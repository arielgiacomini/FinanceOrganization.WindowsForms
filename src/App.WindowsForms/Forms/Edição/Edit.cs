using App.Forms.Enums;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.Repository;
using App.WindowsForms.Services;
using App.WindowsForms.ViewModel;
using Domain.Utils;

namespace App.Forms.Forms.Edição
{
    public partial class FrmEdit : Form
    {
        public EditBillToPayViewModel EditBillToPayViewModel { get; set; } = new EditBillToPayViewModel();
        public EditCashReceivableViewModel EditCashReceivableViewModel { get; set; } = new EditCashReceivableViewModel();
        public IList<EditBillToPayViewModel> BasketEditBillToPayViewModel { get; set; } = new List<EditBillToPayViewModel>();
        public decimal valorContaPagarDigitadoTextBox = 0;
        public string? Environment { get; set; }
        public bool EditInLote { get; set; } = false;

        private AccountRepository _accountRepository;

        public FrmEdit()
        {
            _accountRepository = AccountRepository.Instance;

            InitializeComponent();
        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            PreencherCampos();
        }

        private async void PreencherCampos()
        {
            txtContaPagarNameDescription.Text = EditBillToPayViewModel.Name;
            PreencherComboBoxContaPagarAccount(EditBillToPayViewModel.Account!);
            cboContaPagarFrequencia.Text = EditBillToPayViewModel.Frequence;
            cboContaPagarTipoCadastro.Text = EditBillToPayViewModel.RegistrationType;
            PreencherComboBoxAnoMes(EditBillToPayViewModel.YearMonth!);
            cboContaPagarAnoMesInicial.Text = EditBillToPayViewModel.YearMonth;
            await PreencherComboBoxCadastroContaCategoriaAsync(EditBillToPayViewModel?.Category!);
            txtContaPagarValor.Text = EditBillToPayViewModel.Value.ToString("C");

            if (EditBillToPayViewModel.PurchaseDate == null)
            {
                dtpContaPagarDataCompra.Enabled = false;
                dtpContaPagarDataCompra.Text = null;
            }
            else
            {
                cboHabilitarDataCompra.Checked = true;
                dtpContaPagarDataCompra.Text = EditBillToPayViewModel.PurchaseDate.ToString();
            }

            dtpContaPagarDataVencimento.Text = EditBillToPayViewModel.DueDate.ToString();
            txtContaPagarDataPagamento.Text = EditBillToPayViewModel.PayDay?.ToString();
            rdbPagamentoPago.Checked = EditBillToPayViewModel.HasPay;
            rdbPagamentoNaoPago.Checked = !EditBillToPayViewModel.HasPay;
            rtbContaPagarMensagemAdicional.Text = EditBillToPayViewModel.AdditionalMessage;
            lblContaPagarDataCriacao.Text = EditBillToPayViewModel.LastChangeDate.ToString();

            if (EditInLote)
            {
                txtContaPagarNameDescription.Enabled = true;
                cboContaPagarTipoConta.Enabled = true;
                cboContaPagarFrequencia.Enabled = true;
                cboContaPagarTipoCadastro.Enabled = true;
                cboContaPagarAnoMesInicial.Enabled = false;
                cboContaPagarCategory.Enabled = true;
                txtContaPagarValor.Enabled = true;

                if (EditBillToPayViewModel.PurchaseDate == null)
                {
                    dtpContaPagarDataCompra.Enabled = false;
                }
                else
                {
                    cboHabilitarDataCompra.Checked = true;
                }

                dtpContaPagarDataVencimento.Enabled = false;
                txtContaPagarDataPagamento.Enabled = false;
                rdbPagamentoPago.Enabled = false;
                rdbPagamentoNaoPago.Enabled = false;
                rtbContaPagarMensagemAdicional.Enabled = false;
                lblContaPagarDataCriacao.Enabled = false;
            }
        }

        private void PreencherComboBoxAnoMes(string current)
        {
            var yearMonths = DateServiceUtils.GetListYearMonthsByThreeMonthsBeforeAndTwentyFourAfter();
            var yearMonthsArray = yearMonths.Values.ToArray();

            cboContaPagarAnoMesInicial.Items.AddRange(yearMonthsArray);

            var dateTimeNow = DateTime.Now;
            DateTime actual = new(dateTimeNow.Year, dateTimeNow.Month, 1);
            _ = yearMonths.TryGetValue(actual, out string? currentYearMonth);

            cboContaPagarAnoMesInicial.SelectedItem = current;
        }

