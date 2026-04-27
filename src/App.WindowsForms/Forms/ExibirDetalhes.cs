using App.Forms.DataSource;
using App.Forms.Forms.Edição;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.DataSource;
using App.WindowsForms.Entities;
using App.WindowsForms.Enums;
using App.WindowsForms.Forms.Excluir;
using App.WindowsForms.Services;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Domain.Utils;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Diagnostics;


namespace App.WindowsForms.Forms.ExcluirDetalhes
{
    public partial class FrmExibirDetalhes : Form
    {
        public DeleteBillToPayViewModel DeleteBillToPayViewModel { get; set; } = new DeleteBillToPayViewModel();
        public SearchBillToPayViewModel PostSearchBillToPayViewModel { get; set; } = new SearchBillToPayViewModel();
        public SearchCashReceivableViewModel PostSearchCashReceivableViewModel { get; set; } = new SearchCashReceivableViewModel();
        public EditBillToPayViewModel EditBillToPayViewModel { get; set; } = new EditBillToPayViewModel();
        private Dictionary<string, Stopwatch> _timesLoading = new();

        public Dictionary<string, object> LastSearch = new();
        public string? Environment { get; set; }
        public IList<Account>? CreditCard
        {
            set
            {
                _creditCard = value?.ToList();
                _listCreditCard = _creditCard?.ToList().Select(static x => x.Name).ToList();
            }
        }

        private static List<Account>? _creditCard;
        private static List<string>? _listCreditCard;

        private bool EH_CONTA_PAGAR = true;

        public FrmExibirDetalhes()
        {
            InitializeComponent();
        }

        private async void FrmExcluirDetalhes_Load(object sender, EventArgs e)
        {
            if (PostSearchBillToPayViewModel.IdBillToPayRegistrations != null)
            {
                EH_CONTA_PAGAR = true;
            }
            else if (PostSearchCashReceivableViewModel.IdCashReceivableRegistrations != null)
            {
                EH_CONTA_PAGAR = false;
                btnShowDetails.Visible = false;
            }

            await CarregamentoTelaAgain();
        }

        private void PreencherTempoCarregamentoTela(Dictionary<string, Stopwatch> stopWatchs)
        {
            stopWatchs?.GetValueOrDefault("Total")?.Stop();

            TimeSpan ts = stopWatchs?.GetValueOrDefault("Total")?.Elapsed ?? new TimeSpan();

            string elapsedTime = string
                .Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            lblRunTimeLoad.Text = string
                .Concat("Tempo total de carregamento: ", elapsedTime,
                " - RequestHttp: ", stopWatchs?.GetValueOrDefault("stopWatchHttpRequestContaPagar")?.ElapsedMilliseconds, "ms",
                " - MapSearchResultContaPagarToDataSource: ", stopWatchs?.GetValueOrDefault("stopWatchHttpRequestContaPagar")?.ElapsedMilliseconds, "ms",
                " - OrdenacaoRegraContasPagar: ", stopWatchs?.GetValueOrDefault("stopWatchOrdenacaoRegraContasPagar")?.ElapsedMilliseconds, "ms",
                " - PreecherDataGridViewDetalhes: ", stopWatchs?.GetValueOrDefault("stopWatchPreecherDataGridViewDetalhes")?.ElapsedMilliseconds, "ms"
                );
        }

        private void PreecherPrecoMedio()
        {
            try
            {
                if (dgvExcluirDetalhes.SelectedRows.Count == 0)
                    return;

                decimal valorTotalItens = 0;
                int quantidadeItensPagos = 0;

                foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
                {
                    var valorCell = row.Cells[7]?.Value;
                    var payCell = row.Cells[15]?.Value;

                    if (valorCell != null && decimal.TryParse(valorCell.ToString(), out decimal valor) &&
                        payCell != null && bool.TryParse(payCell.ToString(), out bool hasPay) && hasPay)
                    {
                        valorTotalItens += valor;
                        quantidadeItensPagos++;
                    }
                }

                var firstSelectedRow = dgvExcluirDetalhes.SelectedRows[0];
                string descricaoConta = firstSelectedRow.Cells[3].Value?.ToString() ?? string.Empty;

                decimal avgPrice = quantidadeItensPagos > 0 ? valorTotalItens / quantidadeItensPagos : 0;

                lblValorMedioOnlyPagos.Text = $"[{descricaoConta}] - Valor Médio: {avgPrice:C}";
            }
            catch (Exception ex)
            {
                // Log exception if needed
            }
        }

