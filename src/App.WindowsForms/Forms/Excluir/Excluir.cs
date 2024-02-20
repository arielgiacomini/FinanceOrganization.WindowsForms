using App.Forms.DataSource;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.ViewModel;
using Domain.Entities;
using Newtonsoft.Json;

namespace App.WindowsForms.Forms.ExcluirDetalhes
{
    public partial class FrmExibirDetalhes : Form
    {
        private const string EH_CARTAO_CREDITO_NAIRA = "Cartão de Crédito Nubank Naíra";
        public DeleteBillToPayViewModel DeleteBillToPayViewModel { get; set; } = new DeleteBillToPayViewModel();
        public SearchBillToPayViewModel SearchBillToPayViewModel { get; set; } = new SearchBillToPayViewModel();
        public string? Environment { get; set; }

        public FrmExibirDetalhes()
        {
            InitializeComponent();
        }

        private async void FrmExcluirDetalhes_Load(object sender, EventArgs e)
        {
            await PreencherCampos();
        }

        private async Task PreencherCampos()
        {
            var resultSearch = await BillToPayServices.SearchBillToPay(SearchBillToPayViewModel);

            var dataSource = MapSearchResultToDataSource(resultSearch);

            var dataSourceOrderBy = dataSource
                .OrderBy(dueDate => dueDate.DueDate)
                .ToList();

            PreecherDataGridViewExcluirDetalhes(dataSourceOrderBy);
        }

        private void PreecherDataGridViewExcluirDetalhes(IList<DgvEfetuarPagamentoListagemDataSource> dataSourceOrderBy)
        {
            dgvExcluirDetalhes.DataSource = dataSourceOrderBy;
            dgvExcluirDetalhes.Columns[0].HeaderText = "Id";
            dgvExcluirDetalhes.Columns[0].Visible = false;
            dgvExcluirDetalhes.Columns[1].HeaderText = "Id da tabela pai";
            dgvExcluirDetalhes.Columns[1].Visible = false;
            dgvExcluirDetalhes.Columns[2].HeaderText = "Conta";
            dgvExcluirDetalhes.Columns[3].HeaderText = "Descrição";
            dgvExcluirDetalhes.Columns[4].HeaderText = "Categoria";
            dgvExcluirDetalhes.Columns[5].HeaderText = "Valor";
            dgvExcluirDetalhes.Columns[5].DefaultCellStyle.Format = "C2";
            dgvExcluirDetalhes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExcluirDetalhes.Columns[6].HeaderText = "Data de Compra";
            dgvExcluirDetalhes.Columns[7].HeaderText = "Vencimento";
            dgvExcluirDetalhes.Columns[8].HeaderText = "Mês/Ano";
            dgvExcluirDetalhes.Columns[9].HeaderText = "Frequência";
            dgvExcluirDetalhes.Columns[10].HeaderText = "Tipo";
            dgvExcluirDetalhes.Columns[11].HeaderText = "Data de Pagamento";
            dgvExcluirDetalhes.Columns[12].HeaderText = "Pago?";
            dgvExcluirDetalhes.Columns[13].HeaderText = "Mensagem";
            dgvExcluirDetalhes.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvExcluirDetalhes.Columns[14].HeaderText = "Data de Criação";
            dgvExcluirDetalhes.Columns[14].Visible = false;
            dgvExcluirDetalhes.Columns[15].HeaderText = "Data de Alteração";
            dgvExcluirDetalhes.Columns[15].Visible = false;
        }

        private static IList<DgvEfetuarPagamentoListagemDataSource> MapSearchResultToDataSource(SearchBillToPayOutput searchBillToPayOutput)
        {
            IList<DgvEfetuarPagamentoListagemDataSource> dgvEfetuarPagamentoListagemDataSources = new List<DgvEfetuarPagamentoListagemDataSource>();

            if (searchBillToPayOutput.Output == null || searchBillToPayOutput.Output.Data == null)
            {
                return dgvEfetuarPagamentoListagemDataSources;
            }

            var dados = searchBillToPayOutput.Output.Data;

            var json = JsonConvert.SerializeObject(dados);

            var conversion = JsonConvert.DeserializeObject<IList<DgvEfetuarPagamentoListagemDataSource>>(json);

            foreach (var item in conversion!)
            {
                dgvEfetuarPagamentoListagemDataSources.Add(item);
            }

            return dgvEfetuarPagamentoListagemDataSources;
        }

        private void DgvExcluirDetalhes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvExcluirDetalhes.Rows)
            {
                if (Convert.ToBoolean(row.Cells[12].Value))
                {
                    SetColorRows(row, Color.DarkGreen, Color.White);
                }

                if (row.Cells[2].Value.ToString() == Account.CARTAO_CREDITO && !Convert.ToBoolean(row.Cells[12].Value))
                {
                    SetColorRows(row, Color.DarkOrange, Color.Black);
                }

                if (!string.IsNullOrWhiteSpace(row.Cells[13].Value?.ToString())
                    && row.Cells[13].Value.ToString()!.StartsWith(EH_CARTAO_CREDITO_NAIRA))
                {
                    SetColorRows(row, Color.DimGray, Color.White);
                }
            }
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

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox
                .Show("Realmente deseja excluir os registros selecionados?", "Excluir?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvExcluirDetalhes.SelectedRows)
                {
                    bool isOk = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid id);

                    
                }
            }
        }
    }
}