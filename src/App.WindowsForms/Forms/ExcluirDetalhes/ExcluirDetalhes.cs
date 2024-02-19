using App.Forms.DataSource;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.ViewModel;
using Domain.Entities;
using Newtonsoft.Json;

namespace App.WindowsForms.Forms.ExcluirDetalhes
{
    public partial class FrmExcluirDetalhes : Form
    {
        public DeleteBillToPayViewModel DeleteBillToPayViewModel { get; set; } = new DeleteBillToPayViewModel();
        public SearchBillToPayViewModel SearchBillToPayViewModel { get; set; } = new SearchBillToPayViewModel();
        public string? Environment { get; set; }

        public FrmExcluirDetalhes()
        {
            InitializeComponent();
        }

        private async void FrmExcluirDetalhes_Load(object sender, EventArgs e)
        {
            await PreencherCampos();
        }

        private async Task PreencherCampos()
        {
            var resultSearch = await SearchBillToPay(SearchBillToPayViewModel);

            var dataSource = MapSearchResultToDataSource(resultSearch);

            var dataSourceOrderBy = dataSource
                .OrderBy(hasPay => hasPay.HasPay)
                .ThenBy(creditCard => creditCard.Account == Account.CARTAO_CREDITO)
                .ThenBy(dueDate => dueDate.DueDate)
                .ThenByDescending(purchase => purchase.PurchaseDate)
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

        private async Task<SearchBillToPayOutput> SearchBillToPay(SearchBillToPayViewModel searchBillToPayViewModel)
        {
            var result = await BillToPayServices.SearchBillToPay(searchBillToPayViewModel);

            return result;
        }
    }
}