        private void PreencherlblTotaisRegistrosEValores()
        {
            decimal valorTotalItens = 0;
            int quantidadeTotalItens = dgvExcluirDetalhes.RowCount;

            foreach (DataGridViewRow row in dgvExcluirDetalhes.Rows)
            {
                var valorCell = row.Cells[7].Value;
                if (valorCell != null && decimal.TryParse(valorCell.ToString(), out decimal valor))
                {
                    valorTotalItens += valor;
                }
            }

            lblTotaisRegistrosEValores.Text = $"Totais de Registro(s): {quantidadeTotalItens} - {valorTotalItens:C}";
        }

        private async Task PreencherCampos()
        {
            LastSearch.Clear();

            IList<DgvVisualizarContaPagarDataSource> dgvVisualizarContaPagarDataSources = new List<DgvVisualizarContaPagarDataSource>();
            IList<DgvVisualizarContaReceberDataSource> dgvVisualizarContaReceberDataSources = new List<DgvVisualizarContaReceberDataSource>();

            if (EH_CONTA_PAGAR)
            {
                Stopwatch stopWatchHttpRequestContaPagar = new();
                _timesLoading.Add("stopWatchHttpRequestContaPagar", stopWatchHttpRequestContaPagar);
                stopWatchHttpRequestContaPagar.Start();

                var contaPagar = await BillToPayServices.SearchBillToPay(PostSearchBillToPayViewModel);

                stopWatchHttpRequestContaPagar.Stop();

                Stopwatch stopWatchMapSearchResultContaPagarToDataSource = new();
                _timesLoading.Add("stopWatchMapSearchResultContaPagarToDataSource", stopWatchMapSearchResultContaPagarToDataSource);
                stopWatchMapSearchResultContaPagarToDataSource.Start();

                dgvVisualizarContaPagarDataSources = MapSearchResultContaPagarToDataSource(contaPagar);

                stopWatchMapSearchResultContaPagarToDataSource.Stop();

                LastSearch.Add(DateTime.Now.ToString(), dgvVisualizarContaPagarDataSources);

                Stopwatch stopWatchOrdenacaoRegraContasPagar = new();
                _timesLoading.Add("stopWatchOrdenacaoRegraContasPagar", stopWatchOrdenacaoRegraContasPagar);
                stopWatchOrdenacaoRegraContasPagar.Start();

                IList<DgvVisualizarContaPagarDataSource> allPagar = OrdenacaoRegraContasPagar(dgvVisualizarContaPagarDataSources);

                stopWatchOrdenacaoRegraContasPagar.Stop();

                Stopwatch stopWatchPreecherDataGridViewDetalhes = new();
                _timesLoading.Add("stopWatchPreecherDataGridViewDetalhes", stopWatchPreecherDataGridViewDetalhes);
                stopWatchPreecherDataGridViewDetalhes.Start();

                PreecherDataGridViewDetalhes<DgvVisualizarContaPagarDataSource>(allPagar);

                stopWatchPreecherDataGridViewDetalhes.Stop();
            }

            if (!EH_CONTA_PAGAR)
            {
                SearchCashReceivableOutput contaReceber = new();

                contaReceber = await CashReceivableServices.SearchCashReceivable(PostSearchCashReceivableViewModel);

                dgvVisualizarContaReceberDataSources = MapSearchResultContaReceberToDataSource(contaReceber);

                LastSearch.Add(DateTime.Now.ToString(), dgvVisualizarContaReceberDataSources);

                IList<DgvVisualizarContaReceberDataSource> allReceber = OrdenacaoRegraContasReceber(dgvVisualizarContaReceberDataSources);

                PreecherDataGridViewDetalhes<DgvVisualizarContaReceberDataSource>(allReceber, false);
            }
        }