        private async Task PreencherComboBoxCadastroContaCategoriaAsync(string currentCategory = null)
        {
            CategoryServices.Environment = Environment;
            var resultSearch = await CategoryServices.SearchCategories(new SearchCategoryViewModel());

            Dictionary<int, string> categoriasContaPagar = new() { };

            int cont = 0;
            foreach (var item in resultSearch.Categories)
            {
                if (cont == 0)
                {
                    categoriasContaPagar.Add(cont, "Nenhum");
                    cont++;
                    categoriasContaPagar.Add(cont, item);
                }
                else
                {
                    categoriasContaPagar.Add(cont, item);
                }

                cont++;
            }

            var categoriasContaPagarOrderBy = categoriasContaPagar
                .OrderBy(x => x.Value)
                .Where(x => x.Key != 0)
                .ToList();

            var first = categoriasContaPagar.FirstOrDefault(x => x.Key == 0);

            cboContaPagarCategory.Items.Add(first.Value);

            foreach (var item in categoriasContaPagarOrderBy)
            {
                cboContaPagarCategory.Items.Add(item.Value);
            }

            if (currentCategory == null)
            {
                cboContaPagarCategory.SelectedItem = first.Value;
            }
            else
            {
                var theChoise = categoriasContaPagarOrderBy
                    .FirstOrDefault(x => x.Value == currentCategory);

                if (theChoise.Value?.Length > 0)
                {
                    cboContaPagarCategory.SelectedItem = theChoise.Value;
                }
                else if (currentCategory != null)
                {
                    cboContaPagarCategory.Items.Add(currentCategory);
                    cboContaPagarCategory.SelectedItem = currentCategory;
                }
                else
                {
                    var dado = categoriasContaPagarOrderBy
                        .FirstOrDefault().Value;

                    cboContaPagarCategory.SelectedItem = dado;
                }
            }
        }

        private void PreencherComboBoxContaPagarAccount(string current)
        {
            cboContaPagarTipoConta.Items.Add(current);

            foreach (var item in _accountRepository._accounts.Values.OrderBy((x) => x.Name))
            {
                string name = item.Name;
                if (item.IsCreditCard)
                {
                    name = string.Concat(item.Name, " - ", item.CardNumber);
                }

                if (item.Enable)
                {
                    cboContaPagarTipoConta.Items.Add(name);
                }
            }

            if (current == null)
            {
                cboContaPagarTipoConta.SelectedItem = _accountRepository._accounts[0];
            }
            else
            {
                var theChoise = _accountRepository._accounts.FirstOrDefault(x => x.Value.Name == current);

                if (theChoise.Value.Name != null)
                {
                    cboContaPagarTipoConta.SelectedItem = theChoise.Value.Name;
                }
                else
                {
                    cboContaPagarTipoConta.SelectedItem = _accountRepository._accounts.FirstOrDefault().Value.Name;
                }
            }
        }

        private async void BtnContaPagarEditar_Click(object sender, EventArgs e)
        {
            if (EditInLote)
            {
                MapFormBasketToViewModel();

                BillToPayServices.Environment = Environment;
                var result = await BillToPayServices.EditBasketBillToPay(BasketEditBillToPayViewModel);

                OutputMapper(result);
            }
            else
            {
                MapFormToViewModel();

                BillToPayServices.Environment = Environment;
                var result = await BillToPayServices.EditBillToPay(EditBillToPayViewModel);

                OutputMapper(result);
            }
        }

