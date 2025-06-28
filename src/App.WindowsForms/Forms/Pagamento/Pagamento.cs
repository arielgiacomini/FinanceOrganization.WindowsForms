using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.Repository;
using Domain.Utils;

namespace App.Forms.Forms.Pay
{
    public partial class FrmPagamento : Form
    {
        private const string EH_CARTAO_CREDITO_NAIRA = "Cartão de Crédito Nubank Naíra";

        public Guid IdentificadorUnicoContaPagar { get; set; } = Guid.Empty;
        public string? Nome { get; set; } = string.Empty;
        public string? Conta { get; set; } = string.Empty;
        public string AdditionalMessage { get; set; } = string.Empty;
        public string? AnoMes { get; set; } = string.Empty;
        public decimal? Valor { get; set; } = 0;
        public string? Environment { get; set; }

        private AccountRepository _accountRepository;

        public FrmPagamento()
        {
            _accountRepository = AccountRepository.Instance;

            InitializeComponent();
        }

        private void PreencherComboBoxAnoMes(string selectedItem = null)
        {
            var yearMonths = DateServiceUtils.GetListYearMonthsByThreeMonthsBeforeAndTwentyFourAfter();

            cboPagamentoMesAno.Items.AddRange(yearMonths.Values.ToArray());

            var dateTimeNow = DateTime.Now;
            DateTime actual = new(dateTimeNow.Year, dateTimeNow.Month, 1);
            _ = yearMonths.TryGetValue(actual, out string? currentYearMonth);

            cboPagamentoMesAno.SelectedItem = currentYearMonth;

            if (!string.IsNullOrWhiteSpace(selectedItem))
            {
                cboPagamentoMesAno.SelectedItem = selectedItem;
            }
        }

        private void PreencherComboBoxContaPagarTipoConta(string accountSelected = null)
        {
            var accounts = _accountRepository._accounts.Values.OrderBy((x) => x.Name);

            foreach (var account in accounts)
            {
                cboPagamentoConta.Items.Add(account.Name);
            }

            if (string.IsNullOrWhiteSpace(accountSelected))
            {
                cboPagamentoConta.SelectedItem = accounts.FirstOrDefault()?.Name;
            }
            else
            {
                var theChoise = accounts.FirstOrDefault(x => x.Name == accountSelected);

                if (theChoise?.Name.Length > 0)
                {
                    cboPagamentoConta.SelectedItem = theChoise.Name;
                }
                else
                {
                    cboPagamentoConta.SelectedItem = accounts.FirstOrDefault()?.Name;
                }
            }
        }

        private void FrmPagamento_Load(object sender, EventArgs e)
        {
            PreencherComboBoxAnoMes(AnoMes);
            PreencherComboBoxContaPagarTipoConta(Conta);
            RegraApresentarInfoPreenchidas();
            txtPagamentoData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void RegraApresentarInfoPreenchidas()
        {
            if (IdentificadorUnicoContaPagar != Guid.Empty)
            {
                txtPagamentoIdContaPagar.Enabled = false;
                cboPagamentoConta.Enabled = false;
                cboPagamentoMesAno.Enabled = false;
                txtPagamentoIdContaPagar.Text = IdentificadorUnicoContaPagar.ToString();
            }

            if (!string.IsNullOrWhiteSpace(Nome))
            {
                lblPagamentoNome.Text = Nome;
            }

            if (Valor != null && Valor.Value > 0)
            {
                lblPagamentoValor.Text = Valor.Value.ToString("C");
            }
        }

        private async void BtnPagamentoPagar_Click(object sender, EventArgs e)
        {
            var account = _accountRepository
                    .GetAccountByName(cboPagamentoConta.Text!);

            if (account == null)
            {
                MessageBox.Show("Conta não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (account.IsCreditCard)
            {
                if (!string.IsNullOrWhiteSpace(txtPagamentoIdContaPagar.Text))
                {
                    MessageBox.Show(
                        $"Se você está efetuando um pagamento em massa da conta: " +
                        $"{cboPagamentoConta.Text} não é possível informar um ID de conta para pagamento.",
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SetOutput(await SendPayment());
            }
            else
            {
                _ = Guid.TryParse(txtPagamentoIdContaPagar.Text, out Guid idContaPagar);

                SetOutput(await SendPayment(idContaPagar));
            }
        }

        private async Task<PayBillToPayOutput> SendPayment(Guid? idContaPagar = null, bool? advancePayment = null)
        {
            PayBillToPayViewModel request;
            PayBillToPayOutput output;

            request = MapPayBillToPayToRequest(idContaPagar, true, advancePayment);

            BillToPayServices.Environment = Environment;
            output = await BillToPayServices.PayBillToPay(request);

            return output;
        }

        private async void SetOutput(PayBillToPayOutput? output)
        {
            if (output == null)
            {
                MessageBox.Show("Ocorreu um erro ao tentar efetuar o pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (output!.Output!.Status == OutputStatus.Success)
            {
                MessageBox.Show($"{output!.Output!.Message}", "Pagamento realizado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var validations = output!.Output?.Validations;

            if (validations != null && validations!.Count > 0)
            {
                var mensagem = string.Empty;
                foreach (var validation in validations)
                {
                    mensagem += string.Concat(validation.Key, "-", validation.Value);

                    if (validation.Key == "[34]" && validations.Count == 1)
                    {
                        var advancePayment = MessageBox.Show(
                            string.Concat(mensagem, "\n\n", "Deseja efetuar o pagamento mesmo assim?"),
                            "Validação de Conta a Pagar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (advancePayment == DialogResult.Yes)
                        {
                            // Chamar o método de pagamento com a opção de adiantamento

                            SetOutput(await SendPayment(advancePayment: true));

                            return;
                        }
                    }
                }

                MessageBox.Show(mensagem, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var errors = output!.Output?.Errors;
            if (errors != null && errors!.Count > 0)
            {
                var mensagem = string.Empty;
                foreach (var error in errors)
                {
                    mensagem += string.Concat(error.Key, "-", error.Value);
                }

                MessageBox.Show(mensagem, "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var message = output.Output.Message;
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PayBillToPayViewModel MapPayBillToPayToRequest(Guid? idContaPagar = null, bool sendYearMonthAndAccount = true, bool? advancePayment = null)
        {
            var request = new PayBillToPayViewModel()
            {
                Id = idContaPagar,
                PayDay = txtPagamentoData.Text,
                HasPay = rdbPagamentoPago.Checked ? rdbPagamentoPago.Checked : rdbPagamentoNaoPago.Checked,
                LastChangeDate = DateTime.Now,
                YearMonth = cboPagamentoMesAno.Text,
                Account = cboPagamentoConta.Text,
                AdvancePayment = advancePayment,
                ConsiderNairaCreditCard = ckbCartaoCreditoNaira.Checked,
            };

            if (!sendYearMonthAndAccount)
            {
                request.Account = null;
                request.YearMonth = null;
            }

            return request;
        }

        private void CkbCartaoCreditoNaira_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCartaoCreditoNaira.Checked)
            {
                MessageBox.Show($"Só será efetuado pagamento de todos os itens que comtemplam a fatura do mês [{cboPagamentoMesAno.Text}] de todos os itens que estão marcados como [{EH_CARTAO_CREDITO_NAIRA}]", "Informação de Pagamento",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var account = _accountRepository.GetAccountByName(cboPagamentoConta.Text);

                if (account != null)
                {
                    cboPagamentoConta.Text = account.Name;
                }
            }
        }
    }
}