        private static IList<DgvVisualizarContaPagarDataSource> OrdenacaoRegraContasPagar(IList<DgvVisualizarContaPagarDataSource> dataSource)
        {
            ConcurrentDictionary<int, DgvVisualizarContaPagarDataSource> dictionary = new();
            int contador = 0;

            List<DgvVisualizarContaPagarDataSource> topRecords = new();

            if (!FewRecords(dataSource))
            {
                topRecords = dataSource
                    .Where(x => x.HasPay && x.DueDate < DateTime.Now)
                    .OrderByDescending(dueDate => dueDate.DueDate)
                    .ToList()
                    .Take(8)
                    .ToList();
            }

            var dataSourceOrderBy = dataSource
            .OrderBy(hasPay => hasPay.HasPay)
            .ThenBy(creditCard => _listCreditCard?.Contains(creditCard.Account))
            .ThenBy(dueDate => dueDate.DueDate)
            .ThenByDescending(purchase => purchase.PurchaseDate)
            .ToList();

            foreach (var topThree in topRecords.OrderBy(dueDate => dueDate.DueDate))
            {
                contador++;

                dataSourceOrderBy.Remove(topThree);

                dictionary.TryAdd(contador, topThree);
            }

            foreach (var item in dataSourceOrderBy)
            {
                contador++;

                dictionary.TryAdd(contador, item);
            }

            IList<DgvVisualizarContaPagarDataSource> all
                    = new List<DgvVisualizarContaPagarDataSource>(dictionary.Count);

            foreach (var item in dictionary)
            {
                all.Add(item.Value);
            }

            return all;
        }

        private static IList<DgvVisualizarContaReceberDataSource> OrdenacaoRegraContasReceber(IList<DgvVisualizarContaReceberDataSource> dataSource)
        {
            ConcurrentDictionary<int, DgvVisualizarContaReceberDataSource> dictionary = new();
            int contador = 0;

            List<DgvVisualizarContaReceberDataSource> topRecords = new();

            if (!FewRecords(dataSource))
            {
                topRecords = dataSource
                    .Where(x => x.HasReceived && x.DueDate < DateTime.Now)
                    .OrderByDescending(dueDate => dueDate.DueDate)
                    .ToList()
                    .Take(8)
                    .ToList();
            }

            var dataSourceOrderBy = dataSource
            .OrderBy(hasPay => hasPay.HasReceived)
            .ThenBy(creditCard => _listCreditCard?.Contains(creditCard.Account))
            .ThenBy(dueDate => dueDate.DueDate)
            .ThenByDescending(purchase => purchase.AgreementDate)
            .ToList();

            foreach (var topThree in topRecords.OrderBy(dueDate => dueDate.DueDate))
            {
                contador++;

                dataSourceOrderBy.Remove(topThree);

                dictionary.TryAdd(contador, topThree);
            }

            foreach (var item in dataSourceOrderBy)
            {
                contador++;

                dictionary.TryAdd(contador, item);
            }

            IList<DgvVisualizarContaReceberDataSource> all
                    = new List<DgvVisualizarContaReceberDataSource>(dictionary.Count);

            foreach (var item in dictionary)
            {
                all.Add(item.Value);
            }

            return all;
        }

        private static bool FewRecords<T>(IList<T> dataSource)
        {
            return dataSource.Count <= 18;
        }

