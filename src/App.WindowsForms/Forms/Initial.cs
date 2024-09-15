using App.Forms.Config;
using App.Forms.DataSource;
using App.Forms.Enums;
using App.Forms.Forms.Edição;
using App.Forms.Forms.Pay;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.DataSource;
using App.WindowsForms.Forms.ExcluirDetalhes;
using App.WindowsForms.Services;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Domain.Entities;
using Domain.Utils;
using Newtonsoft.Json;
using System.Data;

namespace App.Forms.Forms
{
    public partial class Initial : Form
    {
        private const string TAB_PAGE_CONTA_PAGAR_CADASTRO = "tbpContaPagarLivre";
        private const string TAB_PAGE_VISUALIZAR_CONTA_PAGAR = "tbpEfetuarPagamento";
        private const string TAB_PAGE_ESTUDO_FINANCEIRO = "tbpEstudosFinanceiros";
        private const string DESCRICAO_GROUP_BOX = "Cadastro de Conta a Pagar";
        private const string EH_CARTAO_CREDITO_NAIRA = "Cartão de Crédito Nubank Naíra: ";
        private readonly Dictionary<int, CreateBillToPayViewModel> _createBillToPayViewModels = new();
        private IList<DgvVisualizarContaPagarDataSource> _dgvEfetuarPagamentoListagemDataSource = new List<DgvVisualizarContaPagarDataSource>();
        private IList<DgvVisualizarEstudoFinanceiroDataSource> _dgvVisuarEstudoFinanceiroDataSource = new List<DgvVisualizarEstudoFinanceiroDataSource>();

        public static int CurrentIndex { get; set; } = 0;
        public decimal ValorContaPagarDigitadoTextBox { get; set; } = 0;
        public int Identifier { get; set; } = 0;
        public InfoHeader InfoHeader { get; set; } = new InfoHeader();
        public string? Environment { get; set; }

        public Initial(InfoHeader? infoHeader)
        {
            if (infoHeader != null)
            {
                InfoHeader = infoHeader;
                Environment = infoHeader.Environment;
            }

            InitializeComponent();
        }

        private async void Initial_Load(object sender, EventArgs e)
        {
            lblVersion.Text = InfoHeader.Version;
            lblInfoHeader.Text = AdjusteInfoHeader();
            PreencherLabelDataCriacao();
            await PreencherComboBoxContaPagarCategoriaAsync();
            PreencherComboBoxContaPagarTipoConta();
            PreencherComboBoxAnoMes();
            PreencherComboBoxEstudoFinanceiroQuantideMeses();
            RegraCamposAnoMes();
            CampoValor();
            TabPageIndexOne();
            PreencherContaPagarMelhorDiaPagamento();
            PreencherContaPagarFrequencia();
            PreencherContaPagarTipoCadastro();
            await BuscarListaPagamentos();
            await SearchMonthlyAverageAnalysis();
            tbcInitial.SelectedTab = tbcInitial.TabPages[0];
            ToolTip tooltipBtnPagamentoAvulso = new();
            tooltipBtnPagamentoAvulso.SetToolTip(this.btnPagamentoAvulso, "Ideal p/ Pagamento em Massa, Ex.: Cartão de Crédito");
            SetColorGrbTemplateContaPagar();
        }

        private string AdjusteInfoHeader(DateTime? lastUpdate = null)
        {
            string? lblInfoHeaderIntern;

            if (InfoHeader.IsProductionEnvironment || InfoHeader.Environment == "Produção")
            {
                lblInfoHeader.BackColor = Color.OrangeRed;
                lblInfoHeader.ForeColor = Color.White;
                lblVersion.BackColor = Color.OrangeRed;
                lblVersion.ForeColor = Color.White;
                rdbAmbienteLocal.BackColor = Color.OrangeRed;
                rdbAmbienteLocal.ForeColor = Color.White;
                rdbAmbienteHomologacao.BackColor = Color.OrangeRed;
                rdbAmbienteHomologacao.ForeColor = Color.White;
                rdbAmbienteProducao.BackColor = Color.OrangeRed;
                rdbAmbienteProducao.ForeColor = Color.White;
                lblInfoHeaderIntern = string.Concat("CFM - PRODUÇÃO", " - ", InfoHeader.Url, " - ", "Última Busca: ", lastUpdate ?? DateTime.Now);
            }
            else if (!InfoHeader.IsProductionEnvironment && InfoHeader.Environment == "Homologação")
            {
                var colorDarkGreen = Color.DarkGreen;
                lblInfoHeader.BackColor = colorDarkGreen;
                lblInfoHeader.ForeColor = Color.White;
                lblVersion.BackColor = colorDarkGreen;
                lblVersion.ForeColor = Color.White;
                rdbAmbienteLocal.BackColor = colorDarkGreen;
                rdbAmbienteLocal.ForeColor = Color.White;
                rdbAmbienteHomologacao.BackColor = colorDarkGreen;
                rdbAmbienteHomologacao.ForeColor = Color.White;
                rdbAmbienteProducao.BackColor = colorDarkGreen;
                rdbAmbienteProducao.ForeColor = Color.White;
                lblInfoHeaderIntern = string.Concat("CFM - HOMOLOGAÇÃO", " - ", InfoHeader.Url, " - ", "Última Busca: ", lastUpdate ?? DateTime.Now);
            }
            else if (!InfoHeader.IsProductionEnvironment && InfoHeader.Environment == "Local")
            {
                lblInfoHeader.BackColor = Color.DarkGray;
                lblInfoHeader.ForeColor = Color.White;
                lblVersion.BackColor = Color.DarkGray;
                lblVersion.ForeColor = Color.White;
                rdbAmbienteLocal.BackColor = Color.DarkGray;
                rdbAmbienteLocal.ForeColor = Color.White;
                rdbAmbienteHomologacao.BackColor = Color.DarkGray;
                rdbAmbienteHomologacao.ForeColor = Color.White;
                rdbAmbienteProducao.BackColor = Color.DarkGray;
                rdbAmbienteProducao.ForeColor = Color.White;
                lblInfoHeaderIntern = string.Concat("CFM - LOCAL", " - ", InfoHeader.Url, " - ", "Última Busca: ", lastUpdate ?? DateTime.Now);
            }
            else
            {
                lblInfoHeaderIntern = "ERRO!";
            }

            return lblInfoHeaderIntern;
        }

