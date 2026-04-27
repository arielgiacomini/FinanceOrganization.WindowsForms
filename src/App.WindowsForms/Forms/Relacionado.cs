using App.Forms.DataSource;
using App.Forms.Forms.Edição;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.Enums;
using App.WindowsForms.Services;
using App.WindowsForms.ViewModel;
using Domain.Utils;

namespace App.WindowsForms.Forms.Excluir
{
    public partial class Relacionado : Form
    {
        public string? Environment { get; set; }
        public Dictionary<string, object> LastSearch = new();
        public Guid Identificador;

        public bool EH_CONTA_PAGAR = true;

        public Relacionado()
        {
            InitializeComponent();
        }

        private void FrmRegistroRelacionado_Load(object sender, EventArgs e)
        {
            // Fix: Remove incorrect access to 'Details' property, use the list of Details directly
            var firstList = LastSearch.FirstOrDefault().Value;
            if (firstList == null)
                return;

            // With this fix:
            System.Collections.IEnumerable? enumerable = firstList as System.Collections.IEnumerable;
            if (enumerable == null)
                return;

            if (enumerable is not IList<DgvVisualizarContaPagarDataSource> lastSearch)
                return;

            var filtered = lastSearch
                .Where(x => x.Id == Identificador)
                .ToList();

            if (filtered == null)
                return;

            if (filtered.Count > 0)
            {
                filtered = filtered.OrderBy(order => order.PurchaseDate).ToList();

                var detailsList = new List<Details>();
                foreach (var item in filtered)
                {
                    if (item.Details != null && item.Details.Count > 0)
                    {
                        detailsList.AddRange(item.Details);
                    }
                }
                ;

                PreecherDataGridViewExcluirDetalhes(detailsList);

                PreecherPrecoMedio();

                lblInformacoesTotais.Text = string
                        .Concat("Quantidade de Registros: ",
                            filtered.Count, " - Total: ",
                            filtered.Sum(x => x.Value).ToString("C"));
            }
        }

        private void PreecherPrecoMedio()
        {
            decimal valorTotalItens = 0;
            int itensTotal = dgvRegistroRelacionado.Rows.Count;

            foreach (DataGridViewRow row in dgvRegistroRelacionado.Rows)
            {
                bool isOkValue = decimal.TryParse(row.Cells[5].Value.ToString(), out decimal valor);

                valorTotalItens += isOkValue ? valor : 0;
            }

            decimal avgPrice = 0;
            if (itensTotal > 0)
            {
                avgPrice = valorTotalItens / itensTotal;
            }

            lblValorMedioTotalLista.Text = string
                .Concat("Valor Médio Total: ", avgPrice.ToString("C"));
        }

        private void PreecherDataGridViewExcluirDetalhes(IList<Details> details)
        {
            dgvRegistroRelacionado.ContextMenuStrip = cmsDgvRegistroRelacionadoActions;
            dgvRegistroRelacionado.DataSource = details;
            dgvRegistroRelacionado.Columns[0].HeaderText = "Id";
            dgvRegistroRelacionado.Columns[0].Visible = false;
            dgvRegistroRelacionado.Columns[1].HeaderText = "Id da tabela pai";
            dgvRegistroRelacionado.Columns[1].Visible = false;
            dgvRegistroRelacionado.Columns[2].HeaderText = "Conta";
            dgvRegistroRelacionado.Columns[3].HeaderText = "Descrição";
            dgvRegistroRelacionado.Columns[4].HeaderText = "Categoria";
            dgvRegistroRelacionado.Columns[5].HeaderText = "Valor";
            dgvRegistroRelacionado.Columns[5].DefaultCellStyle.Format = "C2";
            dgvRegistroRelacionado.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRegistroRelacionado.Columns[6].HeaderText = "Data de Compra";
            dgvRegistroRelacionado.Columns[7].HeaderText = "Vencimento";
            dgvRegistroRelacionado.Columns[8].HeaderText = "Mês/Ano";
            dgvRegistroRelacionado.Columns[9].HeaderText = "Frequência";
            dgvRegistroRelacionado.Columns[10].HeaderText = "Tipo";
            dgvRegistroRelacionado.Columns[11].HeaderText = "Data de Pagamento";
            dgvRegistroRelacionado.Columns[12].HeaderText = "Pago?";
            dgvRegistroRelacionado.Columns[13].HeaderText = "Mensagem";
            dgvRegistroRelacionado.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRegistroRelacionado.Columns[14].HeaderText = "Data de Criação";
            dgvRegistroRelacionado.Columns[14].Visible = false;
            dgvRegistroRelacionado.Columns[15].HeaderText = "Data de Alteração";
            dgvRegistroRelacionado.Columns[15].Visible = false;
        }