        private void PreecherDataGridViewDetalhes<T>(object dataSourceOrderBy, bool contaPagar = true)
        {
            try
            {
                dgvExcluirDetalhes.DataSource = dataSourceOrderBy;

                string currencySymbol = GetCurrencySymbol();

                ConfigureColumn(0, "Id", false);
                ConfigureColumn(1, "Id da tabela pai", false);
                ConfigureColumn(2, "Conta", false);
                ConfigureColumn(3, "Descrição");
                ConfigureColumn(4, "Categoria");

                ConfigureColumn(5, contaPagar ? $"{currencySymbol} Restante" : $"{currencySymbol} Valor", true, "C2", DataGridViewContentAlignment.MiddleRight);
                ConfigureColumn(6, contaPagar ? $"{currencySymbol} Realizado" : $"{currencySymbol} Valor Manipulado", true, "C2", DataGridViewContentAlignment.MiddleRight);
                ConfigureColumn(7, $"{currencySymbol} Total", contaPagar, "C2", DataGridViewContentAlignment.MiddleRight);
                ConfigureColumn(8, "Qtd Compras", contaPagar);
                if (dgvExcluirDetalhes.Columns[8] != null)
                    dgvExcluirDetalhes.Columns[8].ToolTipText = "Quantidade de Compras relacionadas a este item...";

                ConfigureColumn(9, contaPagar ? "Data de Compra" : "Data do Acordo");
                ConfigureColumn(10, "Vencimento");
                ConfigureColumn(11, "Mês/Ano");
                ConfigureColumn(12, "Frequência");
                ConfigureColumn(13, "Tipo");
                ConfigureColumn(14, contaPagar ? "Data de Pagamento" : "Data de Recebimento");
                ConfigureColumn(15, contaPagar ? "Pago?" : "Recebido?");

                ConfigureColumn(16, "Mensagem", true, null, DataGridViewContentAlignment.MiddleLeft);
                ConfigureColumn(17, "Data de Criação", false);
                ConfigureColumn(18, "Data de Alteração", false);
            }
            finally
            {
                Collor();
            }
        }

        private void ConfigureColumn(int columnIndex, string headerText, bool visible = true, string? format = null, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.NotSet)
        {
            if (columnIndex >= dgvExcluirDetalhes.Columns.Count)
                return;

            var column = dgvExcluirDetalhes.Columns[columnIndex];

            // Only set HeaderText if different (avoids unnecessary property setter overhead)
            if (column.HeaderText != headerText)
            {
                column.HeaderText = headerText;
            }

            // Only set Visible if different
            if (column.Visible != visible)
            {
                column.Visible = visible;
            }

            // Only modify DefaultCellStyle if needed
            if (!string.IsNullOrEmpty(format) || alignment != DataGridViewContentAlignment.NotSet)
            {
                var style = column.DefaultCellStyle;

                if (!string.IsNullOrEmpty(format) && style.Format != format)
                {
                    style.Format = format;
                }

                if (alignment != DataGridViewContentAlignment.NotSet && style.Alignment != alignment)
                {
                    style.Alignment = alignment;
                }
            }
        }

        private static IList<DgvVisualizarContaPagarDataSource> MapSearchResultContaPagarToDataSource(SearchBillToPayOutput searchBillToPayOutput)
        {
            if (searchBillToPayOutput?.Output?.Data == null)
                return new List<DgvVisualizarContaPagarDataSource>();

            var dados = searchBillToPayOutput.Output.Data;

            if (dados is IEnumerable<DgvVisualizarContaPagarDataSource> directCast)
            {
                return directCast.ToList();
            }

            var json = JsonConvert.SerializeObject(dados);
            var conversion = JsonConvert.DeserializeObject<IList<DgvVisualizarContaPagarDataSource>>(json);

            return conversion ?? new List<DgvVisualizarContaPagarDataSource>();
        }

        private static IList<DgvVisualizarContaReceberDataSource> MapSearchResultContaReceberToDataSource(SearchCashReceivableOutput searchOutput)
        {
            if (searchOutput?.Output?.Data == null)
                return new List<DgvVisualizarContaReceberDataSource>();

            var dados = searchOutput.Output.Data;

            if (dados is IEnumerable<DgvVisualizarContaReceberDataSource> directCast)
            {
                return directCast.ToList();
            }

            var json = JsonConvert.SerializeObject(dados);
            var conversion = JsonConvert.DeserializeObject<IList<DgvVisualizarContaReceberDataSource>>(json);

            return conversion ?? new List<DgvVisualizarContaReceberDataSource>();
        }

        private void DgvExcluirDetalhes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Collor() agora é chamado apenas no final de PreecherDataGridViewDetalhes
            // para evitar múltiplas iterações desnecessárias
        }