        private async void BtnContaPagarCadastrar_Click(object sender, EventArgs e)
        {
            Identifier++;

            var createBillToPay = new CreateBillToPayViewModel
            {
                Name = txtContaPagarNameDescription.Text,
                Account = cboContaPagarTipoConta.Text,
                Frequence = cboContaPagarFrequencia.Text,
                RegistrationType = cboContaPagarTipoCadastro.Text,
                InitialMonthYear = cboContaPagarAnoMesInicial.Text,
                FynallyMonthYear = !cboNaoEnviarMesAnoFinal.Checked ? cboContaPagarAnoMesFinal.Text : null,
                Category = cboContaPagarCategory.Text,
                Value = Convert.ToDecimal(txtContaPagarValor.Text.Replace("R$ ", "")),
                PurchaseDate = cboHabilitarDataCompra.Checked ? DateServiceUtils.GetDateTimeOfString(dtpContaPagarDataCompra.Text) : null,
                BestPayDay = Convert.ToInt32(cboContaPagarMelhorDiaPagamento.Text),
                AdditionalMessage = rtbContaPagarMensagemAdicional.Text,
                CreationDate = DateTime.Now,
                LastChangeDate = null,
                Status = RegistrationStatus.AwaitRequestAPI
            };

            _createBillToPayViewModels.Add(Identifier, createBillToPay);

            UpdateDataGridView();

            BillToPayServices.Environment = Environment;
            var result = await BillToPayServices.CreateBillToPay(createBillToPay);

            _createBillToPayViewModels[Identifier].Status = RegistrationStatus.AwaitResponseAPI;

            UpdateDataGridView();

            TratamentoOutput(Identifier, result);
        }