        private void DgvRegistroRelacionado_SelectionChanged(object sender, EventArgs e)
        {
            decimal valorTotalItensSelecionados = 0;
            int quantidadeTotalItensSelecionados = dgvRegistroRelacionado.SelectedRows.Count;

            foreach (DataGridViewRow row in dgvRegistroRelacionado.SelectedRows)
            {
                bool isOKRemainingValue = decimal.TryParse(row.Cells[5].Value.ToString(), out decimal remainingValue);
                valorTotalItensSelecionados += isOKRemainingValue ? remainingValue : 0;
            }

            decimal avgPrice = 0;
            if (quantidadeTotalItensSelecionados > 0)
            {
                avgPrice = valorTotalItensSelecionados / quantidadeTotalItensSelecionados;
            }

            lblValorTotalMedioSelecionados.Text = string
                    .Concat("Valor Médio Apenas Selecionados: ", avgPrice.ToString("C"));

            lblValorRestanteRegistroRelacionadoDataGridView.Text = string
                .Concat("Valor restante dos ", quantidadeTotalItensSelecionados, " itens selecionados: ", valorTotalItensSelecionados.ToString("C"));
        }

        private async void ToolEditarRegistro_Click(object sender, EventArgs e)
        {
            var currentCell = dgvRegistroRelacionado.CurrentCell;
            var rowIndexOld = currentCell.RowIndex;

            if (currentCell.RowIndex >= 0)
            {
                _ = Guid.TryParse(dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[0].Value?.ToString(), out Guid guidId);

                if (EH_CONTA_PAGAR)
                {
                    await EditarContaPagar(currentCell, rowIndexOld, guidId);
                }
                else
                {
                    await EditarContaReceber(currentCell, rowIndexOld, guidId);
                }
            }
        }