        private void Collor()
        {
            if (dgvExcluirDetalhes.Rows.Count == 0 || _listCreditCard == null)
                return;

            var creditCardHashSet = new HashSet<string>(_listCreditCard, StringComparer.OrdinalIgnoreCase);
            var nuBankAccounts = new HashSet<string>(_listCreditCard.Where(x => x.Contains("Nubank", StringComparison.OrdinalIgnoreCase)), StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < dgvExcluirDetalhes.Rows.Count; i++)
            {
                var payCell = dgvExcluirDetalhes.Rows[i].Cells[15].Value;
                bool hasPay = payCell != null && bool.TryParse(payCell.ToString(), out bool paid) && paid;

                if (hasPay)
                {
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    continue;
                }

                var accountCell = dgvExcluirDetalhes.Rows[i].Cells[2].Value?.ToString();

                if (!string.IsNullOrEmpty(accountCell) && nuBankAccounts.Contains(accountCell))
                {
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    continue;
                }

                if (!string.IsNullOrEmpty(accountCell) && creditCardHashSet.Contains(accountCell))
                {
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    continue;
                }

                dgvExcluirDetalhes.Rows[i].DefaultCellStyle = null;
            }
        }

        private void DgvExcluirDetalhes_SelectionChanged(object sender, EventArgs e)
        {
            decimal valorTotalItensSelecionados = 0;
            decimal valorRestanteItensSelecionados = 0;
            decimal valorRealizadoItensSelecionados = 0;
            int quantidadeTotalItensSelecionados = dgvExcluirDetalhes.SelectedRows.Count;

            foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
            {
                var totalCell = row.Cells[7].Value;
                if (totalCell != null && decimal.TryParse(totalCell.ToString(), out decimal totalValue))
                    valorTotalItensSelecionados += totalValue;

                var remainingCell = row.Cells[5].Value;
                if (remainingCell != null && decimal.TryParse(remainingCell.ToString(), out decimal remainingValue))
                    valorRestanteItensSelecionados += remainingValue;

                var completedCell = row.Cells[6].Value;
                if (completedCell != null && decimal.TryParse(completedCell.ToString(), out decimal completedValue))
                    valorRealizadoItensSelecionados += completedValue;
            }

            lblValorRestanteExibirDetalhesDataGridView.Text = $"Valor restante dos {quantidadeTotalItensSelecionados} itens selecionados: {valorRestanteItensSelecionados:C}";
            lblValorRealizadoExibirDetalhesDataGridView.Text = $"Valor realizado dos {quantidadeTotalItensSelecionados} itens selecionados: {valorRealizadoItensSelecionados:C}";
            lblValorTotalExibirDetalhesDataGridView.Text = $"Valor Total dos: {quantidadeTotalItensSelecionados} itens selecionados: {valorTotalItensSelecionados:C}";
        }

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox
                            .Show("Realmente deseja excluir os registros selecionados?", "Excluir?",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                List<Guid> guidIds = new();

                foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
                {
                    bool isOk = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid guidId);

                    guidIds.Add(guidId);
                }