        private void TratamentoOutput(int identifier, CreateBillToPayOutput result)
        {
            if (result.Output.Status == OutputStatus.Success)
            {
                MessageBox.Show(result.Output.Message,
                    "Cadastro de Conta a Pagar Realizado com Sucesso.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _createBillToPayViewModels[identifier].Status = RegistrationStatus.Created;
                UpdateDataGridView();
            }
            else
            {
                _createBillToPayViewModels[identifier].Status = RegistrationStatus.RegistrationError;
                UpdateDataGridView();

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

        private void UpdateDataGridView()
        {
            dgvContaPagar.DataSource = MapCreateBillToPayViewModelToDataSource(_createBillToPayViewModels);
            dgvContaPagar.Columns[0].HeaderText = "Descrição";
            dgvContaPagar.Columns[1].HeaderText = "Conta";
            dgvContaPagar.Columns[2].HeaderText = "Frequência";
            dgvContaPagar.Columns[3].HeaderText = "Tipo";
            dgvContaPagar.Columns[4].HeaderText = "Inicial";
            dgvContaPagar.Columns[5].HeaderText = "Final";
            dgvContaPagar.Columns[6].HeaderText = "Categoria";
            dgvContaPagar.Columns[7].HeaderText = "Valor";
            dgvContaPagar.Columns[8].HeaderText = "Data de Compra";
            dgvContaPagar.Columns[9].HeaderText = "Melhor Dia";
            dgvContaPagar.Columns[10].HeaderText = "Mensagem";
            dgvContaPagar.Columns[11].HeaderText = "Status";
        }

        private static IList<DgvContaPagarDataSource> MapCreateBillToPayViewModelToDataSource(Dictionary<int, CreateBillToPayViewModel> billToPayViewModel)
        {
            IList<DgvContaPagarDataSource> list = new List<DgvContaPagarDataSource>();
            foreach (var item in billToPayViewModel.Values)
            {
                var dgvContaPagarDataSource = new DgvContaPagarDataSource()
                {
                    Name = item.Name,
                    Account = item.Account,
                    Frequence = item.Frequence,
                    RegistrationType = item.RegistrationType,
                    InitialMonthYear = item.InitialMonthYear,
                    FynallyMonthYear = item.FynallyMonthYear,
                    Category = item.Category,
                    Value = item.Value,
                    PurchaseDate = item.PurchaseDate,
                    BestPayDay = item.BestPayDay,
                    AdditionalMessage = item.AdditionalMessage,
                    Status = item.Status.ToString()
                };

                list.Add(dgvContaPagarDataSource);
            }

            return list;
        }

        private void PreencherLabelDataCriacao()
        {
            string texto = "Data de Criação: ";
            lblContaPagarDataCriacao.Text = string.Concat(texto, DateTime.Now);
        }

        private async Task PreencherComboBoxContaPagarCategoriaAsync(string tabPageName = null, string categorySelected = null)
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
            cboEfetuarPagamentoCategoria.Items.Add(first.Value);

            foreach (var item in categoriasContaPagarOrderBy)
            {
                cboContaPagarCategory.Items.Add(item.Value);
                cboEfetuarPagamentoCategoria.Items.Add(item.Value);
            }

            if (categorySelected == null)
            {
                cboContaPagarCategory.SelectedItem = first.Value;
                cboEfetuarPagamentoCategoria.SelectedItem = first.Value;
            }
            else
            {
                var theChoise = categoriasContaPagarOrderBy
                    .FirstOrDefault(x => x.Value == categorySelected);

                if (theChoise.Value.Length > 0)
                {
                    cboContaPagarCategory.SelectedItem = theChoise.Value;
                    cboEfetuarPagamentoCategoria.SelectedItem = theChoise.Value;
                }
                else
                {
                    var dado = categoriasContaPagarOrderBy
                        .FirstOrDefault().Value;

                    cboContaPagarCategory.SelectedItem = dado;
                    cboEfetuarPagamentoCategoria.SelectedItem = dado;
                }
            }
        }

        private void PreencherComboBoxContaPagarTipoConta(string tabPageName = null, string accountSelected = null)
        {
            Dictionary<int, string> tipoConta = new()
            {
                { 1, "Cartão de Crédito" },
                { 2, "Cartão de Débito" },
                { 3, "Cartão VA" },
                { 4, "Cartão VR" },
                { 5, "Itaú" }
            };

            foreach (var item in tipoConta)
            {
                cboContaPagarTipoConta.Items.Add(item.Value);
            }

            if (accountSelected == null)
            {
                cboContaPagarTipoConta.SelectedItem = tipoConta.FirstOrDefault().Value;
            }
            else
            {
                var theChoise = tipoConta.FirstOrDefault(x => x.Value == accountSelected);

                if (theChoise.Value.Length > 0)
                {
                    cboContaPagarTipoConta.SelectedItem = theChoise.Value;
                }
                else
                {
                    cboContaPagarTipoConta.SelectedItem = tipoConta.FirstOrDefault().Value;
                }
            }
        }

        private void PreencherComboBoxAnoMes()
        {
            var yearMonths = DateServiceUtils.GetListYearMonthsByThreeMonthsBeforeAndTwentyFourAfter();
            var yearMonthsArray = yearMonths.Values.ToArray();

            cboContaPagarAnoMesInicial.Items.AddRange(yearMonthsArray);
            cboEfetuarPagamentoAnoMes.Items.AddRange(yearMonthsArray);

            var dateTimeNow = DateTime.Now;
            DateTime actual = new(dateTimeNow.Year, dateTimeNow.Month, 1);
            _ = yearMonths.TryGetValue(actual, out string? currentYearMonth);

            cboContaPagarAnoMesInicial.SelectedItem = currentYearMonth;
            cboEfetuarPagamentoAnoMes.SelectedItem = currentYearMonth;

            PreencherComboBoxcboContaPagarAnoMesFinal();
        }

        private void PreencherComboBoxcboContaPagarAnoMesFinal()
        {
            var yearMonths = DateServiceUtils.GetListYearMonthsByThreeMonthsBeforeAndTwentyFourAfter();

            var yearMonthsArray = yearMonths.Values.ToArray();

            cboContaPagarAnoMesFinal.Items.AddRange(yearMonthsArray);

            var dateTimeNow = DateTime.Now;
            DateTime actual = new(dateTimeNow.Year, dateTimeNow.Month, 1);
            _ = yearMonths.TryGetValue(actual, out string? currentYearMonth);

            cboContaPagarAnoMesFinal.SelectedItem = currentYearMonth;
        }

        private void PreencherContaPagarMelhorDiaPagamento()
        {
            IList<int> bestPayDay = new List<int>();

            for (int day = 1; day <= 31; day++)
            {
                bestPayDay.Add(day);
                cboContaPagarMelhorDiaPagamento.Items.Add(day);
            }

            cboContaPagarMelhorDiaPagamento.SelectedItem = DateTime.Now.Day;
        }

        private void PreencherContaPagarFrequencia(string tabPageName = null, string frequenciaSelected = null)
        {
            Dictionary<int, string> frequencia = new()
            {
                { 1, "Livre" },
                { 2, "Mensal" },
                { 3, "Mensal:Recorrente" }
            };

            foreach (var item in frequencia)
            {
                cboContaPagarFrequencia.Items.Add(item.Value);
            }

            if (frequenciaSelected == null)
            {
                cboContaPagarFrequencia.SelectedItem = frequencia.FirstOrDefault().Value;
            }
            else
            {
                var theChoise = frequencia.FirstOrDefault(x => x.Value == frequenciaSelected);

                if (theChoise.Value.Length > 0)
                {
                    cboContaPagarFrequencia.SelectedItem = theChoise.Value;
                }
                else
                {
                    cboContaPagarFrequencia.SelectedItem = frequencia.FirstOrDefault().Value;
                }
            }
        }

        private void PreencherContaPagarTipoCadastro(string tabPageName = null, string tipoCadastroSelected = null)
        {
            Dictionary<int, string> tipoCadastro = new()
            {
                { 1, "Compra Livre" },
                { 2, "Conta/Fatura Fixa" }
            };

            foreach (var item in tipoCadastro)
            {
                cboContaPagarTipoCadastro.Items.Add(item.Value);
            }

            if (tipoCadastroSelected == null)
            {
                cboContaPagarTipoCadastro.SelectedItem = tipoCadastro.FirstOrDefault().Value;
            }
            else
            {
                var theChoise = tipoCadastro.FirstOrDefault(x => x.Value == tipoCadastroSelected);

                if (theChoise.Value.Length > 0)
                {
                    cboContaPagarTipoCadastro.SelectedItem = theChoise.Value;
                }
                else
                {
                    cboContaPagarTipoCadastro.SelectedItem = tipoCadastro.FirstOrDefault().Value;
                }
            }
        }

        private void CkbContaPagarConsideraMesmoMes_CheckedChanged(object sender, EventArgs e)
        {
            RegraCamposAnoMes();
        }

        private void RegraCamposAnoMes()
        {
            if (ckbContaPagarConsideraMesmoMes.Checked)
            {
                if (cboNaoEnviarMesAnoFinal.Checked)
                {
                    var result = MessageBox
                        .Show("Você enviará o Mês/Ano Final exatamente igual o inicial?",
                        "E aí cara?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        cboContaPagarAnoMesFinal.SelectedItem = cboContaPagarAnoMesInicial.SelectedItem;
                        cboContaPagarAnoMesFinal.Enabled = false;
                        cboNaoEnviarMesAnoFinal.Checked = false;
                    }
                }

                cboContaPagarAnoMesFinal.SelectedItem = cboContaPagarAnoMesInicial.SelectedItem;
                cboContaPagarAnoMesFinal.Enabled = false;
            }
            else
            {
                cboContaPagarAnoMesFinal.Enabled = true;
            }
        }

        private void CampoValor()
        {
            txtContaPagarValor.Text = Convert.ToDecimal("0").ToString("C");
        }

        private void CboContaPagarAnoMesInicial_Leave(object sender, EventArgs e)
        {
            RegraCamposAnoMes();
        }

        private void CboContaPagarAnoMesInicial_SelectedValueChanged(object sender, EventArgs e)
        {
            RegraCamposAnoMes();
        }

        private void TbcInitial_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabPageCurrent = tbcInitial.SelectedTab;
            var tabPageCurrentText = tabPageCurrent.Text;
            switch (tabPageCurrent.Name)
            {
                case TAB_PAGE_CONTA_PAGAR_CADASTRO:
                    SetParameters(tabPageCurrentText, "Alimentação:Café da Manhã", "Cartão de Crédito", "Livre");
                    grbTemplateContaPagar.Text = string.Concat(DESCRICAO_GROUP_BOX, " - ", tabPageCurrentText);
                    break;
                case TAB_PAGE_VISUALIZAR_CONTA_PAGAR:
                    SetParameters(tabPageCurrentText, "Nenhum");
                    break;
                case TAB_PAGE_ESTUDO_FINANCEIRO:
                    SetParameters(tabPageCurrentText, "Nenhum");
                    break;
                default:
                    break;
            }

            if (TabPageCurrentIsFormWithTemplate())
            {
                PreencherLabelDataCriacao();
                tbcInitial.TabPages[tbcInitial.SelectedIndex].Controls.Add(grbTemplateContaPagar);
            }
        }

        private bool TabPageCurrentIsFormWithTemplate()
        {
            return
                   tbcInitial.TabPages[tbcInitial.SelectedIndex].Name == TAB_PAGE_CONTA_PAGAR_CADASTRO;
        }

        private void TabPageIndexOne()
        {
            tbcInitial.TabPages[tbcInitial.SelectedIndex].Controls.Add(grbTemplateContaPagar);
        }

        private void SetParameters(string tabPageName, string? category = null, string? account = null, string? frequencia = null)
        {
            cboContaPagarCategory.Items.Clear();
            cboContaPagarTipoConta.Items.Clear();
            PreencherComboBoxContaPagarCategoriaAsync(tabPageName, category);
            PreencherComboBoxContaPagarTipoConta(tabPageName, account);
        }

        private async void BtnEfetuarPagamentoBuscar_Click(object sender, EventArgs e)
        {
            lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
            await BuscarListaPagamentos();
        }

        public async Task BuscarListaPagamentos()
        {
            _dgvEfetuarPagamentoListagemDataSource.Clear();
            cboEfetuarPagamentoCategoria.SelectedItem = "Nenhum";

            SearchBillToPayViewModel search = new()
            {
                YearMonth = cboEfetuarPagamentoAnoMes.Text
            };

            await PreencherEfetuarPagamentoDataGridViewHistory(search);
        }

        private async Task PreencherEfetuarPagamentoDataGridViewHistory(SearchBillToPayViewModel search)
        {
            BillToPayServices.Environment = Environment;
            var resultSearch = await BillToPayServices.SearchBillToPay(search);

            var dataSource = MapSearchResultToDataSource(resultSearch);

            var dataSourceOrderBy = dataSource
                .OrderBy(hasPay => hasPay.HasPay)
                .ThenBy(creditCard => creditCard.Account == Account.CARTAO_CREDITO)
                .ThenBy(dueDate => dueDate.DueDate)
                .ThenByDescending(purchase => purchase.PurchaseDate)
                .ToList();

            PreecherDataGridViewContaPagarListar(dataSourceOrderBy);
        }

        private void PreecherDataGridViewContaPagarListar(IList<DgvVisualizarContaPagarDataSource> dataSourceOrderBy)
        {
            ConsolidateContaPagarListagem(dataSourceOrderBy);

            _dgvEfetuarPagamentoListagemDataSource = dataSourceOrderBy;

            dgvEfetuarPagamentoListagem.DataSource = dataSourceOrderBy;
            dgvEfetuarPagamentoListagem.Columns[0].HeaderText = "Id";
            dgvEfetuarPagamentoListagem.Columns[0].Visible = false;
            dgvEfetuarPagamentoListagem.Columns[1].HeaderText = "Id da tabela pai";
            dgvEfetuarPagamentoListagem.Columns[1].Visible = false;
            dgvEfetuarPagamentoListagem.Columns[2].HeaderText = "Conta";
            dgvEfetuarPagamentoListagem.Columns[3].HeaderText = "Descrição";
            dgvEfetuarPagamentoListagem.Columns[4].HeaderText = "Categoria";

            dgvEfetuarPagamentoListagem.Columns[5].HeaderText = "R$ Restante";
            dgvEfetuarPagamentoListagem.Columns[5].DefaultCellStyle.Format = "C2";
            dgvEfetuarPagamentoListagem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvEfetuarPagamentoListagem.Columns[6].HeaderText = "R$ Realizado";
            dgvEfetuarPagamentoListagem.Columns[6].DefaultCellStyle.Format = "C2";
            dgvEfetuarPagamentoListagem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvEfetuarPagamentoListagem.Columns[7].HeaderText = "R$ Total";
            dgvEfetuarPagamentoListagem.Columns[7].DefaultCellStyle.Format = "C2";
            dgvEfetuarPagamentoListagem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvEfetuarPagamentoListagem.Columns[8].HeaderText = "Qtd Compras";
            dgvEfetuarPagamentoListagem.Columns[8].ToolTipText = "Quantidade de Compras relacionadas a este item...";
            dgvEfetuarPagamentoListagem.Columns[9].HeaderText = "Data de Compra";
            dgvEfetuarPagamentoListagem.Columns[10].HeaderText = "Vencimento";
            dgvEfetuarPagamentoListagem.Columns[11].HeaderText = "Mês/Ano";
            dgvEfetuarPagamentoListagem.Columns[12].HeaderText = "Frequência";
            dgvEfetuarPagamentoListagem.Columns[13].HeaderText = "Tipo";
            dgvEfetuarPagamentoListagem.Columns[14].HeaderText = "Data de Pagamento";
            dgvEfetuarPagamentoListagem.Columns[15].HeaderText = "Pago?";
            dgvEfetuarPagamentoListagem.Columns[16].HeaderText = "Mensagem";
            dgvEfetuarPagamentoListagem.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEfetuarPagamentoListagem.Columns[17].HeaderText = "Data de Criação";
            dgvEfetuarPagamentoListagem.Columns[17].Visible = false;
            dgvEfetuarPagamentoListagem.Columns[18].HeaderText = "Data de Alteração";
            dgvEfetuarPagamentoListagem.Columns[18].Visible = false;
            dgvEfetuarPagamentoListagem.Columns[19].Visible = false;
        }

        private void ConsolidateContaPagarListagem(IList<DgvVisualizarContaPagarDataSource> dataSourceOrderBy)
        {
            #region TOTAL GERAL

            var quantidadeTotal = dataSourceOrderBy.Count;
            var valorTotal = Convert.ToDecimal(dataSourceOrderBy.Sum(x => x.Value));
            ConsolidatePreencherlblGridViewTotais(quantidadeTotal, valorTotal);

            #endregion TOTAL GERAL

            #region TOTAL PAGO

            var quantidadeTotalPago = dataSourceOrderBy.Count(pay => pay.HasPay);
            var valorTotalPago = Convert.ToDecimal(dataSourceOrderBy
                .Where(pay => pay.HasPay)
                .Sum(x => x.Value));
            ConsolidatePreencherlblGridViewTotalPago(quantidadeTotalPago, valorTotalPago);

            #endregion TOTAL PAGO

            #region CARTÃO DE CRÉDITO FAMÍLIA

            var quantidadeTotalCartaoCreditoFamilia = dataSourceOrderBy
                .Count(creditCardFamily => creditCardFamily.Account == Account.CARTAO_CREDITO
                    && !(creditCardFamily.AdditionalMessage != null
                     && creditCardFamily.AdditionalMessage.ToString().StartsWith(EH_CARTAO_CREDITO_NAIRA)));

            var quantidadeTotalPagoCartaoCreditoFamilia = dataSourceOrderBy
                .Count(creditCardFamily => creditCardFamily.Account == Account.CARTAO_CREDITO
                    && !(creditCardFamily.AdditionalMessage != null
                     && creditCardFamily.AdditionalMessage.ToString().StartsWith(EH_CARTAO_CREDITO_NAIRA))
                     && creditCardFamily.HasPay);

            var valorTotalCartaoCreditoFamilia = Convert
                .ToDecimal(dataSourceOrderBy
                .Where(creditCardFamily => creditCardFamily.Account == Account.CARTAO_CREDITO
                    && !(creditCardFamily.AdditionalMessage != null
                     && creditCardFamily.AdditionalMessage.ToString().StartsWith(EH_CARTAO_CREDITO_NAIRA)))
                .Sum(x => x.Value));
            ConsolidatePreencherlblGridViewCartaoCreditoFamilia(
                quantidadeTotalCartaoCreditoFamilia, valorTotalCartaoCreditoFamilia, quantidadeTotalPagoCartaoCreditoFamilia);

            #endregion CARTÃO DE CRÉDITO FAMÍLIA

            #region CARTÃO DE CRÉDITO NAÍRA

            var quantidadeTotalCartaoCreditoNaira = dataSourceOrderBy
                .Count(creditCardNaira => creditCardNaira.Account == Account.CARTAO_CREDITO
                    && creditCardNaira.AdditionalMessage != null && creditCardNaira.AdditionalMessage.ToString()
                .StartsWith(EH_CARTAO_CREDITO_NAIRA));

            var quantidadeTotalPagoCartaoCreditoNaira = dataSourceOrderBy
                .Count(creditCardNaira => creditCardNaira.Account == Account.CARTAO_CREDITO
                    && creditCardNaira.AdditionalMessage != null && creditCardNaira.AdditionalMessage.ToString()
                .StartsWith(EH_CARTAO_CREDITO_NAIRA) && creditCardNaira.HasPay);

            var valorTotalCartaoCreditoNaira = Convert
                .ToDecimal(dataSourceOrderBy
                .Where(creditCardNaira => creditCardNaira.Account == Account.CARTAO_CREDITO
                    && creditCardNaira.AdditionalMessage != null && creditCardNaira.AdditionalMessage.ToString()
                .StartsWith(EH_CARTAO_CREDITO_NAIRA))
                .Sum(x => x.Value));
            ConsolidatePreencherlblGridViewCartaoCreditoNaira(
                quantidadeTotalCartaoCreditoNaira, valorTotalCartaoCreditoNaira, quantidadeTotalPagoCartaoCreditoNaira);

            #endregion CARTÃO DE CRÉDITO NAÍRA
        }

        private void ConsolidatePreencherlblGridViewCartaoCreditoFamilia(
            int quantidadeTotalCartaoCreditoFamilia, decimal valorTotalCartaoCreditoFamilia, int qtdTotalPago = 0)
        {
            string informacaoConsolidate = string
                            .Concat("Cartão de Crédito Família: ", quantidadeTotalCartaoCreditoFamilia, " - ", "R$ ", string
                            .Format("{0:#,##0.00}", valorTotalCartaoCreditoFamilia));

            if (qtdTotalPago == quantidadeTotalCartaoCreditoFamilia)
            {
                informacaoConsolidate = string.Concat(informacaoConsolidate, " - Pagamento OK!");
            }

            lblGridViewCartaoCreditoFamilia.Text = informacaoConsolidate;
        }

        private void ConsolidatePreencherlblGridViewCartaoCreditoNaira(
            int quantidadeTotalCartaoCreditoNaira, decimal valorTotalCartaoCreditoNaira, int qtdTotalPago = 0)
        {
            string informacaoConsolidate = string
                           .Concat("Cartão de Crédito Naíra: ", quantidadeTotalCartaoCreditoNaira, " - ", "R$ ", string
                           .Format("{0:#,##0.00}", valorTotalCartaoCreditoNaira));

            if (qtdTotalPago == quantidadeTotalCartaoCreditoNaira)
            {
                informacaoConsolidate = string.Concat(informacaoConsolidate, " - Pagamento OK!");
            }

            lblGridViewCartaoCreditoNaira.Text = informacaoConsolidate;
        }

        private void ConsolidatePreencherlblGridViewTotalPago(int quantidadeTotalPago, decimal valorTotalPago)
        {
            lblGridViewTotalPago.Text = string
                            .Concat("Pago: ", quantidadeTotalPago, " - ", "R$ ", string
                            .Format("{0:#,##0.00}", valorTotalPago));
        }

        private void ConsolidatePreencherlblGridViewTotais(int quantidadeTotal, decimal valorTotal)
        {
            lblGridViewTotais.Text = string
                            .Concat("Total: ", quantidadeTotal, " - ", "R$ ", string
                            .Format("{0:#,##0.00}", valorTotal));
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

        private void DgvEfetuarPagamentoListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _ = Guid.TryParse(dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[0].Value.ToString(), out Guid identificadorContaPagar);
                var conta = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[2].Value.ToString();
                var descricao = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[3].Value.ToString();
                var valorOfDgv = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[5].Value?.ToString()?.Replace("R$ ", "") ?? "0";
                var valor = Convert.ToDecimal(valorOfDgv);
                var mesAno = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[8].Value.ToString();
                var additionalMessage = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[13].Value?.ToString();

                FrmPagamento frmPagamento = new()
                {
                    IdentificadorUnicoContaPagar = identificadorContaPagar,
                    Nome = descricao,
                    Conta = conta,
                    AnoMes = mesAno,
                    Valor = valor,
                    AdditionalMessage = additionalMessage,
                    Environment = Environment
                };

                frmPagamento.ShowDialog();
            }
        }

