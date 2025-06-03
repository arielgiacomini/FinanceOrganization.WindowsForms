using App.Forms.DataSource;
using App.Forms.Forms.Edição;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.Entities;
using App.WindowsForms.Forms.Excluir;
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
        public EditBillToPayViewModel EditBillToPayViewModel { get; set; } = new EditBillToPayViewModel();
        public Dictionary<string, IList<DgvVisualizarContaPagarDataSource>> LastSearch = new();
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

        public FrmExibirDetalhes()
        {
            InitializeComponent();
        }

        private async void FrmExcluirDetalhes_Load(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new();
            stopWatch.Start();

            await PreencherCampos();

            PreencherlblTotaisRegistrosEValores();

            PreecherPrecoMedio();

            PreencherTempoCarregamentoTela(stopWatch);
        }

        private void PreencherTempoCarregamentoTela(Stopwatch stopWatch)
        {
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = string
                .Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            lblRunTimeLoad.Text = string.Concat("Tempo de Carregamento dos dados desta tela: ", elapsedTime);
        }

        private void PreecherPrecoMedio()
        {
            decimal valorTotalItens = 0;
            int quantidadeItensPagos = 0;

            foreach (DataGridViewRow row in dgvExcluirDetalhes.Rows)
            {
                bool isOkValue = decimal.TryParse(row.Cells[7].Value.ToString(), out decimal valor);
                bool isOkPay = bool.TryParse(row.Cells[15].Value.ToString(), out bool hasPay);


                valorTotalItens += isOkValue && hasPay ? valor : 0;
                quantidadeItensPagos += isOkPay & hasPay ? 1 : 0;
            }

            string descricaoConta = dgvExcluirDetalhes
                .Rows[dgvExcluirDetalhes
                .Rows.GetFirstRow(DataGridViewElementStates.Selected)]
                .Cells[3].Value?.ToString() ?? string.Empty;

            decimal avgPrice = 0;
            if (quantidadeItensPagos > 0)
            {
                avgPrice = valorTotalItens / quantidadeItensPagos;
            }

            lblValorMedioOnlyPagos.Text = string
                .Concat($"[{descricaoConta}] - ", "Valor Médio: ", avgPrice.ToString("C"));
        }

        private void PreencherlblTotaisRegistrosEValores()
        {
            decimal valorTotalItens = 0;
            int quantidadeTotalItens = dgvExcluirDetalhes.RowCount;

            foreach (DataGridViewRow row in dgvExcluirDetalhes.Rows)
            {
                bool isOk = decimal.TryParse(row.Cells[7].Value.ToString(), out decimal valor);

                valorTotalItens += isOk ? valor : 0;
            }

            lblTotaisRegistrosEValores.Text = string
                .Concat("Totais de Registro(s): ", quantidadeTotalItens, " - ", valorTotalItens.ToString("C"));
        }

        private async Task PreencherCampos()
        {
            LastSearch.Clear();

            var resultSearch = await BillToPayServices.SearchBillToPay(PostSearchBillToPayViewModel);

            var dataSource = MapSearchResultToDataSource(resultSearch);

            LastSearch.Add(DateTime.Now.ToString(), dataSource);

            IList<DgvVisualizarContaPagarDataSource> all = OrderingRule(dataSource);

            PreecherDataGridViewExcluirDetalhes(all);
        }

        private static IList<DgvVisualizarContaPagarDataSource> OrderingRule(IList<DgvVisualizarContaPagarDataSource> dataSource)
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

        private static bool FewRecords(IList<DgvVisualizarContaPagarDataSource> dataSource)
        {
            return dataSource.Count <= 18;
        }

        private void PreecherDataGridViewExcluirDetalhes(IList<DgvVisualizarContaPagarDataSource> dataSourceOrderBy)
        {
            dgvExcluirDetalhes.DataSource = dataSourceOrderBy;
            dgvExcluirDetalhes.Columns[0].HeaderText = "Id";
            dgvExcluirDetalhes.Columns[0].Visible = false;
            dgvExcluirDetalhes.Columns[1].HeaderText = "Id da tabela pai";
            dgvExcluirDetalhes.Columns[1].Visible = false;
            dgvExcluirDetalhes.Columns[2].HeaderText = "Conta";
            dgvExcluirDetalhes.Columns[3].HeaderText = "Descrição";
            dgvExcluirDetalhes.Columns[4].HeaderText = "Categoria";
            dgvExcluirDetalhes.Columns[5].HeaderText = "R$ Restante";
            dgvExcluirDetalhes.Columns[5].DefaultCellStyle.Format = "C2";
            dgvExcluirDetalhes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExcluirDetalhes.Columns[6].HeaderText = "R$ Realizado";
            dgvExcluirDetalhes.Columns[6].DefaultCellStyle.Format = "C2";
            dgvExcluirDetalhes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExcluirDetalhes.Columns[7].HeaderText = "R$ Total";
            dgvExcluirDetalhes.Columns[7].DefaultCellStyle.Format = "C2";
            dgvExcluirDetalhes.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExcluirDetalhes.Columns[8].HeaderText = "Qtd Compras";
            dgvExcluirDetalhes.Columns[8].ToolTipText = "Quantidade de Compras relacionadas a este item...";
            dgvExcluirDetalhes.Columns[9].HeaderText = "Data de Compra";
            dgvExcluirDetalhes.Columns[10].HeaderText = "Vencimento";
            dgvExcluirDetalhes.Columns[11].HeaderText = "Mês/Ano";
            dgvExcluirDetalhes.Columns[12].HeaderText = "Frequência";
            dgvExcluirDetalhes.Columns[13].HeaderText = "Tipo";
            dgvExcluirDetalhes.Columns[14].HeaderText = "Data de Pagamento";
            dgvExcluirDetalhes.Columns[15].HeaderText = "Pago?";
            dgvExcluirDetalhes.Columns[16].HeaderText = "Mensagem";
            dgvExcluirDetalhes.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvExcluirDetalhes.Columns[17].HeaderText = "Data de Criação";
            dgvExcluirDetalhes.Columns[17].Visible = false;
            dgvExcluirDetalhes.Columns[18].HeaderText = "Data de Alteração";
            dgvExcluirDetalhes.Columns[18].Visible = false;
            dgvExcluirDetalhes.Columns[19].Visible = false;
        }

        private static IList<DgvVisualizarContaPagarDataSource> MapSearchResultToDataSource(SearchBillToPayOutput searchBillToPayOutput)
        {
            IList<DgvVisualizarContaPagarDataSource> dgvEfetuarPagamentoListagemDataSources = new List<DgvVisualizarContaPagarDataSource>();

            if (searchBillToPayOutput.Output == null || searchBillToPayOutput.Output.Data == null)
            {
                return dgvEfetuarPagamentoListagemDataSources;
            }

            var dados = searchBillToPayOutput.Output.Data;

            var json = JsonConvert.SerializeObject(dados);

            var conversion = JsonConvert.DeserializeObject<IList<DgvVisualizarContaPagarDataSource>>(json);

            foreach (var item in conversion!)
            {
                dgvEfetuarPagamentoListagemDataSources.Add(item);
            }

            return dgvEfetuarPagamentoListagemDataSources;
        }

        private void DgvExcluirDetalhes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Collor();
        }

        private void Collor()
        {
            for (int i = 0; i < dgvExcluirDetalhes.Rows.Count; i++)
            {
                var hasPay = Convert.ToBoolean(dgvExcluirDetalhes.Rows[i].Cells[15].Value?.ToString());

                if (hasPay)
                {
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                    continue;
                }

                var creditCardNotPay = (_listCreditCard?.Contains(dgvExcluirDetalhes?.Rows[i]?.Cells[2].Value?.ToString()) ?? false)
                    && !hasPay;

                if (creditCardNotPay)
                {
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                    continue;
                }

                //TODO: MUDAREMOS OS REGISTROS PASSADOS, OU SEJA, O QUE ESTÁ DEFINIDO COMO CARTÃO DE CRÉDITO APENAS SERÁ FEITO UPDATE PARA CARTÃO DE CRÉDITO NUBANK
                var nubank = _listCreditCard?.Where(x => x.Contains("Nubank")).ToList();
                //TODO: DEFINIR CORES VIA CONFIGURAÇÃO, DEIXAR NO BANCO DE DADOS
                if (nubank != null && nubank.Contains(dgvExcluirDetalhes?.Rows[i]?.Cells[2].Value?.ToString()))
                {
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;
                    dgvExcluirDetalhes.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                    continue;
                }

                dgvExcluirDetalhes.Rows[i].DefaultCellStyle = null;
            }
        }

        private void SetColorRows(DataGridViewRow row, Color backColor, Color foreColor)
        {
            var columnsCount = row.Cells.Count;

            for (int i = 0; i < columnsCount; i++)
            {
                row.Cells[i].Style.BackColor = backColor;
                row.Cells[i].Style.ForeColor = foreColor;
            }
        }

        private void DgvExcluirDetalhes_SelectionChanged(object sender, EventArgs e)
        {
            decimal valorTotalItensSelecionados = 0;
            int quantidadeTotalItensSelecionados = dgvExcluirDetalhes.SelectedRows.Count;

            foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
            {
                bool isOk = decimal.TryParse(row.Cells[7].Value.ToString(), out decimal valor);

                valorTotalItensSelecionados += isOk ? valor : 0;
            }

            lblExcluirDetalhesItensSelecionadosDataGridView.Text = string
                .Concat("Itens selecionados: ", quantidadeTotalItensSelecionados, " - ", valorTotalItensSelecionados.ToString("C"));
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

                BillToPayServices.Environment = Environment;
                var output = await BillToPayServices.DeleteBillToPay(MapDeleteViewModel(guidIds));

                TratamentoOutput(output);
            }
        }

        public static DeleteBillToPayViewModel MapDeleteViewModel(List<Guid> guidIds)
        {
            return new DeleteBillToPayViewModel()
            {
                Id = guidIds.ToArray(),
                JustUnpaid = true,
                DisableFixedInvoice = false
            };
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

            var selected = LastSearch.FirstOrDefault().Value.FirstOrDefault(x => x.Id == identificador);

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
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                _ = Guid.TryParse(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[0].Value?.ToString(), out Guid guidId);

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
                    Value = Convert.ToDecimal(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[7].Value?.ToString().Replace("R$ ", "")),
                    PurchaseDate = DateServiceUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[9].Value?.ToString()),
                    PayDay = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[14].Value?.ToString(),
                    HasPay = Convert.ToBoolean(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[15].Value?.ToString()),
                    DueDate = DateServiceUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[10].Value?.ToString()) ?? DateTime.Now,
                    AdditionalMessage = dgvExcluirDetalhes.Rows[e.RowIndex].Cells[16].Value?.ToString(),
                    LastChangeDate = DateServiceUtils.GetDateTimeOfString(dgvExcluirDetalhes.Rows[e.RowIndex].Cells[18].Value?.ToString()) ?? DateTime.Now
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
                            Value = Convert.ToDecimal(row.Cells[7].Value?.ToString().Replace("R$ ", "")),
                            PurchaseDate = DateServiceUtils.GetDateTimeOfString(row.Cells[9].Value?.ToString()),
                            PayDay = row.Cells[14].Value?.ToString(),
                            HasPay = Convert.ToBoolean(row.Cells[15].Value?.ToString()),
                            DueDate = DateServiceUtils.GetDateTimeOfString(row.Cells[10].Value?.ToString()) ?? DateTime.Now,
                            AdditionalMessage = row.Cells[16].Value?.ToString(),
                            LastChangeDate = DateServiceUtils.GetDateTimeOfString(row.Cells[18].Value?.ToString()) ?? DateTime.Now
                        });
                    }
                }

                FrmEdit frmEditInLote = new()
                {
                    EditBillToPayViewModel = firstSelectedRow,
                    BasketEditBillToPayViewModel = basketEdits,
                    Environment = Environment,
                    EditInLote = editInLote
                };

                frmEditInLote.ShowDialog();
            }
        }
    }
}