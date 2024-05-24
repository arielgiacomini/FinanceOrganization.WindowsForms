using App.Forms.DataSource;

namespace App.WindowsForms.Forms.Excluir
{
    public partial class Relacionado : Form
    {
        public string? Environment { get; set; }
        public Dictionary<string, IList<DgvEfetuarPagamentoListagemDataSource>> LastSearch = new();
        public Guid Identificador;

        public Relacionado()
        {
            InitializeComponent();
        }

        private void FrmRegistroRelacionado_Load(object sender, EventArgs e)
        {
            var lastSearch = LastSearch
                .FirstOrDefault().Value
                .Where(x => x.Id == Identificador)
                .Select(show => show.Details!.ToList())
                .FirstOrDefault()
                .OrderBy(order => order.PurchaseDate)
                .ToList();

            if (lastSearch != null)
            {
                PreecherDataGridViewExcluirDetalhes(lastSearch);

                PreecherPrecoMedio();

                lblInformacoesTotais.Text = string
                        .Concat("Itens Totais: ",
                            lastSearch.Count, " - ",
                            lastSearch.Select(x => x.Value).Sum().ToString("C"));
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
                bool isOk = decimal.TryParse(row.Cells[5].Value.ToString(), out decimal valor);

                valorTotalItensSelecionados += isOk ? valor : 0;
            }

            decimal avgPrice = 0;
            if (quantidadeTotalItensSelecionados > 0)
            {
                avgPrice = valorTotalItensSelecionados / quantidadeTotalItensSelecionados;
            }

            lblValorTotalMedioSelecionados.Text = string
                    .Concat("Valor Médio Apenas Selecionados: ", avgPrice.ToString("C"));

            lblRegistrosSelecionados.Text = string
                .Concat("Itens selecionados: ", quantidadeTotalItensSelecionados, " - ", valorTotalItensSelecionados.ToString("C"));
        }
    }
}