        private void BtnPagamentoAvulso_Click(object sender, EventArgs e)
        {
            FrmPagamento frmPagamento = new()
            {
                Environment = Environment
            };

            frmPagamento.ShowDialog();
        }

        private void CboEfetuarPagamentoCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboEfetuarPagamentoCategoria.Text != "Nenhum")
            {
                var filterByCategory = _dgvEfetuarPagamentoListagemDataSource
                    .Where(x => x.Category == cboEfetuarPagamentoCategoria.Text)
                    .ToList();

                PreecherDataGridViewContaPagarListar(filterByCategory);
            }
            else
            {
                PreecherDataGridViewContaPagarListar(_dgvEfetuarPagamentoListagemDataSource);
            }
        }

        private void TxtContaPagarValor_Enter(object sender, EventArgs e)
        {
            txtContaPagarValor.Text = "";
        }

        private void TxtContaPagarValor_Leave(object sender, EventArgs e)
        {
            ValorContaPagarDigitadoTextBox = StringDecimalUtils
                .TranslateStringEmDecimal(txtContaPagarValor.Text);

            txtContaPagarValor.Text = StringDecimalUtils
                .TranslateValorEmStringDinheiro(txtContaPagarValor.Text);
        }

        private void DgvEfetuarPagamentoListagem_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                _ = Guid.TryParse(dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[0].Value.ToString(), out Guid identificadorContaPagar);

                if (identificadorContaPagar == Guid.Empty)
                {
                    MessageBox.Show("Não encontramos o Identificador da Conta pagar conseguir editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var editBillToPayViewModel = new EditBillToPayViewModel
                {
                    Id = identificadorContaPagar,
                    IdFixedInvoice = Convert.ToInt32(dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[1].Value?.ToString()),
                    Account = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[2].Value?.ToString(),
                    Name = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[3].Value?.ToString(),
                    Category = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[4].Value?.ToString(),
                    Value = Convert.ToDecimal(dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[5].Value?.ToString()?.Replace("R$ ", "") ?? "0"),
                    PurchaseDate = DateServiceUtils.GetDateTimeOfString(dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[9].Value?.ToString()),
                    DueDate = DateServiceUtils.GetDateTimeOfString(dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[10].Value?.ToString())!.Value,
                    YearMonth = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[11].Value?.ToString(),
                    Frequence = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[12].Value?.ToString(),
                    RegistrationType = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[13].Value?.ToString(),
                    PayDay = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[14].Value?.ToString(),
                    HasPay = Convert.ToBoolean(dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[15].Value?.ToString()),
                    AdditionalMessage = dgvEfetuarPagamentoListagem.Rows[e.RowIndex].Cells[16].Value?.ToString(),
                    LastChangeDate = DateTime.Now
                };

                FrmEdit frmPagamento = new()
                {
                    EditBillToPayViewModel = editBillToPayViewModel,
                    Environment = Environment
                };

                frmPagamento.ShowDialog();
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

        private void DgvEfetuarPagamentoListagem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvEfetuarPagamentoListagem.Rows)
            {
                if (Convert.ToBoolean(row.Cells[15].Value))
                {
                    SetColorRows(row, Color.DarkGreen, Color.White);
                }

                if (row?.Cells[2]?.Value?.ToString() == Account.CARTAO_CREDITO && !Convert.ToBoolean(row?.Cells[15]?.Value))
                {
                    SetColorRows(row, Color.DarkOrange, Color.Black);
                }

                if (!string.IsNullOrWhiteSpace(row?.Cells[16]?.Value?.ToString())
                    && (bool)(row?.Cells[16]?.Value?.ToString().StartsWith(EH_CARTAO_CREDITO_NAIRA)))
                {
                    SetColorRows(row, Color.DimGray, Color.White);
                }

                var projection = row?.Cells[3]?.Value?.ToString().Contains("(Projetado para o mês todo)") ?? false;

                if (projection)
                {
                    SetColorRows(row, Color.LightGreen, Color.Black);
                }
            }
        }

        private void DgvContaPagar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvContaPagar.Rows)
            {
                if (row.Cells[11].Value.ToString() == RegistrationStatus.AwaitRequestAPI.ToString())
                {
                    SetColorRows(row, Color.Yellow, Color.Black);
                }

                if (row.Cells[11].Value.ToString() == RegistrationStatus.AwaitResponseAPI.ToString())
                {
                    SetColorRows(row, Color.DarkOrange, Color.Black);
                }

                if (row.Cells[11].Value.ToString() == RegistrationStatus.Created.ToString())
                {
                    SetColorRows(row, Color.DarkGreen, Color.White);
                }

                if (row.Cells[11].Value.ToString() == RegistrationStatus.RegistrationError.ToString())
                {
                    SetColorRows(row, Color.DarkRed, Color.White);
                }
            }
        }

        public string? PreencheAmbienteCorretamente()
        {
            if (rdbAmbienteLocal.Checked)
            {
                Environment = "Local";
                InfoHeader.IsProductionEnvironment = false;
                InfoHeader.Environment = Environment;
                InfoHeader.Url = UrlConfig.GetFinanceOrganizationApiUrl(Environment);
                lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
            }

            if (rdbAmbienteHomologacao.Checked)
            {
                Environment = "Homologação";
                InfoHeader.IsProductionEnvironment = false;
                InfoHeader.Environment = Environment;
                InfoHeader.Url = UrlConfig.GetFinanceOrganizationApiUrl(Environment);
                lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
            }

            if (rdbAmbienteProducao.Checked)
            {
                Environment = "Produção";
                InfoHeader.IsProductionEnvironment = true;
                InfoHeader.Environment = Environment;
                InfoHeader.Url = UrlConfig.GetFinanceOrganizationApiUrl(Environment);
                lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
            }

            return Environment;
        }

        private void RdbAmbienteLocal_CheckedChanged(object sender, EventArgs e)
        {
            PreencheAmbienteCorretamente();
        }

        private void RdbAmbienteHomologacao_CheckedChanged(object sender, EventArgs e)
        {
            PreencheAmbienteCorretamente();
        }

        private void RdbAmbienteProducao_CheckedChanged(object sender, EventArgs e)
        {
            PreencheAmbienteCorretamente();
        }

        private void DgvEfetuarPagamentoListagem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DgvEfetuarPagamentoListagem_MultiSelectChanged(object sender, EventArgs e)
        {

        }

        private void DgvEfetuarPagamentoListagem_SelectionChanged(object sender, EventArgs e)
        {
            decimal valorTotalItensSelecionados = 0;
            int quantidadeTotalItensSelecionados = dgvEfetuarPagamentoListagem.SelectedRows.Count;

            foreach (DataGridViewRow row in dgvEfetuarPagamentoListagem.SelectedRows)
            {
                bool isOk = decimal.TryParse(row.Cells[5].Value.ToString(), out decimal valor);

                valorTotalItensSelecionados += isOk ? valor : 0;
            }

            lblEfetuarPagamentoItensSelecionadosDataGridView.Text = string
                .Concat("Itens selecionados: ", quantidadeTotalItensSelecionados, " - ", valorTotalItensSelecionados.ToString("C"));
        }

        private void BtnDetalhesContas_Click(object sender, EventArgs e)
        {
            List<Guid> idsBillsToPay = new();
            List<int> idsFixedInvoices = new();
            var searchBillToPayViewModel = new SearchBillToPayViewModel();

            foreach (DataGridViewRow row in dgvEfetuarPagamentoListagem.SelectedRows)
            {
                _ = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid id);
                _ = int.TryParse(row.Cells[1].Value.ToString(), out int idFixedInvoice);

                idsBillsToPay.Add(id);
                idsFixedInvoices.Add(idFixedInvoice);
            }

            searchBillToPayViewModel.IdFixedInvoices = idsFixedInvoices.ToArray();

            FrmExibirDetalhes frmExcluirDetalhes = new()
            {
                PostSearchBillToPayViewModel = searchBillToPayViewModel,
                Environment = Environment
            };

            frmExcluirDetalhes.ShowDialog();
        }

        private void DgvEfetuarPagamentoListagem_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {

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

        private void CboNaoEnviarMesAnoFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (cboNaoEnviarMesAnoFinal.Checked)
            {
                if (ckbContaPagarConsideraMesmoMes.Checked)
                {
                    var result = MessageBox
                                        .Show("Você quer considerar o mesmo Mês/Ano inicial e final?",
                                        "E aí cara?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        cboContaPagarAnoMesFinal.SelectedItem = cboContaPagarAnoMesInicial.SelectedItem;
                        cboContaPagarAnoMesFinal.Enabled = false;
                        ckbContaPagarConsideraMesmoMes.Checked = false;

                    }
                }

                cboContaPagarAnoMesFinal.Enabled = false;
                cboContaPagarAnoMesFinal.Text = null;
            }
            else
            {
                cboContaPagarAnoMesFinal.Enabled = true;
                PreencherComboBoxcboContaPagarAnoMesFinal();
            }
        }

        private async void BtnSearchMonthlyAverageAnalysis_Click(object sender, EventArgs e)
        {
            lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
            await SearchMonthlyAverageAnalysis();
        }

        public async Task SearchMonthlyAverageAnalysis()
        {
            _dgvVisuarEstudoFinanceiroDataSource.Clear();

            SearchMonthlyAverageAnalysisViewModel search = new()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                QuantityMonthsAnalysis = MapQuantityMonths()
            };

            await PreencherEstudoFinanceiroDataGridViewHistory(search);
        }

        private async Task PreencherEstudoFinanceiroDataGridViewHistory(SearchMonthlyAverageAnalysisViewModel search)
        {
            BillToPayServices.Environment = Environment;
            var resultSearch = await BillToPayServices.SearchMonthlyAverageAnalysis(search);

            var dataSource = MapSearchMonthlyAverageAnalysisResultToDataSource(resultSearch);

            var dataSourceOrderBy = dataSource
                .ToList();

            PreecherDataGridViewEstudoFinanceiro(dataSourceOrderBy);
        }

        private static IList<DgvVisualizarEstudoFinanceiroDataSource> MapSearchMonthlyAverageAnalysisResultToDataSource(SearchMonthlyAverageAnalysisOutput output)
        {
            IList<DgvVisualizarEstudoFinanceiroDataSource> dgvEfetuarPagamentoListagemDataSources = new List<DgvVisualizarEstudoFinanceiroDataSource>();

            if (output.Output == null || output.Output.Data == null)
            {
                return dgvEfetuarPagamentoListagemDataSources;
            }

            var dados = output.Output.Data;

            var json = JsonConvert.SerializeObject(dados);

            var conversion = JsonConvert.DeserializeObject<IList<DgvVisualizarEstudoFinanceiroDataSource>>(json);

            foreach (var item in conversion!)
            {
                dgvEfetuarPagamentoListagemDataSources.Add(item);
            }

            return dgvEfetuarPagamentoListagemDataSources;
        }

        private void PreecherDataGridViewEstudoFinanceiro(IList<DgvVisualizarEstudoFinanceiroDataSource> dataSourceOrderBy)
        {
            ConsolidateEstudoFinanceiro(dataSourceOrderBy);

            _dgvVisuarEstudoFinanceiroDataSource = dataSourceOrderBy;

            dgvSearchMonthlyAverageAnalysis.DataSource = dataSourceOrderBy;
            dgvSearchMonthlyAverageAnalysis.Columns[0].HeaderText = "Categoria";
            dgvSearchMonthlyAverageAnalysis.Columns[1].HeaderText = "Registros Totais";

            dgvSearchMonthlyAverageAnalysis.Columns[2].HeaderText = "R$ Total";
            dgvSearchMonthlyAverageAnalysis.Columns[2].DefaultCellStyle.Format = "C2";
            dgvSearchMonthlyAverageAnalysis.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearchMonthlyAverageAnalysis.Columns[3].HeaderText = "Meses Análisados";

            dgvSearchMonthlyAverageAnalysis.Columns[4].HeaderText = "R$ Média Mensal";
            dgvSearchMonthlyAverageAnalysis.Columns[4].DefaultCellStyle.Format = "C2";
            dgvSearchMonthlyAverageAnalysis.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearchMonthlyAverageAnalysis.Columns[5].HeaderText = "Registros Média";
            dgvSearchMonthlyAverageAnalysis.Columns[6].HeaderText = "Primeira Data";
            dgvSearchMonthlyAverageAnalysis.Columns[7].HeaderText = "Última Data";
        }

        private void ConsolidateEstudoFinanceiro(IList<DgvVisualizarEstudoFinanceiroDataSource> dataSourceOrderBy)
        {

        }

        private void PreencherComboBoxEstudoFinanceiroQuantideMeses()
        {
            Dictionary<int, string> quantidaeMeses = new()
            {
                { 0, "Mês Anterior" },
                { 1, "2 meses anteriores" },
                { 2, "3 meses anteriores" },
                { 3, "4 meses anteriores" },
                { 4, "5 meses anteriores" }
            };

            foreach (var item in quantidaeMeses)
            {
                cboEstudoFinanceiroMesesAnalises.Items.Add(item.Value);
            }

            cboEstudoFinanceiroMesesAnalises.SelectedItem = quantidaeMeses.Where(x => x.Key == 3).FirstOrDefault().Value;
        }

        private int MapQuantityMonths()
        {
            if (cboEstudoFinanceiroMesesAnalises.Text == "Mês Anterior")
            {
                return -0;
            }

            else if (cboEstudoFinanceiroMesesAnalises.Text == "2 meses anteriores")
            {
                return -1;
            }

            else if (cboEstudoFinanceiroMesesAnalises.Text == "3 meses anteriores")
            {
                return -2;
            }

            else if (cboEstudoFinanceiroMesesAnalises.Text == "4 meses anteriores")
            {
                return -3;
            }

            else if (cboEstudoFinanceiroMesesAnalises.Text == "5 meses anteriores")
            {
                return -4;
            }
            else
            {
                return -3;
            }
        }

        private void CkbCartaoCreditoNaira_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCartaoCreditoNaira.Checked)
            {
                if (cboContaPagarTipoConta.Text != "Cartão de Crédito")
                {
                    cboContaPagarTipoConta.Text = "Cartão de Crédito";
                }

                SetColorGrbTemplateContaPagar();

                if (!rtbContaPagarMensagemAdicional.Text.StartsWith(EH_CARTAO_CREDITO_NAIRA))
                {
                    rtbContaPagarMensagemAdicional.Text = string.Concat(EH_CARTAO_CREDITO_NAIRA, txtContaPagarNameDescription.Text);
                }
            }
            else
            {
                SetColorGrbTemplateContaPagar();
                rtbContaPagarMensagemAdicional.Text = rtbContaPagarMensagemAdicional.Text.Replace(EH_CARTAO_CREDITO_NAIRA, "");
            }
        }

        private void SetColorGrbTemplateContaPagar()
        {
            if (cboContaPagarTipoConta.Text == "Cartão de Crédito")
            {
                if (ckbCartaoCreditoNaira.Checked)
                {
                    grbTemplateContaPagar.BackColor = Color.DimGray;
                    grbTemplateContaPagar.ForeColor = Color.White;
                }
                else
                {
                    grbTemplateContaPagar.BackColor = Color.DarkOrange;
                    grbTemplateContaPagar.ForeColor = Color.Black;
                }
            }
            else
            {
                grbTemplateContaPagar.BackColor = Color.White;
                grbTemplateContaPagar.ForeColor = Color.Black;
            }
        }

        private void DtpContaPagarDataCompra_ValueChanged(object sender, EventArgs e)
        {
            var dayChoise = DateServiceUtils.GetDateTimeOfString(dtpContaPagarDataCompra.Text);

            if (dayChoise.HasValue)
            {
                cboContaPagarMelhorDiaPagamento.Text = dayChoise.Value.Day.ToString();
            }
        }

        private void CboContaPagarTipoConta_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboContaPagarTipoConta.Text != "Cartão de Crédito" && ckbCartaoCreditoNaira.Checked)
            {
                ckbCartaoCreditoNaira.Checked = false;
            }

            SetColorGrbTemplateContaPagar();
        }
    }
}