                if (EH_CONTA_PAGAR)
                {
                    BillToPayServices.Environment = Environment;

                    var output = await BillToPayServices.DeleteBillToPay(MapDeleteBillToPayViewModel(guidIds));

                    TratamentoOutput(output.Output, AccountType.ContaAPagar);
                }
                else
                {
                    CashReceivableServices.Environment = Environment;
                    var output = await CashReceivableServices.DeleteCashReceivable(MapDeleteCashReceivableViewModel(guidIds));
                    TratamentoOutput(output.Output, AccountType.ContaAReceber);
                }
            }
        }

        public static DeleteBillToPayViewModel MapDeleteBillToPayViewModel(List<Guid> guidIds)
        {
            return new DeleteBillToPayViewModel()
            {
                Id = guidIds.ToArray(),
                JustUnpaid = true,
                DisableBillToPayRegistration = false
            };
        }

        public static DeleteCashReceivableViewModel MapDeleteCashReceivableViewModel(List<Guid> guidIds)
        {
            return new DeleteCashReceivableViewModel()
            {
                Id = guidIds.ToArray(),
                OnlyNotReceivable = true,
                DisableCashReceivableRegistration = false
            };
        }

        private async void TratamentoOutput(object result, AccountType accountType)
        {
            var outputDetails = (OutputDetails)result;

            if (outputDetails.Status == OutputStatus.Success)
            {
                MessageBox.Show(outputDetails.Message,
                    "Exclusão de registro realizado com sucesso.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await PreencherCampos();
            }
            else
            {
                await PreencherCampos();

                var information = string.Empty;

                var errors = outputDetails?.Errors;
                var validations = outputDetails?.Validations;

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

                MessageBox.Show(information, "Erro ao tentar deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void TratamentoOutput(DeleteBillToPayOutput result)
        {
            if (result.Output?.Status == OutputStatus.Success)
            {
                MessageBox.Show(result.Output.Message,
                    "Exclusão de registro realizado com sucesso.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await PreencherCampos();
            }
            else
            {
                await PreencherCampos();

                var information = string.Empty;

                var errors = result.Output?.Errors;
                var validations = result.Output?.Validations;

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

                MessageBox.Show(information, "Erro ao tentar cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnShowDetails_Click(object sender, EventArgs e)
        {
            Guid identificador = Guid.NewGuid();

            foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
            {
                bool isOk = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid guidId);

                identificador = guidId;
            }

            // Fix: Cast the object to IList<DgvVisualizarContaPagarDataSource> before using LINQ
            var firstSearch = LastSearch.FirstOrDefault().Value;
            IList<DgvVisualizarContaPagarDataSource>? searchList = firstSearch as IList<DgvVisualizarContaPagarDataSource>;
            var selected = searchList?.FirstOrDefault(x => x.Id == identificador);

            if (selected?.Details?.Count > 0)
            {
                Relacionado frmRegistroRelacionado = new()
                {
                    Environment = Environment,
                    LastSearch = LastSearch,
                    Identificador = identificador
                };

                frmRegistroRelacionado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não foi encontrado nenhum registro relacionado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void EditarRegistroSelecionado_dgvExcluirDetalhes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var rowIndexOld = e.RowIndex;
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                _ = Guid.TryParse(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[0].Value?.ToString(), out Guid guidId);

                if (EH_CONTA_PAGAR)
                {
                    await EditarContaPagar(e, rowIndexOld, guidId);
                }
                else
                {
                    await EditarContaReceber(e, rowIndexOld, guidId);
                }
            }
        }

        private async Task EditarContaPagar(DataGridViewCellMouseEventArgs e, int rowIndexOld, Guid guidId)
        {
            var firstSelectedRow = new EditBillToPayViewModel()
            {
                Id = guidId,
                IdFixedInvoice = Convert.ToInt32(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[1].Value?.ToString()),
                Name = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[3].Value?.ToString(),
                Account = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[2].Value?.ToString(),
                Frequence = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[12].Value?.ToString(),
                RegistrationType = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[13].Value?.ToString(),
                YearMonth = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[11].Value?.ToString(),
                Category = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[4].Value?.ToString(),
                Value = Convert.ToDecimal(RemoveCurrencySymbol(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[7].Value?.ToString())),
                PurchaseDate = DateUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[9].Value?.ToString()),
                PayDay = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[14].Value?.ToString(),
                HasPay = Convert.ToBoolean(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[15].Value?.ToString()),
                DueDate = DateUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[10].Value?.ToString()) ?? DateTime.Now,
                AdditionalMessage = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[16].Value?.ToString(),
                LastChangeDate = DateUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[18].Value?.ToString()) ?? DateTime.Now
            };

            bool editInLote = false;

            List<EditBillToPayViewModel> basketEdits = new();

            if (dgvExcluirDetalhes.SelectedRows.Count > 1)
            {
                editInLote = true;

                foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
                {
                    _ = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid idBillToPay);
                    _ = int.TryParse(row.Cells[1].Value.ToString(), out int registrationId);

                    basketEdits.Add(new EditBillToPayViewModel()
                    {
                        Id = idBillToPay,
                        IdFixedInvoice = registrationId,
                        Name = row.Cells[3].Value?.ToString(),
                        Account = row.Cells[2].Value?.ToString(),
                        Frequence = row.Cells[12].Value?.ToString(),
                        RegistrationType = row.Cells[13].Value?.ToString(),
                        YearMonth = row.Cells[11].Value?.ToString(),
                        Category = row.Cells[4].Value?.ToString(),
                        Value = Convert.ToDecimal(RemoveCurrencySymbol(row.Cells[7].Value?.ToString())),
                        PurchaseDate = DateUtils.GetDateTimeOfString(row.Cells[9].Value?.ToString()),
                        PayDay = row.Cells[14].Value?.ToString(),
                        HasPay = Convert.ToBoolean(row.Cells[15].Value?.ToString()),
                        DueDate = DateUtils.GetDateTimeOfString(row.Cells[10].Value?.ToString()) ?? DateTime.Now,
                        AdditionalMessage = row.Cells[16].Value?.ToString(),
                        LastChangeDate = DateUtils.GetDateTimeOfString(row.Cells[18].Value?.ToString()) ?? DateTime.Now
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

            await CarregamentoTelaAgain();

            dgvExcluirDetalhes.CurrentCell = dgvExcluirDetalhes.Rows[rowIndexOld].Cells[3];
        }

        private async Task EditarContaReceber(DataGridViewCellMouseEventArgs e, int rowIndexOld, Guid guidId)
        {
            var firstSelectedRow = new EditCashReceivableViewModel()
            {
                Id = guidId,
                IdCashReceivableRegistration = Convert.ToInt32(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[1].Value?.ToString()),
                Account = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[2].Value?.ToString(),
                Name = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[3].Value?.ToString(),
                Category = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[4].Value?.ToString(),
                Value = Convert.ToDecimal(RemoveCurrencySymbol(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[5].Value?.ToString())),
                ManipulatedValue = Convert.ToDecimal(RemoveCurrencySymbol(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[6].Value?.ToString())),
                /*7-TotalValue*/
                /*8-DetailsQuantity*/
                AgreementDate = DateUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[9].Value?.ToString()),
                DueDate = DateUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[10].Value?.ToString()) ?? DateTime.Now,
                YearMonth = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[11].Value?.ToString(),
                Frequence = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[12].Value?.ToString(),
                RegistrationType = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[13].Value?.ToString(),
                DateReceived = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[14].Value?.ToString(),
                HasReceived = Convert.ToBoolean(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[15].Value?.ToString()),
                AdditionalMessage = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[16].Value?.ToString(),
                LastChangeDate = DateUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[18].Value?.ToString()) ?? DateTime.Now
            };

            bool editInLote = false;

            List<EditCashReceivableViewModel> basketEdits = new();

            if (dgvExcluirDetalhes.SelectedRows.Count > 1)
            {
                editInLote = true;

                foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
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

            await CarregamentoTelaAgain();

            dgvExcluirDetalhes.CurrentCell = dgvExcluirDetalhes.Rows[rowIndexOld].Cells[3];
        }

        private async void BtnAtualizar_Click(object sender, EventArgs e)
        {
            var rowIndexOld = dgvExcluirDetalhes.CurrentCell.RowIndex;

            await CarregamentoTelaAgain();

            dgvExcluirDetalhes.CurrentCell = dgvExcluirDetalhes.Rows[rowIndexOld].Cells[3];
        }

        private async Task CarregamentoTelaAgain()
        {
            _timesLoading.Clear();
            Stopwatch stopWatchTotal = new();
            _timesLoading.Add("Total", stopWatchTotal);
            stopWatchTotal.Start();

            await PreencherCampos();

            PreencherlblTotaisRegistrosEValores();

            PreecherPrecoMedio();

            PreencherTempoCarregamentoTela(_timesLoading);
        }

        /// <summary>
        /// Retorna o símbolo da moeda baseado na cultura atual
        /// </summary>
        private string GetCurrencySymbol()
        {
            return StringDecimalUtils.CurrentCulture switch
            {
                "pt-BR" => "R$",
                "es-ES" => "€",
                "en-US" => "$",
                "de-DE" => "€",
                "fr-FR" => "€",
                _ => "R$"
            };
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
    }
}