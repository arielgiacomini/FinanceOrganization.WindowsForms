using App.Forms.DataSource;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.Forms.Excluir;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Newtonsoft.Json;


namespace App.WindowsForms.Forms.ExcluirDetalhes
{
    public partial class FrmExibirDetalhes : Form
    {
        private const string EH_CARTAO_CREDITO_NAIRA = "Cartão de Crédito Nubank Naíra";
        public DeleteBillToPayViewModel DeleteBillToPayViewModel { get; set; } = new DeleteBillToPayViewModel();
        public SearchBillToPayViewModel PostSearchBillToPayViewModel { get; set; } = new SearchBillToPayViewModel();
        public Dictionary<string, IList<DgvVisualizarContaPagarDataSource>> LastSearch = new();
        private readonly Dictionary<int, DeleteBillToPayViewModel> _deleteBillToPayViewModels = new();
        public string? Environment { get; set; }

        public FrmExibirDetalhes()
        {
            InitializeComponent();
        }

        private async void FrmExcluirDetalhes_Load(object sender, EventArgs e)
        {
            await PreencherCampos();

            PreencherlblTotaisRegistrosEValores();

            PreecherPrecoMedio();
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

            string descricaoConta = dgvExcluirDetalhes.Rows[dgvExcluirDetalhes.Rows.GetFirstRow(DataGridViewElementStates.Selected)].Cells[3].Value?.ToString() ?? string.Empty;

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

            var dataSourceOrderBy = dataSource
                .OrderBy(dueDate => dueDate.DueDate)
                .ToList();

            PreecherDataGridViewExcluirDetalhes(dataSourceOrderBy);
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
            SetColor();
        }

        private void SetColor()
        {
            foreach (DataGridViewRow row in dgvExcluirDetalhes.Rows)
            {
                Console.WriteLine($"Está na linha de indice [{row.Index}] com o valor de Mes/Ano [{row.Cells[8].Value}]");
                if (IsPaid(row))
                {
                    SetColorRows(row, Color.DarkGreen, Color.White);
                }
                else
                {
                    SetColorRows(row, Color.Transparent, Color.Black);
                }
            }
        }

        private static bool IsPaid(DataGridViewRow row)
        {
            return Convert.ToBoolean(row.Cells[15].Value);
        }

        private static void SetColorRows(DataGridViewRow row, Color backColor, Color foreColor)
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
                bool isOk = decimal.TryParse(row.Cells[5].Value.ToString(), out decimal valor);

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
    }
}