        private async void ToolDesabilitarRegistro_Click(object sender, EventArgs e)
        {
            var currentCell = dgvRegistroRelacionado.CurrentCell;

            if (currentCell.RowIndex >= 0)
            {
                dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[0].Selected = true;
                var descricaoRow = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[3].Value.ToString();
                _ = int.TryParse(dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[1].Value.ToString(), out int identificadorContaReceber);
                if (identificadorContaReceber <= 0)
                {
                    MessageBox.Show("Não encontramos o Identificador da Conta Receber conseguir editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox
                    .Show($"Deseja Realmente deseja DESABILITAR? o registro: {descricaoRow}", $"Ambiente: [{Environment}] - E aí, tem certeza?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    OutputDetails output;

                    if (EH_CONTA_PAGAR)
                    {
                        BillToPayServices.Environment = Environment;
                        var resultHttp = await BillToPayServices.DisableBillToPay(new DisableBillToPayViewModel() { Id = identificadorContaReceber });
                        output = resultHttp.Output;
                    }
                    else
                    {
                        CashReceivableServices.Environment = Environment;
                        var resultHttp = await CashReceivableServices.DisableCashReceivable(new DisableCashReceivableViewModel() { Id = identificadorContaReceber });
                        output = resultHttp.Output;
                    }

                    if (output.Status == OutputStatus.Success)
                    {
                        MessageBox.Show(output.Message,
                            "Registro desabilitado com sucesso.",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var information = string.Empty;

                        var errors = output?.Errors;
                        var validations = output?.Validations;

                        if (errors != null)
                        {
                            foreach (var error in errors)
                            {
                                information = string
                                    .Concat(information, error.Key, " - ", error.Value, " | ");
                            }
                        }

                        if (validations != null)
                        {
                            foreach (var validation in validations)
                            {
                                information = string
                                    .Concat(information, validation.Key, " - ", validation.Value, " | ");
                            }
                        }

                        MessageBox.Show(information, "Erro ao tentar desabilitar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Remove o símbolo da moeda de uma string, independente da cultura
        /// </summary>
        private string RemoveCurrencySymbol(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "0";

            // Remove símbolos comuns de moeda e espaços
            return value
                .Replace("R$", "")
                .Replace("€", "")
                .Replace("$", "")
                .Replace("£", "")
                .Replace("¥", "")
                .Trim();
        }

        private async Task EditarContaPagar(DataGridViewCell currentCell, int rowIndexOld, Guid guidId)
        {
            var firstSelectedRow = new EditBillToPayViewModel()
            {
                Id = guidId,
                IdFixedInvoice = Convert.ToInt32(dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[1].Value?.ToString()),
                Account = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[2].Value?.ToString(),
                Name = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[3].Value?.ToString(),
                Category = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[4].Value?.ToString(),
                Value = Convert.ToDecimal(RemoveCurrencySymbol(dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[5].Value?.ToString() ?? "0")),
                PurchaseDate = DateUtils.GetDateTimeOfString(dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[6].Value?.ToString()),
                DueDate = DateUtils.GetDateTimeOfString(dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[7].Value?.ToString())!.Value,
                YearMonth = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[8].Value?.ToString(),
                Frequence = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[9].Value?.ToString(),
                RegistrationType = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[10].Value?.ToString(),
                PayDay = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[11].Value?.ToString(),
                HasPay = Convert.ToBoolean(dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[12].Value?.ToString()),
                AdditionalMessage = dgvRegistroRelacionado.Rows[currentCell.RowIndex].Cells[13].Value?.ToString(),
                LastChangeDate = DateTime.Now
            };

            bool editInLote = false;

            List<EditBillToPayViewModel> basketEdits = new();

            if (dgvRegistroRelacionado.SelectedRows.Count > 1)
            {
                editInLote = true;

                foreach (DataGridViewRow row in dgvRegistroRelacionado.SelectedRows)
                {
                    _ = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid idBillToPay);
                    _ = int.TryParse(row.Cells[1].Value.ToString(), out int registrationId);

                    basketEdits.Add(new EditBillToPayViewModel()
                    {
                        Id = idBillToPay,
                        IdFixedInvoice = registrationId,
                        Account = row.Cells[2].Value?.ToString(),
                        Name = row.Cells[3].Value?.ToString(),
                        Category = row.Cells[4].Value?.ToString(),
                        Value = Convert.ToDecimal(RemoveCurrencySymbol(row.Cells[5].Value?.ToString())),
                        PurchaseDate = DateUtils.GetDateTimeOfString(row.Cells[6].Value?.ToString()),
                        DueDate = DateUtils.GetDateTimeOfString(row.Cells[7].Value?.ToString()) ?? DateTime.Now,
                        YearMonth = row.Cells[8].Value?.ToString(),
                        Frequence = row.Cells[9].Value?.ToString(),
                        RegistrationType = row.Cells[10].Value?.ToString(),
                        PayDay = row.Cells[11].Value?.ToString(),
                        HasPay = Convert.ToBoolean(row.Cells[12].Value?.ToString()),
                        AdditionalMessage = row.Cells[13].Value?.ToString(),
                        LastChangeDate = DateTime.Now
                    });
                }
            }

            FrmEdit frmEditInLote = new()
            {
                EditBillToPayViewModel = firstSelectedRow,
                BasketEditBillToPayViewModel = basketEdits,
                Environment = Environment,
                EditInLote = editInLote,
                AccountType = AccountType.ContaAPagar
            };

            frmEditInLote.ShowDialog();

            dgvRegistroRelacionado.CurrentCell = dgvRegistroRelacionado.Rows[rowIndexOld].Cells[3];
        }

        private async Task EditarContaReceber(DataGridViewCell e, int rowIndexOld, Guid guidId)
        {
            var firstSelectedRow = new EditCashReceivableViewModel()
            {
                Id = guidId,
                IdCashReceivableRegistration = Convert.ToInt32(dgvRegistroRelacionado.Rows[e.RowIndex].Cells[1].Value?.ToString()),
                Account = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[2].Value?.ToString(),
                Name = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[3].Value?.ToString(),
                Category = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[4].Value?.ToString(),
                Value = Convert.ToDecimal(RemoveCurrencySymbol(dgvRegistroRelacionado.Rows[e.RowIndex].Cells[5].Value?.ToString())),
                ManipulatedValue = Convert.ToDecimal(RemoveCurrencySymbol(dgvRegistroRelacionado.Rows[e.RowIndex].Cells[6].Value?.ToString())),
                /*7-TotalValue*/
                /*8-DetailsQuantity*/
                AgreementDate = DateUtils.GetDateTimeOfString(dgvRegistroRelacionado.Rows[e.RowIndex].Cells[9].Value?.ToString()),
                DueDate = DateUtils.GetDateTimeOfString(dgvRegistroRelacionado.Rows[e.RowIndex].Cells[10].Value?.ToString()) ?? DateTime.Now,
                YearMonth = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[11].Value?.ToString(),
                Frequence = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[12].Value?.ToString(),
                RegistrationType = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[13].Value?.ToString(),
                DateReceived = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[14].Value?.ToString(),
                HasReceived = Convert.ToBoolean(dgvRegistroRelacionado.Rows[e.RowIndex].Cells[15].Value?.ToString()),
                AdditionalMessage = dgvRegistroRelacionado.Rows[e.RowIndex].Cells[16].Value?.ToString(),
                LastChangeDate = DateUtils.GetDateTimeOfString(dgvRegistroRelacionado.Rows[e.RowIndex].Cells[18].Value?.ToString()) ?? DateTime.Now
            };

            bool editInLote = false;

            List<EditCashReceivableViewModel> basketEdits = new();

            if (dgvRegistroRelacionado.SelectedRows.Count > 1)
            {
                editInLote = true;

                foreach (DataGridViewRow row in dgvRegistroRelacionado.SelectedRows)
                {
                    _ = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid idCashReceivable);
                    _ = int.TryParse(row.Cells[1].Value.ToString(), out int registrationId);

                    basketEdits.Add(new EditCashReceivableViewModel()
                    {
                        Id = idCashReceivable,
                        IdCashReceivableRegistration = registrationId,
                        Account = row.Cells[2].Value?.ToString(),
                        Name = row.Cells[3].Value?.ToString(),
                        Category = row.Cells[4].Value?.ToString(),
                        Value = Convert.ToDecimal(RemoveCurrencySymbol(row.Cells[5].Value?.ToString())),
                        ManipulatedValue = Convert.ToDecimal(RemoveCurrencySymbol(row.Cells[6].Value?.ToString())),
                        /*7-TotalValue*/
                        /*8-DetailsQuantity*/
                        AgreementDate = DateUtils.GetDateTimeOfString(row.Cells[9].Value?.ToString()),
                        DueDate = DateUtils.GetDateTimeOfString(row.Cells[10].Value?.ToString()) ?? DateTime.Now,
                        YearMonth = row.Cells[11].Value?.ToString(),
                        Frequence = row.Cells[12].Value?.ToString(),
                        RegistrationType = row.Cells[13].Value?.ToString(),
                        DateReceived = row.Cells[14].Value?.ToString(),
                        HasReceived = Convert.ToBoolean(row.Cells[15].Value?.ToString()),
                        AdditionalMessage = row.Cells[16].Value?.ToString(),
                        LastChangeDate = DateUtils.GetDateTimeOfString(row.Cells[18].Value?.ToString()) ?? DateTime.Now
                    });
                }
            }

            FrmEdit frmEditInLote = new()
            {
                EditCashReceivableViewModel = firstSelectedRow,
                BasketEditCashReceivableViewModel = basketEdits,
                Environment = Environment,
                EditInLote = editInLote,
                AccountType = AccountType.ContaAReceber
            };

            frmEditInLote.ShowDialog();

            dgvRegistroRelacionado.CurrentCell = dgvRegistroRelacionado.Rows[rowIndexOld].Cells[3];
        }
    }
}