        private static void OutputMapper(EditBillToPayOutput result)
        {
            if (result.Output.Status == OutputStatus.Success)
            {
                MessageBox.Show(result.Output.Message,
                    "Edição de Conta Realizado com Sucesso.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var information = string.Empty;

                var errors = result.Output.Errors;
                var validations = result.Output.Validations;

                foreach (var error in errors)
                {
                    information = string
                        .Concat(information, error.Key, " - ", error.Value, " | ");
                }

                foreach (var validation in validations)
                {
                    information = string
                        .Concat(information, validation.Key, " - ", validation.Value, " | ");
                }

                MessageBox.Show(information, "Erro ao tentar cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MapFormToViewModel()
        {
            EditBillToPayViewModel.Name = txtContaPagarNameDescription.Text;
            EditBillToPayViewModel.Account = cboContaPagarTipoConta.Text.Split(" - ")[0];
            EditBillToPayViewModel.Frequence = cboContaPagarFrequencia.Text;
            EditBillToPayViewModel.RegistrationType = cboContaPagarTipoCadastro.Text;
            EditBillToPayViewModel.YearMonth = cboContaPagarAnoMesInicial.Text;
            EditBillToPayViewModel.Category = cboContaPagarCategory.Text;
            EditBillToPayViewModel.Value = Convert.ToDecimal(txtContaPagarValor.Text.Replace("R$ ", ""));
            EditBillToPayViewModel.PurchaseDate = cboHabilitarDataCompra.Checked ? DateServiceUtils.GetDateTimeOfString(dtpContaPagarDataCompra.Text) : null;
            EditBillToPayViewModel.PayDay = string.IsNullOrWhiteSpace(txtContaPagarDataPagamento.Text) ? null : txtContaPagarDataPagamento.Text;
            EditBillToPayViewModel.HasPay = rdbPagamentoPago.Checked;
            EditBillToPayViewModel.DueDate = DateServiceUtils.GetDateTimeOfString(dtpContaPagarDataVencimento.Text) ?? DateTime.Now;
            EditBillToPayViewModel.AdditionalMessage = rtbContaPagarMensagemAdicional.Text;
            EditBillToPayViewModel.LastChangeDate = DateServiceUtils.GetDateTimeOfString(lblContaPagarDataCriacao.Text) ?? DateTime.Now;
        }

        private void MapFormBasketToViewModel()
        {
            foreach (var item in BasketEditBillToPayViewModel)
            {
                BasketEditBillToPayViewModel
                    .FirstOrDefault(f => f.Id == item.Id)!.Name = txtContaPagarNameDescription.Text;
                BasketEditBillToPayViewModel
                    .FirstOrDefault(f => f.Id == item.Id)!.Account = cboContaPagarTipoConta.Text.Split(" - ")[0];
                BasketEditBillToPayViewModel
                    .FirstOrDefault(f => f.Id == item.Id)!.Frequence = cboContaPagarFrequencia.Text;
                BasketEditBillToPayViewModel
                    .FirstOrDefault(f => f.Id == item.Id)!.RegistrationType = cboContaPagarTipoCadastro.Text;
                //BasketEditBillToPayViewModel
                //    .FirstOrDefault(f => f.Id == item.Id)!.YearMonth = cboContaPagarAnoMesInicial.Text;
                BasketEditBillToPayViewModel
                    .FirstOrDefault(f => f.Id == item.Id)!.Category = cboContaPagarCategory.Text;
                BasketEditBillToPayViewModel
                    .FirstOrDefault(f => f.Id == item.Id)!.Value = Convert.ToDecimal(txtContaPagarValor.Text.Replace("R$ ", ""));
                //BasketEditBillToPayViewModel
                //    .FirstOrDefault(f => f.Id == item.Id)!.PurchaseDate = cboHabilitarDataCompra.Checked ? DateServiceUtils.GetDateTimeOfString(dtpContaPagarDataCompra.Text) : null;
                //BasketEditBillToPayViewModel
                //    .FirstOrDefault(f => f.Id == item.Id)!.PayDay = string.IsNullOrWhiteSpace(txtContaPagarDataPagamento.Text) ? null : txtContaPagarDataPagamento.Text;
                //BasketEditBillToPayViewModel
                //    .FirstOrDefault(f => f.Id == item.Id)!.HasPay = rdbPagamentoPago.Checked;
                //BasketEditBillToPayViewModel
                //    .FirstOrDefault(f => f.Id == item.Id)!.DueDate = DateServiceUtils.GetDateTimeOfString(dtpContaPagarDataVencimento.Text) ?? DateTime.Now;
                //BasketEditBillToPayViewModel
                //    .FirstOrDefault(f => f.Id == item.Id)!.AdditionalMessage = rtbContaPagarMensagemAdicional.Text;
                BasketEditBillToPayViewModel
                    .FirstOrDefault(f => f.Id == item.Id)!.LastChangeDate = DateTime.Now;
            }
        }

        private void TxtContaPagarValor_Leave(object sender, EventArgs e)
        {
            valorContaPagarDigitadoTextBox = StringDecimalUtils
            .TranslateStringEmDecimal(txtContaPagarValor.Text);

            txtContaPagarValor.Text = StringDecimalUtils
                .TranslateValorEmStringDinheiro(txtContaPagarValor.Text);
        }

        private void TxtContaPagarValor_Enter(object sender, EventArgs e)
        {
            txtContaPagarValor.Text = "";
        }

        private void CboHabilitarDataCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (cboHabilitarDataCompra.Checked)
            {
                dtpContaPagarDataCompra.Enabled = true;
            }
            else
            {
                dtpContaPagarDataCompra.Text = string.Empty;
                dtpContaPagarDataCompra.Enabled = false;
            }
        }
    }
}