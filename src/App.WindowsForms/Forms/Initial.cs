using App.Forms.Config;
using App.Forms.DataSource;
using App.Forms.Enums;
using App.Forms.Forms.Edição;
using App.Forms.Forms.Pay;
using App.Forms.Services;
using App.Forms.Services.Output;
using App.Forms.UI;
using App.Forms.ViewModel;
using App.WindowsForms.BackgroundServices;
using App.WindowsForms.DataSource;
using App.WindowsForms.Enums;
using App.WindowsForms.Forms.ExcluirDetalhes;
using App.WindowsForms.Repository;
using App.WindowsForms.Services;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Domain.Entities;
using Domain.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Concurrent;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace App.Forms.Forms
{
    public partial class Initial : Form
    {
        private const string TAB_PAGE_CONTA_PAGAR_CADASTRO = "tbpContaPagarLivre";
        private const string TAB_PAGE_VISUALIZAR_CONTA_PAGAR = "tbpEfetuarPagamento";
        private const string TAB_PAGE_ESTUDO_FINANCEIRO = "tbpEstudosFinanceiros";
        private const string DESCRICAO_GROUP_BOX = "Cadastro de Conta a Pagar";
        private readonly ConcurrentDictionary<int, object> _cadastroContaViewModels = new();
        private IList<DgvVisualizarContaPagarDataSource> _dgvEfetuarPagamentoListagemDataSource = new List<DgvVisualizarContaPagarDataSource>();
        private IList<DgvVisualizarEstudoFinanceiroDataSource> _dgvVisuarEstudoFinanceiroDataSource = new List<DgvVisualizarEstudoFinanceiroDataSource>();
        private IList<DgvVisualizarContaReceberDataSource> _dgvVisualizarContaReceberDataSource = new List<DgvVisualizarContaReceberDataSource>();
        private IHost _host;
        private int _eventRepeat = 0;
        private bool ehInitialization = false;

        public static int CurrentIndex { get; set; } = 0;
        public decimal ValorContaPagarDigitadoTextBox { get; set; } = 0;
        public int IdDgvCadastroConta { get; set; } = 0;
        public InfoHeader InfoHeader { get; set; } = new InfoHeader();
        public string? Environment { get; set; }

        private AccountRepository _accountRepository;
        private BillToPayRegistrationRepository _billToPayRegistrationRepository;

        public Initial(InfoHeader? infoHeader)
        {
            if (infoHeader != null)
            {
                InfoHeader = infoHeader;
                Environment = infoHeader.Environment;
            }

            _accountRepository = AccountRepository.Instance;
            _billToPayRegistrationRepository = BillToPayRegistrationRepository.Instance;

            Task.Run(async () =>
            {
                await InitializerBackgroundService();
            });

            InitializeComponent();
        }

        private async void Initial_Load(object sender, EventArgs e)
        {
            CultureSelectorHelper.InitializeCultureComboBox(cboCultura);
            ehInitialization = true;
            rdbCadastroContaPagar.Checked = true;
            lblQtdItensParaFinalizarCadastro.Visible = false;
            lblEventRepeat.Visible = false;
            lblVersion.Text = InfoHeader.Version;
            lblInfoHeader.Text = AdjusteInfoHeader();
            PreencherLabelDataCriacao();
            await PreencherComboBoxCadastroContaAccount();
            await PreencherComboBoxContaPagarCategoriaAsync();
            await PreencherComboBoxAnoMes();
            PreencherComboBoxEstudoFinanceiroQuantideMeses();
            RegraCamposAnoMes();
            CampoValor();
            TabPageIndexOne();
            PreencherContaPagarMelhorDiaPagamento();
            LoadFrequence();
            LoadType();


            await CarregaContasApagar();
            await CarregaContasAReceber();
            await SearchMonthlyAverageAnalysis();


            tbcInitial.SelectedTab = tbcInitial.TabPages[1];
            ToolTip tooltipBtnPagamentoAvulso = new();
            tooltipBtnPagamentoAvulso.SetToolTip(this.btnPagamentoAvulso, "Ideal p/ Pagamento em Massa, Ex.: Cartão de Crédito");
            SetColorGrbTemplateContaPagar();

            lblTotalValueGridView.Text = string.Empty;

            _billToPayRegistrationRepository.DataProcessed += OnEventNotify;
        }

        /// <summary>
        /// Evento que executa quando a resposta da API para cadastros pendentes executa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="listBillToPayRegistration"></param>
        private void OnEventNotify(object? sender, IList<BillToPayRegistration> listBillToPayRegistration)
        {
            _eventRepeat++;
            _ = TimeSpan.TryParse(ConfigurationManager.AppSettings["routine-worker-start-time"], out TimeSpan time);
            var shouldAlertVisible = listBillToPayRegistration.Count > 0;
            if (lblQtdItensParaFinalizarCadastro.InvokeRequired)
            {
                lblQtdItensParaFinalizarCadastro.Invoke(new Action(async () =>
                {
                    lblQtdItensParaFinalizarCadastro.Visible = shouldAlertVisible;
                    grbAlerta.Visible = shouldAlertVisible;
                    lblEventRepeat.Visible = listBillToPayRegistration.Count > 0;
                    lblQtdItensParaFinalizarCadastro.Text = listBillToPayRegistration.Count > 0
                        ? $"Conta a Pagar pendente de importação: {listBillToPayRegistration.Count}"
                        : "Nenhum item para finalizar cadastro.";
                    lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
                    lblEventRepeat.Text = $"A cada {time.TotalSeconds} segundo(s) é efetuado uma consulta. Evento Repetido: {_eventRepeat}x até o momento.";
                }));
            }
            else
            {
                grbAlerta.Visible = shouldAlertVisible;
                lblQtdItensParaFinalizarCadastro.Visible = shouldAlertVisible;
                lblEventRepeat.Visible = shouldAlertVisible;
                lblQtdItensParaFinalizarCadastro.Text = shouldAlertVisible
                    ? $"Quantidade de Cadastro Pendentes: {listBillToPayRegistration.Count}"
                    : "Nenhum item para finalizar cadastro.";
            }
        }

        private async Task InitializerBackgroundService()
        {
            _host = Host.CreateDefaultBuilder()
            .UseSerilog()
            .ConfigureServices(services =>
            {
                services.AddHostedService<FillInInformationBackgroundService>();
            })
            .Build();

            await _host.RunAsync();
        }

        private string AdjusteInfoHeader(DateTime? lastUpdate = null)
        {
            string? lblInfoHeaderIntern;

            if (InfoHeader.IsProductionEnvironment || InfoHeader.Environment == "Produção")
            {
                rdbAmbienteProducao.Checked = true;
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
                rdbAmbienteHomologacao.Checked = true;
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
                rdbAmbienteLocal.Checked = true;
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

        private async void BtnEfetuarCadastroConta_Click(object sender, EventArgs e)
        {
            var accountType = GetAccountType();

            if (accountType == AccountType.ContaAPagar)
            {
                IdDgvCadastroConta++;

                var accountWithoutNumbers = cboCadastroContaAccount.Text.Split(" - ");

                CreateBillToPayViewModel createBillToPay = new();
                createBillToPay.Name = txtCadastroContaName.Text;
                createBillToPay.Account = accountWithoutNumbers[0];
                createBillToPay.Frequence = cboCadastroContaFrequence.Text;
                createBillToPay.RegistrationType = cboCadastroContaRegistrationType.Text;
                createBillToPay.InitialMonthYear = cboCadastroContaInititalMonthYear.Text;
                createBillToPay.FynallyMonthYear = !cboNaoEnviarMesAnoFinal.Checked ? cboCadastroContaFinallyMonthYear.Text : null;
                createBillToPay.Category = cboCadastroContaCategory.Text;
                createBillToPay.Value = Convert.ToDecimal(RemoveCurrencySymbol(txtCadastroContaValue.Text));
                createBillToPay.PurchaseDate = cboCadastroContaHabilitarDate.Checked ? dtpCadastroContaDate.Value : null;
                createBillToPay.BestPayDay = Convert.ToInt32(cboCadastroContaBestDay.Text);
                createBillToPay.AdditionalMessage = rtbCadastroContaMensagemAdicional.Text;
                createBillToPay.CreationDate = DateTime.Now;
                createBillToPay.LastChangeDate = null;
                createBillToPay.Status = RegistrationStatus.AwaitRequestAPI;
                createBillToPay.AccountType = AccountType.ContaAPagar;

                _cadastroContaViewModels.TryAdd(IdDgvCadastroConta, createBillToPay);

                UpdateDataGridView(accountType);

                BillToPayServices.Environment = Environment;
                var result = await BillToPayServices.CreateBillToPay(createBillToPay);

                UpdateDataGridView(accountType);

                TratamentoOutput(IdDgvCadastroConta, result.Output, accountType);
            }
            else if (accountType == AccountType.ContaAReceber)
            {
                IdDgvCadastroConta++;

                var accountWithoutNumbers = cboCadastroContaAccount.Text.Split(" - ");

                var createCashReceivable = new CreateCashReceivableViewModel
                {
                    Name = txtCadastroContaName.Text,
                    Account = accountWithoutNumbers[0],
                    Frequence = cboCadastroContaFrequence.Text,
                    RegistrationType = cboCadastroContaRegistrationType.Text,
                    InitialMonthYear = cboCadastroContaInititalMonthYear.Text,
                    FynallyMonthYear = !cboNaoEnviarMesAnoFinal.Checked ? cboCadastroContaFinallyMonthYear.Text : null,
                    Category = cboCadastroContaCategory.Text,
                    Value = Convert.ToDecimal(RemoveCurrencySymbol(txtCadastroContaValue.Text)),
                    AgreementDate = cboCadastroContaHabilitarDate.Checked ? dtpCadastroContaDate.Value : null,
                    BestReceivingDay = Convert.ToInt32(cboCadastroContaBestDay.Text),
                    AdditionalMessage = rtbCadastroContaMensagemAdicional.Text,
                    CreationDate = DateTime.Now,
                    LastChangeDate = null,
                    Status = RegistrationStatus.AwaitRequestAPI,
                    AccountType = AccountType.ContaAReceber
                };

                _cadastroContaViewModels.TryAdd(IdDgvCadastroConta, createCashReceivable);

                UpdateDataGridView(accountType);

                CashReceivableServices.Environment = Environment;
                var result = await CashReceivableServices.CreateCashReceivable(createCashReceivable);

                UpdateDataGridView(accountType);

                TratamentoOutput(IdDgvCadastroConta, result.Output, accountType);
            }
        }

        private AccountType GetAccountType()
        {
            if (rdbCadastroContaPagar.Checked)
            {
                return AccountType.ContaAPagar;
            }
            else
            {
                return AccountType.ContaAReceber;
            }
        }

        private void TratamentoOutput(int identifier, object result, AccountType accountType)
        {
            var outputDetails = (OutputDetails)result;

            if (outputDetails.Status == OutputStatus.Success)
            {
                MessageBox.Show(outputDetails.Message,
                    "Cadastro de Conta a Pagar Realizado com Sucesso.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (accountType == AccountType.ContaAPagar)
                {
                    var billToPay = _cadastroContaViewModels[identifier];
                    CreateBillToPayViewModel createBillToPayViewModel = billToPay as CreateBillToPayViewModel;
                    if (createBillToPayViewModel != null)
                    {
                        createBillToPayViewModel.Status = RegistrationStatus.Created;
                        _cadastroContaViewModels[identifier] = createBillToPayViewModel;
                    }
                }
                else
                {
                    var cashReceivable = _cadastroContaViewModels[identifier];
                    CreateCashReceivableViewModel createCashReceivable = cashReceivable as CreateCashReceivableViewModel;
                    if (createCashReceivable != null)
                    {
                        createCashReceivable.Status = RegistrationStatus.Created;
                        _cadastroContaViewModels[identifier] = createCashReceivable;
                    }
                }
                UpdateDataGridView(accountType);
            }
            else
            {
                if (accountType == AccountType.ContaAPagar)
                {
                    var billToPay = _cadastroContaViewModels[identifier];
                    CreateBillToPayViewModel createBillToPayViewModel = billToPay as CreateBillToPayViewModel;
                    if (createBillToPayViewModel != null)
                    {
                        createBillToPayViewModel.Status = RegistrationStatus.RegistrationError;
                        _cadastroContaViewModels[identifier] = createBillToPayViewModel;
                    }
                }
                else
                {
                    var cashReceivable = _cadastroContaViewModels[identifier];
                    CreateCashReceivableViewModel createCashReceivable = cashReceivable as CreateCashReceivableViewModel;
                    if (createCashReceivable != null)
                    {
                        createCashReceivable.Status = RegistrationStatus.RegistrationError;
                        _cadastroContaViewModels[identifier] = createCashReceivable;
                    }
                }

                UpdateDataGridView(accountType);

                var information = string.Empty;

                var errors = outputDetails.Errors;
                var validations = outputDetails.Validations;

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

        private void UpdateDataGridView(AccountType accountType)
        {
            dgvCadastroConta.DataSource = MapCadastroContaViewModelToDataSource(_cadastroContaViewModels);
            dgvCadastroConta.Columns[0].HeaderText = "Descrição";
            dgvCadastroConta.Columns[1].HeaderText = "Conta";
            dgvCadastroConta.Columns[2].HeaderText = "Frequência";
            dgvCadastroConta.Columns[3].HeaderText = "Tipo";
            dgvCadastroConta.Columns[4].HeaderText = "Inicial";
            dgvCadastroConta.Columns[5].HeaderText = "Final";
            dgvCadastroConta.Columns[6].HeaderText = "Categoria";
            dgvCadastroConta.Columns[7].HeaderText = "Valor";
            dgvCadastroConta.Columns[8].HeaderText = "Data de Compra";
            dgvCadastroConta.Columns[9].HeaderText = "Melhor Dia";
            dgvCadastroConta.Columns[10].HeaderText = "Mensagem";
            dgvCadastroConta.Columns[11].HeaderText = "Status";
        }

        private static IList<DgvCadastroContaDataSource> MapCadastroContaViewModelToDataSource(
            ConcurrentDictionary<int, object> listViewModels, int? idDgvCadastroConta = null)
        {
            var dgvCadastroContaDataSource = new DgvCadastroContaDataSource();
            IList<DgvCadastroContaDataSource> list = new List<DgvCadastroContaDataSource>();

            if (idDgvCadastroConta != null)
            {
                listViewModels
                    .Where(x => x.Key != idDgvCadastroConta)
                    .ToList()
                    .ForEach(x => listViewModels.Remove(x.Key, out object test));
            }

            foreach (var objectViewModel in listViewModels.Values)
            {
                var accountType = GetAccountType(objectViewModel);

                if (accountType == AccountType.ContaAPagar)
                {
                    var createBillToPayViewModel = (CreateBillToPayViewModel?)objectViewModel;
                    if (createBillToPayViewModel != null)
                    {
                        dgvCadastroContaDataSource = new DgvCadastroContaDataSource()
                        {
                            Name = createBillToPayViewModel.Name,
                            Account = createBillToPayViewModel.Account,
                            Frequence = createBillToPayViewModel.Frequence,
                            RegistrationType = createBillToPayViewModel.RegistrationType,
                            InitialMonthYear = createBillToPayViewModel.InitialMonthYear,
                            FynallyMonthYear = createBillToPayViewModel.FynallyMonthYear,
                            Category = createBillToPayViewModel.Category,
                            Value = createBillToPayViewModel.Value,
                            PurchaseDate = createBillToPayViewModel.PurchaseDate,
                            BestPayDay = createBillToPayViewModel.BestPayDay,
                            AdditionalMessage = createBillToPayViewModel.AdditionalMessage,
                            Status = createBillToPayViewModel.Status.ToString()
                        };
                    }
                }
                else if (accountType == AccountType.ContaAReceber)
                {
                    var createCashReceivableViewModel = (CreateCashReceivableViewModel?)objectViewModel;
                    if (createCashReceivableViewModel != null)
                    {
                        dgvCadastroContaDataSource = new DgvCadastroContaDataSource()
                        {
                            Name = createCashReceivableViewModel.Name,
                            Account = createCashReceivableViewModel.Account,
                            Frequence = createCashReceivableViewModel.Frequence,
                            RegistrationType = createCashReceivableViewModel.RegistrationType,
                            InitialMonthYear = createCashReceivableViewModel.InitialMonthYear,
                            FynallyMonthYear = createCashReceivableViewModel.FynallyMonthYear,
                            Category = createCashReceivableViewModel.Category,
                            Value = createCashReceivableViewModel.Value,
                            PurchaseDate = createCashReceivableViewModel.AgreementDate,
                            BestPayDay = createCashReceivableViewModel.BestReceivingDay,
                            AdditionalMessage = createCashReceivableViewModel.AdditionalMessage,
                            Status = createCashReceivableViewModel.Status.ToString()
                        };
                    }
                }

                list.Add(dgvCadastroContaDataSource);
            }

            return list;
        }

        private static AccountType? GetAccountType(object objectViewModel)
        {
            // Obtém todas as propriedades do tipo
            PropertyInfo[] propriedades = objectViewModel.GetType().GetProperties();

            var accountTypeByObject = propriedades.FirstOrDefault(x => x.Name == "AccountType");

            AccountType? accountType = (AccountType?)(accountTypeByObject?
                .GetValue(objectViewModel));

            return accountType;
        }

        private void PreencherLabelDataCriacao()
        {
            string texto = "Data de Criação: ";
            lblCadastroContaDataCriacao.Text = string.Concat(texto, DateTime.Now);
        }

        private async Task PreencherComboBoxContaPagarCategoriaAsync(string tabPageName = null, string categorySelected = null)
        {
            cboCadastroContaCategory.Items.Clear();
            cboEfetuarPagamentoCategoria.Items.Clear();
            CategoryServices.Environment = Environment;
            var resultSearch = await CategoryServices
                .SearchCategories(new SearchCategoryViewModel()
                {
                    AccountType = AccountType.ContaAPagar,
                    Enable = cboBuscaTodasCategorias.Checked ? false : true
                });

            Dictionary<int, string> subCategoriasContaPagar = new() { };
            Dictionary<int, string> categoriasContaPagar = new() { };

            int contSubCategory = 0;
            int contCategory = 0;

            if (resultSearch.Categories != null)
            {
                var categories = resultSearch.Categories?.ToList()?.Select(x => x.Split(":")[0]).Distinct().ToArray();

                foreach (var category in categories)
                {
                    if (contCategory == 0)
                    {
                        categoriasContaPagar.Add(contCategory, "Nenhum");
                        contCategory++;
                        categoriasContaPagar.Add(contCategory, category);
                    }
                    else
                    {
                        categoriasContaPagar.Add(contCategory, category);
                    }
                    contCategory++;
                }

                foreach (var item in resultSearch.Categories)
                {
                    if (contSubCategory == 0)
                    {
                        subCategoriasContaPagar.Add(contSubCategory, "Nenhum");
                        contSubCategory++;
                        subCategoriasContaPagar.Add(contSubCategory, item);
                    }
                    else
                    {
                        subCategoriasContaPagar.Add(contSubCategory, item);
                    }

                    contSubCategory++;
                }
            }
            else
            {
                subCategoriasContaPagar.Add(contSubCategory, "Nenhum");
                categoriasContaPagar.Add(contCategory, "Nenhum");
            }

            var subCategoriasContaPagarOrderBy = subCategoriasContaPagar
                .OrderBy(x => x.Value)
                .Where(x => x.Key != 0)
                .ToList();

            var categoriasContaPagarOrderBy = categoriasContaPagar
                .OrderBy(x => x.Value)
                .Where(x => x.Key != 0)
                .ToList();

            var first = subCategoriasContaPagar.FirstOrDefault(x => x.Key == 0);

            cboCadastroContaCategory.Items.Add(first.Value);
            cboEfetuarPagamentoCategoria.Items.Add(first.Value);

            foreach (var item in subCategoriasContaPagarOrderBy)
            {
                cboCadastroContaCategory.Items.Add(item.Value);
                cboEfetuarPagamentoCategoria.Items.Add(item.Value);
            }

            foreach (var item in categoriasContaPagarOrderBy)
            {
                cboInitialCategory.Items.Add(item.Value);
            }

            cboInitialCategory.SelectedItem = "Nenhum";

            if (categorySelected == null)
            {
                cboCadastroContaCategory.SelectedItem = first.Value;
                cboEfetuarPagamentoCategoria.SelectedItem = first.Value;
            }
            else
            {
                var theChoise = subCategoriasContaPagarOrderBy
                    .FirstOrDefault(x => x.Value == categorySelected);

                if (theChoise.Value.Length > 0)
                {
                    cboCadastroContaCategory.SelectedItem = theChoise.Value;
                    cboEfetuarPagamentoCategoria.SelectedItem = theChoise.Value;
                }
                else
                {
                    var dado = subCategoriasContaPagarOrderBy
                        .FirstOrDefault().Value;

                    cboCadastroContaCategory.SelectedItem = dado;
                    cboEfetuarPagamentoCategoria.SelectedItem = dado;
                }
            }
        }

        private async Task PreencherComboBoxCadastroContaAccount(string tabPageName = null, string accountSelected = null)
        {
            AccountServices.Environment = Environment;
            var accounts = await AccountServices.SearchAccounts(new SearchAccountViewModel());

            foreach (var account in accounts)
            {
                _accountRepository.AddOnMemory(account);
            }

            cboInitialAccount.Items.Add("Nenhum");

            foreach (var item in _accountRepository._accounts.Values.OrderBy((x) => x.Name))
            {
                string name = item.Name;
                if (item.IsCreditCard)
                {
                    name = string.Concat(item.Name, " - ", item.CardNumber);
                }

                if (item.Enable)
                {
                    cboCadastroContaAccount.Items.Add(name);
                    cboInitialAccount.Items.Add(name);
                }
            }

            if (accountSelected == null)
            {
                cboCadastroContaAccount.SelectedItem = _accountRepository._accounts[0];
                cboInitialAccount.SelectedItem = "Nenhum";
            }
            else
            {
                var theChoise = _accountRepository._accounts.FirstOrDefault(x => x.Value.Name == accountSelected);

                if (theChoise.Value.Name != null)
                {
                    cboCadastroContaAccount.SelectedItem = theChoise.Value;
                }
                else
                {
                    cboCadastroContaAccount.SelectedItem = _accountRepository._accounts.FirstOrDefault().Value.Name;
                }
            }
        }

        private async Task PreencherComboBoxAnoMes()
        {
            DateServices.Environment = Environment;
            var serviceDate = await DateServices.SearchMonthYears(new SearchDateYearMonthViewModel() { StartYear = 2020, EndYear = 2030 });

            string[]? yearMonthsArray;

            yearMonthsArray = serviceDate?.MonthYears;

            cboCadastroContaInititalMonthYear.Items.AddRange(yearMonthsArray);
            cboAnoMesContaPagar.Items.AddRange(yearMonthsArray);
            cboMesAnoContaReceber.Items.AddRange(yearMonthsArray);
            cboCadastroContaFinallyMonthYear.Items.AddRange(yearMonthsArray);

            string currentYearMonth = DateUtils.GetYearMonthPortugueseByDateTime(DateTime.Now);

            cboCadastroContaInititalMonthYear.SelectedItem = currentYearMonth;
            cboAnoMesContaPagar.SelectedItem = currentYearMonth;
            cboMesAnoContaReceber.SelectedItem = currentYearMonth;
            cboCadastroContaFinallyMonthYear.SelectedItem = currentYearMonth;
        }

        private void PreencherContaPagarMelhorDiaPagamento()
        {
            IList<int> bestPayDay = new List<int>();

            for (int day = 1; day <= 31; day++)
            {
                bestPayDay.Add(day);
                cboCadastroContaBestDay.Items.Add(day);
            }

            cboCadastroContaBestDay.SelectedItem = DateTime.Now.Day;
        }

        private void LoadFrequence(string tabPageName = null, string frequenciaSelected = null)
        {
            Dictionary<int, string> frequencia = new()
            {
                { 1, "Livre" },
                { 2, "Mensal" },
                { 3, "Mensal:Recorrente" },
                { 4, "Apenas desta vez" }
            };

            foreach (var item in frequencia)
            {
                cboCadastroContaFrequence.Items.Add(item.Value);
            }

            if (frequenciaSelected == null)
            {
                cboCadastroContaFrequence.SelectedItem = frequencia.FirstOrDefault().Value;
            }
            else
            {
                var theChoise = frequencia.FirstOrDefault(x => x.Value == frequenciaSelected);

                if (theChoise.Value.Length > 0)
                {
                    cboCadastroContaFrequence.SelectedItem = theChoise.Value;
                }
                else
                {
                    cboCadastroContaFrequence.SelectedItem = frequencia.FirstOrDefault().Value;
                }
            }
        }

        private void LoadType(string tabPageName = null, string tipoCadastroSelected = null)
        {
            Dictionary<int, string> tipoCadastro = new()
            {
                { 1, "Compra Livre" },
                { 2, "Conta/Fatura Fixa" }
            };

            foreach (var item in tipoCadastro)
            {
                cboCadastroContaRegistrationType.Items.Add(item.Value);
            }

            if (tipoCadastroSelected == null)
            {
                cboCadastroContaRegistrationType.SelectedItem = tipoCadastro.FirstOrDefault().Value;
            }
            else
            {
                var theChoise = tipoCadastro.FirstOrDefault(x => x.Value == tipoCadastroSelected);

                if (theChoise.Value.Length > 0)
                {
                    cboCadastroContaRegistrationType.SelectedItem = theChoise.Value;
                }
                else
                {
                    cboCadastroContaRegistrationType.SelectedItem = tipoCadastro.FirstOrDefault().Value;
                }
            }
        }

        private void CkbContaPagarConsideraMesmoMes_CheckedChanged(object sender, EventArgs e)
        {
            RegraCamposAnoMes();
        }

        private void RegraCamposAnoMes()
        {
            if (ckbCadastroContaConsideraMesmoMes.Checked)
            {
                if (cboNaoEnviarMesAnoFinal.Checked)
                {
                    var result = MessageBox
                        .Show("Você enviará o Mês/Ano Final exatamente igual o inicial?",
                        "E aí cara?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        cboCadastroContaFinallyMonthYear.SelectedItem = cboCadastroContaInititalMonthYear.SelectedItem;
                        cboCadastroContaFinallyMonthYear.Enabled = false;
                        cboNaoEnviarMesAnoFinal.Checked = false;
                    }
                }

                cboCadastroContaFinallyMonthYear.SelectedItem = cboCadastroContaInititalMonthYear.SelectedItem;
                cboCadastroContaFinallyMonthYear.Enabled = false;
            }
            else
            {
                cboCadastroContaFinallyMonthYear.Enabled = true;
            }
        }

        private void CampoValor()
        {
            txtCadastroContaValue.Text = Convert.ToDecimal("0").ToString("C");
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
            cboCadastroContaCategory.Items.Clear();
            cboCadastroContaAccount.Items.Clear();
            PreencherComboBoxCadastroContaAccount(tabPageName, account).GetAwaiter().GetResult();
            PreencherComboBoxContaPagarCategoriaAsync(tabPageName, category).GetAwaiter().GetResult();
        }

        private async void BtnEfetuarPagamentoBuscar_Click(object sender, EventArgs e)
        {
            lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
            await CarregaContasApagar();
        }

        public async Task CarregaContasApagar(bool notSelectedItem = true)
        {
            _dgvEfetuarPagamentoListagemDataSource.Clear();

            if (notSelectedItem)
            {
                cboEfetuarPagamentoCategoria.SelectedItem = "Nenhum";
                cboInitialAccount.SelectedItem = "Nenhum";
            }

            SearchBillToPayViewModel search = new()
            {
                YearMonth = cboAnoMesContaPagar.Text
            };

            await PreencherContaPagarDataGridView(search);
        }

        public async Task CarregaContasAReceber()
        {
            _dgvVisualizarContaReceberDataSource.Clear();

            SearchCashReceivableViewModel search = new()
            {
                YearMonth = cboMesAnoContaReceber.Text
            };

            await PreencherContaReceberDataGridView(search);
        }

        private async Task PreencherContaPagarDataGridView(SearchBillToPayViewModel search)
        {
            BillToPayServices.Environment = Environment;
            var resultSearch = await BillToPayServices.SearchBillToPay(search);

            var dataSource = MapSearchResultContaPagarToDataSource(resultSearch);

            var dataSourceOrderBy = dataSource
                .OrderBy(hasPay => hasPay.HasPay)
                .ThenBy(creditCard => creditCard.AccountObject?.IsCreditCard)
                .ThenBy(dueDate => dueDate.DueDate)
                .ThenByDescending(purchase => purchase.PurchaseDate)
                .ToList();

            PreencheDataSourceContaPagar(dataSourceOrderBy);
        }

        private async Task PreencherContaReceberDataGridView(SearchCashReceivableViewModel search)
        {
            CashReceivableServices.Environment = Environment;
            var resultService = await CashReceivableServices.SearchCashReceivable(search);

            var dataSource = MapSearchResultContaReceberToDataSource(resultService);

            var dataSourceOrderBy = dataSource
                .OrderBy(dueDate => dueDate.DueDate)
                .ThenByDescending(dateReceived => dateReceived.DateReceived)
                .ToList();

            PreencheDataSourceContaReceber(dataSourceOrderBy);
        }

        private void PreencheDataSourceContaPagar(IList<DgvVisualizarContaPagarDataSource> dataSourceOrderBy)
        {
            ConsolidateContaPagarListagem(dataSourceOrderBy);

            _dgvEfetuarPagamentoListagemDataSource = dataSourceOrderBy;

            dgvContaPagar.DataSource = dataSourceOrderBy;
            dgvContaPagar.Columns[0].HeaderText = "Id";
            dgvContaPagar.Columns[0].Visible = false;
            dgvContaPagar.Columns[1].HeaderText = "Id da tabela pai";
            dgvContaPagar.Columns[1].Visible = false;
            dgvContaPagar.Columns[2].HeaderText = "Conta";
            dgvContaPagar.Columns[3].HeaderText = "Descrição";
            dgvContaPagar.Columns[4].HeaderText = "Categoria";

            dgvContaPagar.Columns[5].HeaderText = GetCurrencySymbol() + " Restante";
            dgvContaPagar.Columns[5].DefaultCellStyle.Format = "C2";
            dgvContaPagar.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvContaPagar.Columns[6].HeaderText = GetCurrencySymbol() + " Realizado";
            dgvContaPagar.Columns[6].DefaultCellStyle.Format = "C2";
            dgvContaPagar.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvContaPagar.Columns[7].HeaderText = GetCurrencySymbol() + " Total";
            dgvContaPagar.Columns[7].DefaultCellStyle.Format = "C2";
            dgvContaPagar.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvContaPagar.Columns[8].HeaderText = "Qtd Compras";
            dgvContaPagar.Columns[8].ToolTipText = "Quantidade de Compras relacionadas a este item...";
            dgvContaPagar.Columns[9].HeaderText = "Data de Compra";
            dgvContaPagar.Columns[10].HeaderText = "Vencimento";
            dgvContaPagar.Columns[11].HeaderText = "Mês/Ano";
            dgvContaPagar.Columns[12].HeaderText = "Frequência";
            dgvContaPagar.Columns[13].HeaderText = "Tipo";
            dgvContaPagar.Columns[14].HeaderText = "Data de Pagamento";
            dgvContaPagar.Columns[15].HeaderText = "Pago?";
            dgvContaPagar.Columns[16].HeaderText = "Mensagem";
            dgvContaPagar.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvContaPagar.Columns[17].HeaderText = "Data de Criação";
            dgvContaPagar.Columns[17].Visible = false;
            dgvContaPagar.Columns[18].HeaderText = "Data de Alteração";
            dgvContaPagar.Columns[18].Visible = false;
            dgvContaPagar.Columns[19].Visible = false;
        }

        private void PreencheDataSourceContaReceber(IList<DgvVisualizarContaReceberDataSource> dataSourceOrderBy)
        {
            ConsolidateContaReceberListagem(dataSourceOrderBy);

            _dgvVisualizarContaReceberDataSource = dataSourceOrderBy;

            dgvContaReceber.DataSource = dataSourceOrderBy;
            dgvContaReceber.Columns[0].HeaderText = "Id";
            dgvContaReceber.Columns[0].Visible = false;

            dgvContaReceber.Columns[1].HeaderText = "Id da tabela pai";
            dgvContaReceber.Columns[1].Visible = false;

            dgvContaReceber.Columns[2].HeaderText = "Conta";

            dgvContaReceber.Columns[3].HeaderText = "Descrição";

            dgvContaReceber.Columns[4].HeaderText = "Categoria";

            dgvContaReceber.Columns[5].HeaderText = GetCurrencySymbol() + " Total";
            dgvContaReceber.Columns[5].DefaultCellStyle.Format = "C2";
            dgvContaReceber.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvContaReceber.Columns[6].HeaderText = GetCurrencySymbol() + " Valor Manipulado";
            dgvContaReceber.Columns[6].DefaultCellStyle.Format = "C2";
            dgvContaReceber.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvContaReceber.Columns[7].HeaderText = GetCurrencySymbol() + " Valor Total";
            dgvContaReceber.Columns[7].DefaultCellStyle.Format = "C2";
            dgvContaReceber.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContaReceber.Columns[7].Visible = false;

            dgvContaReceber.Columns[8].HeaderText = "Qtd Compras";
            dgvContaReceber.Columns[8].ToolTipText = "Quantidade de Compras relacionadas a este item...";
            dgvContaReceber.Columns[8].Visible = false;

            dgvContaReceber.Columns[9].HeaderText = "Data do Acordo";

            dgvContaReceber.Columns[10].HeaderText = "Vencimento";

            dgvContaReceber.Columns[11].HeaderText = "Mês/Ano";

            dgvContaReceber.Columns[12].HeaderText = "Frequência";

            dgvContaReceber.Columns[13].HeaderText = "Tipo";

            dgvContaReceber.Columns[14].HeaderText = "Data de Recebimento";

            dgvContaReceber.Columns[15].HeaderText = "Recebido?";

            dgvContaReceber.Columns[16].HeaderText = "Mensagem";
            dgvContaReceber.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvContaReceber.Columns[17].HeaderText = "Data de Criação";
            dgvContaReceber.Columns[17].Visible = false;

            dgvContaReceber.Columns[18].HeaderText = "Data de Alteração";
            dgvContaReceber.Columns[18].Visible = false;
        }

        private void ConsolidateContaPagarListagem(IList<DgvVisualizarContaPagarDataSource> dataSourceOrderBy)
        {
            #region TOTAL GERAL

            var quantidadeTotal = dataSourceOrderBy.Count();
            var valorTotal = Convert.ToDecimal(dataSourceOrderBy.Sum(x => x.Value));
            PreencheLabels(quantidadeTotal, valorTotal, lblContaPagarGridViewTotais, "Total: ");

            #endregion TOTAL GERAL

            #region TOTAL PAGO

            var quantidadeTotalPago = dataSourceOrderBy.Count(pay => pay.HasPay);
            var valorTotalPago = Convert
                .ToDecimal(dataSourceOrderBy
                .Where(pay => pay.HasPay)
                .Sum(x => x.Value));
            PreencheLabels(quantidadeTotalPago, valorTotalPago, lblContaPagarGridViewTotalPago, "Pago: ");

            #endregion TOTAL PAGO

            #region CARTÕES DE CRÉDITOS

            ConsolidateCreditCards(dataSourceOrderBy);

            #endregion CARTÕES DE CRÉDITOS
        }

        private void ConsolidateContaReceberListagem(IList<DgvVisualizarContaReceberDataSource> dataSourceOrderBy)
        {
            #region TOTAL GERAL

            var quantidadeTotal = dataSourceOrderBy.Count();
            var valorTotal = Convert.ToDecimal(dataSourceOrderBy.Sum(x => x.Value));
            PreencheLabels(quantidadeTotal, valorTotal, lblValorTotalContaReceber, "Total: ");

            #endregion TOTAL GERAL

            #region TOTAL RECEBIDO

            var quantidadeTotalPago = dataSourceOrderBy
                .Count(pay => pay.HasReceived);
            var valorTotalPago = Convert
                .ToDecimal(dataSourceOrderBy
                .Where(pay => pay.HasReceived)
                .Sum(x => x.Value));
            PreencheLabels(quantidadeTotalPago, valorTotalPago, lblValorRecebido, "Recebido: ");

            #endregion TOTAL RECEBIDO
        }

        private void ConsolidateCreditCards(IList<DgvVisualizarContaPagarDataSource> billToPayHist)
        {
            var getAccountsOnlyCreditCard = _accountRepository
                .GetAccountsOnlyCreditCard()
                .OrderBy(x => x.Name);

            string informacaoConsolidate = string.Empty;
            int contador = 0;

            foreach (var creditCard in getAccountsOnlyCreditCard)
            {
                var quantidadeRegistros = billToPayHist
                    .Count(creditCardFamily => creditCardFamily.Account == creditCard.Name);
                var totalValue = billToPayHist
                    .Where(creditCardFamily => creditCardFamily.Account == creditCard.Name)
                    .Sum(x => x.Value);
                var totalPay = billToPayHist
                    .Count(creditCardFamily => creditCardFamily.Account == creditCard.Name
                         && creditCardFamily.HasPay);
                var infoFistRegister = billToPayHist
                    .FirstOrDefault(creditCardFamily => creditCardFamily.Account == creditCard.Name
                         && creditCardFamily.HasPay);

                if (quantidadeRegistros > 0)
                {
                    informacaoConsolidate += string
                                .Concat(contador > 0 ? "\n" : string.Empty,
                                        creditCard.Name,
                                        ": ",
                                        quantidadeRegistros,
                                        " - ",
                                        GetCurrencySymbol() + " ",
                                        string.Format("{0:#,##0.00}",
                                        totalValue));

                    if (totalPay == quantidadeRegistros)
                    {
                        informacaoConsolidate = string.Concat(informacaoConsolidate, $" - Pagamento realizado em {infoFistRegister?.PayDay}");
                    }
                    contador++;
                }
            }

            lblGridViewCartaoCreditoFamilia.Text = informacaoConsolidate;
        }

        private void PreencheLabels(int quantidadeTotal, decimal valorTotal, Label lbl, string prefix)
        {
            lbl.Text = string
                            .Concat(prefix, quantidadeTotal, " - ", GetCurrencySymbol(), " ", string
                            .Format("{0:#,##0.00}", valorTotal));
        }

        private IList<DgvVisualizarContaPagarDataSource> MapSearchResultContaPagarToDataSource(SearchBillToPayOutput searchBillToPayOutput)
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
                if (item.Account == null)
                {
                    continue;
                }

                var account = _accountRepository
                    .GetAccountByName(item.Account!);

                if (account == null)
                {
                    continue;
                }

                item.AccountObject = account;

                dgvEfetuarPagamentoListagemDataSources.Add(item);
            }

            return dgvEfetuarPagamentoListagemDataSources;
        }

        private IList<DgvVisualizarContaReceberDataSource> MapSearchResultContaReceberToDataSource(SearchCashReceivableOutput search)
        {
            IList<DgvVisualizarContaReceberDataSource> dataGridViewDataSource = new List<DgvVisualizarContaReceberDataSource>();

            if (search.Output == null || search.Output.Data == null)
            {
                return dataGridViewDataSource;
            }

            var dados = search.Output.Data;

            var json = JsonConvert.SerializeObject(dados);

            var conversion = JsonConvert.DeserializeObject<IList<DgvVisualizarContaReceberDataSource>>(json);

            foreach (var item in conversion!)
            {
                dataGridViewDataSource.Add(item);
            }

            return dataGridViewDataSource;
        }

        private void DgvEfetuarPagamentoListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _ = Guid.TryParse(dgvContaPagar.Rows[e.RowIndex].Cells[0].Value.ToString(), out Guid identificadorContaPagar);
                var conta = dgvContaPagar.Rows[e.RowIndex].Cells[2].Value.ToString();
                var descricao = dgvContaPagar.Rows[e.RowIndex].Cells[3].Value.ToString();
                var valorOfDgv = dgvContaPagar.Rows[e.RowIndex].Cells[5].Value?.ToString()?.Replace("R$ ", "") ?? "0";
                var valor = Convert.ToDecimal(valorOfDgv);
                var mesAno = dgvContaPagar.Rows[e.RowIndex].Cells[8].Value.ToString();
                var additionalMessage = dgvContaPagar.Rows[e.RowIndex].Cells[13].Value?.ToString();

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
                Environment = Environment,
                AnoMes = DateUtils.GetYearMonthPortugueseByDateTime(DateTime.Now.AddMonths(-1))
            };

            frmPagamento.ShowDialog();
        }

        private async void CboEfetuarPagamentoCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboEfetuarPagamentoCategoria.Text != "Nenhum")
            {
                await CarregaContasApagar(false);

                var filterByCategory = _dgvEfetuarPagamentoListagemDataSource
                    .Where(x => x.Category == cboEfetuarPagamentoCategoria.Text)
                    .ToList();

                PreencheDataSourceContaPagar(filterByCategory);
            }
            else
            {
                if (!ehInitialization)
                {
                    await CarregaContasApagar();
                }
            }
        }

        private void TxtContaPagarValor_Enter(object sender, EventArgs e)
        {
            txtCadastroContaValue.Text = "";
        }

        private void TxtContaPagarValor_Leave(object sender, EventArgs e)
        {
            ValorContaPagarDigitadoTextBox = StringDecimalUtils
                .TranslateStringEmDecimal(txtCadastroContaValue.Text);

            txtCadastroContaValue.Text = StringDecimalUtils
                .TranslateValorEmStringDinheiro(txtCadastroContaValue.Text);
        }

        private void EditarRegistroSelecionado_DgvEfetuarPagamentoListagem_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvContaPagar.Rows[e.RowIndex].Cells[0].Selected = true;
                _ = Guid.TryParse(dgvContaPagar.Rows[e.RowIndex].Cells[0].Value.ToString(), out Guid identificadorContaPagar);

                if (identificadorContaPagar == Guid.Empty)
                {
                    MessageBox.Show("Não encontramos o Identificador da Conta pagar conseguir editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var editBillToPayViewModel = new EditBillToPayViewModel
                {
                    Id = identificadorContaPagar,
                    IdFixedInvoice = Convert.ToInt32(dgvContaPagar.Rows[e.RowIndex].Cells[1].Value?.ToString()),
                    Account = dgvContaPagar.Rows[e.RowIndex].Cells[2].Value?.ToString(),
                    Name = dgvContaPagar.Rows[e.RowIndex].Cells[3].Value?.ToString(),
                    Category = dgvContaPagar.Rows[e.RowIndex].Cells[4].Value?.ToString(),
                    Value = Convert.ToDecimal(RemoveCurrencySymbol(dgvContaPagar.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "0")),
                    PurchaseDate = DateUtils.GetDateTimeOfString(dgvContaPagar.Rows[e.RowIndex].Cells[9].Value?.ToString()),
                    DueDate = DateUtils.GetDateTimeOfString(dgvContaPagar.Rows[e.RowIndex].Cells[10].Value?.ToString())!.Value,
                    YearMonth = dgvContaPagar.Rows[e.RowIndex].Cells[11].Value?.ToString(),
                    Frequence = dgvContaPagar.Rows[e.RowIndex].Cells[12].Value?.ToString(),
                    RegistrationType = dgvContaPagar.Rows[e.RowIndex].Cells[13].Value?.ToString(),
                    PayDay = dgvContaPagar.Rows[e.RowIndex].Cells[14].Value?.ToString(),
                    HasPay = Convert.ToBoolean(dgvContaPagar.Rows[e.RowIndex].Cells[15].Value?.ToString()),
                    AdditionalMessage = dgvContaPagar.Rows[e.RowIndex].Cells[16].Value?.ToString(),
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

        private void DgvContaPagar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvContaPagar.Rows)
            {
                var account = _accountRepository.GetAccountByName(row?.Cells[2]?.Value?.ToString());

                SetColorRows(row,
                    ColorTranslator.FromHtml(account!.Colors!.BackgroundColorHexadecimal),
                    ColorTranslator.FromHtml(account!.Colors!.FonteColorHexadecimal));

                if (Convert.ToBoolean(row.Cells[15].Value))
                {
                    SetColorRows(row, Color.DarkGreen, Color.White);
                }

                var projection = row?.Cells[3]?.Value?.ToString().Contains("Projetado") ?? false;

                if (projection)
                {
                    SetColorRows(row, Color.LightGreen, Color.Black);
                }
            }
        }

        private void DgvCadastroContaPagar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            InformaLabel(dgvCadastroConta, lblTotalValueGridView, 7, false);

            foreach (DataGridViewRow row in dgvCadastroConta.Rows)
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
            decimal valorRestanteItensSelecionados = 0;
            decimal valorRealizadoItensSelecionados = 0;
            int quantidadeTotalItensSelecionados = dgvContaPagar.SelectedRows.Count;

            foreach (DataGridViewRow row in dgvContaPagar.SelectedRows)
            {
                bool isOKTotalValue = decimal.TryParse(row.Cells[7].Value.ToString(), out decimal totalValue);
                valorTotalItensSelecionados += isOKTotalValue ? totalValue : 0;

                bool isOKRemainingValue = decimal.TryParse(row.Cells[5].Value.ToString(), out decimal remainingValue);
                valorRestanteItensSelecionados += isOKRemainingValue ? remainingValue : 0;

                bool isOKCompletedValue = decimal.TryParse(row.Cells[6].Value.ToString(), out decimal completedValue);
                valorRealizadoItensSelecionados += isOKCompletedValue ? completedValue : 0;
            }

            lblValorTotalItensSelecionadoGrid.Text = string
                .Concat("Valor Total dos ", quantidadeTotalItensSelecionados, " itens selecionados: ", valorTotalItensSelecionados.ToString("C"));

            lblValorRestanteDosItensSelecionadosNoGrid.Text = string
                .Concat("Valor restante dos ", quantidadeTotalItensSelecionados, " itens selecionados: ", valorRestanteItensSelecionados.ToString("C"));

            lblValorRealizadoItensSelecionadosGrid.Text = string.
                Concat("Valor realizado dos ", quantidadeTotalItensSelecionados, " itens selecionados: ", valorRealizadoItensSelecionados.ToString("C"));
        }

        private void BtnDetalhesContas_Click(object sender, EventArgs e)
        {
            List<Guid> idsBillsToPay = new();
            List<int> idsFixedInvoices = new();
            var searchBillToPayViewModel = new SearchBillToPayViewModel();

            foreach (DataGridViewRow row in dgvContaPagar.SelectedRows)
            {
                _ = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid id);
                _ = int.TryParse(row.Cells[1].Value.ToString(), out int idFixedInvoice);

                idsBillsToPay.Add(id);
                idsFixedInvoices.Add(idFixedInvoice);
            }

            searchBillToPayViewModel.IdBillToPayRegistrations = idsFixedInvoices.ToArray();

            FrmExibirDetalhes frmExcluirDetalhes = new()
            {
                PostSearchBillToPayViewModel = searchBillToPayViewModel,
                Environment = Environment,
                CreditCard = _accountRepository.GetAccountsOnlyCreditCard()
            };

            frmExcluirDetalhes.ShowDialog();
        }

        private void DgvEfetuarPagamentoListagem_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void CboHabilitarDataCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (cboCadastroContaHabilitarDate.Checked)
            {
                dtpCadastroContaDate.Enabled = true;
            }
            else
            {
                dtpCadastroContaDate.Text = string.Empty;
                dtpCadastroContaDate.Enabled = false;
            }
        }

        private async void CboNaoEnviarMesAnoFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (cboNaoEnviarMesAnoFinal.Checked)
            {
                if (ckbCadastroContaConsideraMesmoMes.Checked)
                {
                    var result = MessageBox
                                        .Show("Você quer considerar o mesmo Mês/Ano inicial e final?",
                                        "E aí cara?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        cboCadastroContaFinallyMonthYear.SelectedItem = cboCadastroContaInititalMonthYear.SelectedItem;
                        cboCadastroContaFinallyMonthYear.Enabled = false;
                        ckbCadastroContaConsideraMesmoMes.Checked = false;

                    }
                }

                cboCadastroContaFinallyMonthYear.Enabled = false;
                cboCadastroContaFinallyMonthYear.Text = null;
            }
            else
            {
                cboCadastroContaFinallyMonthYear.Enabled = true;
                await PreencherComboBoxAnoMes();
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

        private void SetColorGrbTemplateContaPagar()
        {
            var accountComboBox = cboCadastroContaAccount.Text;

            if (accountComboBox.StartsWith("Cartão de Crédito"))
            {
                accountComboBox = accountComboBox.Split(" - ")[0];
            }

            var account = _accountRepository.GetAccountByName(accountComboBox);

            if (account == null)
            {
                return;
            }

            grbTemplateContaPagar.BackColor = ColorTranslator.FromHtml(account!.Colors!.BackgroundColorHexadecimal);
            grbTemplateContaPagar.ForeColor = ColorTranslator.FromHtml(account!.Colors!.FonteColorHexadecimal);
        }

        private void DtpContaPagarDataCompra_ValueChanged(object sender, EventArgs e)
        {
            var dayChoise = dtpCadastroContaDate.Value;

            cboCadastroContaBestDay.Text = dayChoise.Day.ToString();
        }

        private void CboContaPagarTipoConta_SelectedValueChanged(object sender, EventArgs e)
        {
            SetColorGrbTemplateContaPagar();
        }

        private async void BtnExcluirInitial_Click(object sender, EventArgs e)
        {
            var result = MessageBox
                .Show("Realmente deseja excluir os registros selecionados?", "Excluir?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _ = Task.Run(async () =>
                {
                    List<Guid> guidIds = new();

                    foreach (DataGridViewRow row in dgvContaPagar.SelectedRows)
                    {
                        bool isOk = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid guidId);

                        guidIds.Add(guidId);
                    }

                    BillToPayServices.Environment = Environment;
                    var output = await BillToPayServices.DeleteBillToPay(MapDeleteViewModel(guidIds));

                    TratamentoOutput(output);

                });
            }
            await Task.CompletedTask;
        }

        public static DeleteBillToPayViewModel MapDeleteViewModel(List<Guid> guidIds)
        {
            return new DeleteBillToPayViewModel()
            {
                Id = guidIds.ToArray(),
                JustUnpaid = true,
                DisableBillToPayRegistration = false
            };
        }

        private static void TratamentoOutput(DeleteBillToPayOutput result)
        {
            if (result.Output?.Status == OutputStatus.Success)
            {
                MessageBox.Show(result.Output.Message,
                    "Exclusão de registro realizado com sucesso.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
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

        private void DgvContaPagar_SelectionChanged(object sender, EventArgs e)
        {
            InformaLabel(dgvCadastroConta, lblTotalValueGridView, 7, true);
        }

        private static void InformaLabel(DataGridView dataGridView, Label label, int positionCellGridView, bool textSelected)
        {
            decimal totalValue = 0;
            int totalQuantity = dataGridView.SelectedRows.Count;

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                bool isOKTotalValue = decimal.TryParse(row.Cells[positionCellGridView].Value.ToString(), out decimal totalValueParsed);
                totalValue += isOKTotalValue ? totalValueParsed : 0;
            }

            label.Text = string
                .Concat("Valor Total dos ", totalQuantity, " itens ", textSelected ? "selecionados: " : "cadastrados: ", totalValue.ToString("C"));
        }

        private async void BtnBuscarContaReceber_Click(object sender, EventArgs e)
        {
            lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
            await CarregaContasAReceber();
        }

        private void RdbCadastroContaReceber_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCadastroContaReceber.Checked)
            {
                cboCadastroContaHabilitarDate.Text = "Habilitar Data do Acordo?";
                lblCadastroContaDataCompra.Text = "Data de Recebimento: ";
                lblCadastroContaBestDay.Text = "Melhor Dia de Recebimento: ";

                PreencherComboBoxContaReceberCategoriaAsync();
            }
            else
            {
                cboCadastroContaHabilitarDate.Text = "Habilitar Data da Compra?";
                lblCadastroContaDataCompra.Text = "Data de Compra: ";
                lblCadastroContaBestDay.Text = "Melhor Dia de Pagamento: ";

                PreencherComboBoxContaReceberCategoriaAsync();
            }
        }

        private async Task PreencherComboBoxContaReceberCategoriaAsync(string tabPageName = null, string categorySelected = null)
        {
            cboCadastroContaCategory.Items.Clear();
            cboEfetuarPagamentoCategoria.Items.Clear();

            CategoryServices.Environment = Environment;
            var resultSearch = await CategoryServices
                .SearchCategories(new SearchCategoryViewModel()
                {
                    AccountType = AccountType.ContaAReceber,
                    Enable = !cboBuscaTodasCategorias.Checked
                });

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

            cboCadastroContaCategory.Items.Add(first.Value);
            cboEfetuarPagamentoCategoria.Items.Add(first.Value);

            foreach (var item in categoriasContaPagarOrderBy)
            {
                cboCadastroContaCategory.Items.Add(item.Value);
                cboEfetuarPagamentoCategoria.Items.Add(item.Value);
            }

            if (categorySelected == null)
            {
                cboCadastroContaCategory.SelectedItem = first.Value;
                cboEfetuarPagamentoCategoria.SelectedItem = first.Value;
            }
            else
            {
                var theChoise = categoriasContaPagarOrderBy
                    .FirstOrDefault(x => x.Value == categorySelected);

                if (theChoise.Value.Length > 0)
                {
                    cboCadastroContaCategory.SelectedItem = theChoise.Value;
                    cboEfetuarPagamentoCategoria.SelectedItem = theChoise.Value;
                }
                else
                {
                    var dado = categoriasContaPagarOrderBy
                        .FirstOrDefault().Value;

                    cboCadastroContaCategory.SelectedItem = dado;
                    cboEfetuarPagamentoCategoria.SelectedItem = dado;
                }
            }
        }

        private void EditarRegistroSelecionadoContaReceber_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvContaReceber.Rows[e.RowIndex].Cells[0].Selected = true;
                _ = Guid.TryParse(dgvContaReceber.Rows[e.RowIndex].Cells[0].Value.ToString(), out Guid identificadorContaReceber);

                if (identificadorContaReceber == Guid.Empty)
                {
                    MessageBox.Show("Não encontramos o Identificador da Conta pagar conseguir editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dgvContaReceber == null)
                {
                    MessageBox.Show("Registro no gridview inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var editBillToPayViewModel = new EditCashReceivableViewModel
                {
                    Id = identificadorContaReceber,
                    IdCashReceivableRegistration = Convert.ToInt32(dgvContaReceber.Rows[e.RowIndex].Cells[1].Value?.ToString()),
                    Account = dgvContaReceber.Rows[e.RowIndex].Cells[2].Value?.ToString(),
                    Name = dgvContaReceber.Rows[e.RowIndex].Cells[3].Value?.ToString(),
                    Category = dgvContaReceber.Rows[e.RowIndex].Cells[4].Value?.ToString(),
                    Value = Convert.ToDecimal(RemoveCurrencySymbol(dgvContaReceber.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "0")),
                    ManipulatedValue = Convert.ToDecimal(RemoveCurrencySymbol(dgvContaReceber.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? "0")),
                    /*Cells[7] - TotalValue*/
                    /*Cells[8] - DetailsQuantity*/
                    AgreementDate = DateUtils.GetDateTimeOfString(dgvContaReceber.Rows[e.RowIndex].Cells[9].Value?.ToString()),
                    DueDate = DateUtils.GetDateTimeOfString(dgvContaReceber.Rows[e.RowIndex].Cells[10].Value?.ToString())!.Value,
                    YearMonth = dgvContaReceber.Rows[e.RowIndex].Cells[11].Value?.ToString(),
                    Frequence = dgvContaReceber.Rows[e.RowIndex].Cells[12].Value?.ToString(),
                    RegistrationType = dgvContaReceber.Rows[e.RowIndex].Cells[13].Value?.ToString(),
                    DateReceived = dgvContaReceber.Rows[e.RowIndex].Cells[14].Value?.ToString(),
                    HasReceived = Convert.ToBoolean(dgvContaReceber.Rows[e.RowIndex].Cells[15].Value?.ToString()),
                    AdditionalMessage = dgvContaReceber.Rows[e.RowIndex].Cells[16].Value?.ToString(),
                    /*Cells[17] - CreationDate*/
                    LastChangeDate = DateTime.Now /*Cells[18] - LastChangeDate*/
                    /*Cells[19] - Details*/
                    /*Cells[20] - AccountObject*/
                };

                FrmEdit frmPagamento = new()
                {
                    EditCashReceivableViewModel = editBillToPayViewModel,
                    Environment = Environment,
                    AccountType = AccountType.ContaAReceber
                };

                frmPagamento.ShowDialog();
            }
        }

        private void DgvContaReceber_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvContaReceber.Rows)
            {
                var account = _accountRepository.GetAccountByName(row?.Cells[2]?.Value?.ToString());

                SetColorRows(row,
                    ColorTranslator.FromHtml(account!.Colors!.BackgroundColorHexadecimal),
                    ColorTranslator.FromHtml(account!.Colors!.FonteColorHexadecimal));

                if (Convert.ToBoolean(row.Cells[15].Value))
                {
                    SetColorRows(row, Color.DarkGreen, Color.White);
                }
            }
        }

        private void BtnContaReceberExibirDetalhes_Click(object sender, EventArgs e)
        {
            List<Guid> idsContaReceber = new();
            List<int> idCashReceivableRegistrations = new();
            var searchContaReceberViewModel = new SearchCashReceivableViewModel();

            foreach (DataGridViewRow row in dgvContaReceber.SelectedRows)
            {
                _ = Guid.TryParse(row.Cells[0].Value.ToString(), out Guid id);
                _ = int.TryParse(row.Cells[1].Value.ToString(), out int idFixedInvoice);

                idsContaReceber.Add(id);
                idCashReceivableRegistrations.Add(idFixedInvoice);
            }

            searchContaReceberViewModel.IdCashReceivableRegistrations = idCashReceivableRegistrations.ToArray();

            FrmExibirDetalhes frmExcluirDetalhes = new()
            {
                PostSearchCashReceivableViewModel = searchContaReceberViewModel,
                Environment = Environment,
                CreditCard = _accountRepository.GetAccountsOnlyCreditCard()
            };

            frmExcluirDetalhes.ShowDialog();
        }

        private void DgvContaReceber_SelectionChange(object sender, EventArgs e)
        {
            decimal valorTotalItensSelecionados = 0;
            decimal valorManipuladoItensSelecionados = 0;
            decimal valorRealizadoItensSelecionados = 0;
            int quantidadeTotalItensSelecionados = dgvContaReceber.SelectedRows.Count;

            foreach (DataGridViewRow row in dgvContaReceber.SelectedRows)
            {
                bool isOKTotalValue = decimal.TryParse(row.Cells[5].Value.ToString(), out decimal totalValue);
                valorTotalItensSelecionados += isOKTotalValue ? totalValue : 0;

                bool isOKRemainingValue = decimal.TryParse(row.Cells[6].Value.ToString(), out decimal remainingValue);
                valorManipuladoItensSelecionados += isOKRemainingValue ? remainingValue : 0;

                bool isOKCompletedValue = decimal.TryParse(row.Cells[6].Value.ToString(), out decimal completedValue);
                valorRealizadoItensSelecionados += isOKCompletedValue ? completedValue : 0;
            }

            lblContaReceberTotalItensSelecionados.Text = string
                .Concat("Valor Total dos ", quantidadeTotalItensSelecionados, " itens selecionados: ", valorTotalItensSelecionados.ToString("C"));

            lblContaReceberValorRestanteItensSelecionados.Text = string
                .Concat("Valor Manipulado dos ", quantidadeTotalItensSelecionados, " itens selecionados: ", valorManipuladoItensSelecionados.ToString("C"));
        }

        private void CboBuscaTodasCategorias_CheckedChanged(object sender, EventArgs e)
        {
            if (cboBuscaTodasCategorias.Checked)
            {
                if (rdbCadastroContaPagar.Checked)
                {
                    PreencherComboBoxContaPagarCategoriaAsync();
                }
                else
                {
                    PreencherComboBoxContaReceberCategoriaAsync();
                }
            }
            else
            {
                if (rdbCadastroContaPagar.Checked)
                {
                    PreencherComboBoxContaPagarCategoriaAsync();
                }
                else
                {
                    PreencherComboBoxContaReceberCategoriaAsync();
                }
            }
        }

        private async void cboInitialAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboInitialAccount.Text != "Nenhum")
            {
                await CarregaContasApagar(false);

                var filterByAccount = _dgvEfetuarPagamentoListagemDataSource
                    .Where(x => x.Account == cboInitialAccount.Text.Split(" - ")[0])
                    .ToList();

                PreencheDataSourceContaPagar(filterByAccount);
            }
            else
            {
                if (!ehInitialization)
                {
                    await CarregaContasApagar();
                }
            }
        }

        private async void cboInitialCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            cboEfetuarPagamentoCategoria.Items.Clear();
            cboEfetuarPagamentoCategoria.Items.Add("Nenhum");
            cboEfetuarPagamentoCategoria.SelectedItem = "Nenhum";

            if (cboInitialCategory.Text != "Nenhum")
            {
                cboEfetuarPagamentoCategoria.Items.Clear();
                CategoryServices.Environment = Environment;
                var resultSearch = await CategoryServices
                    .SearchCategories(new SearchCategoryViewModel()
                    {
                        AccountType = AccountType.ContaAPagar,
                        Enable = cboBuscaTodasCategorias.Checked ? false : true
                    });

                Dictionary<int, string> subCategoriasContaPagar = new() { };

                int contSubCategory = 0;

                if (resultSearch.Categories != null)
                {
                    foreach (var item in resultSearch.Categories)
                    {
                        if (item.StartsWith(cboInitialCategory.Text))
                        {
                            if (contSubCategory == 0)
                            {
                                subCategoriasContaPagar.Add(contSubCategory, "Nenhum");
                                contSubCategory++;
                                subCategoriasContaPagar.Add(contSubCategory, item);
                            }
                            else
                            {
                                subCategoriasContaPagar.Add(contSubCategory, item);
                            }

                            contSubCategory++;
                        }
                    }
                }
                else
                {
                    subCategoriasContaPagar.Add(contSubCategory, "Nenhum");
                }

                var subCategoriasContaPagarOrderBy = subCategoriasContaPagar
                    .OrderBy(x => x.Value)
                    .Where(x => x.Key != 0)
                    .ToList();

                var first = subCategoriasContaPagar.FirstOrDefault(x => x.Key == 0);

                cboEfetuarPagamentoCategoria.Items.Add(first.Value);

                foreach (var item in subCategoriasContaPagarOrderBy)
                {
                    cboCadastroContaCategory.Items.Add(item.Value);
                    cboEfetuarPagamentoCategoria.Items.Add(item.Value);
                }
            }
        }

        /// <summary>
        /// Atualiza a UI após uma mudança de cultura
        /// </summary>
        private void RefreshUIAfterCultureChange()
        {
            // Atualiza os textos hardcoded da UI com as traduções
            UpdateUITexts();

            // Atualiza o rótulo de data de criação com o novo formato de data
            PreencherLabelDataCriacao();

            // Atualiza os rótulos do header com o novo formato de data
            lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);

            // Se houver dados carregados nas grid views, atualiza os valores exibidos
            if (_dgvEfetuarPagamentoListagemDataSource.Count > 0)
            {
                PreencheDataSourceContaPagar(_dgvEfetuarPagamentoListagemDataSource);
            }

            if (_dgvVisualizarContaReceberDataSource.Count > 0)
            {
                PreencheDataSourceContaReceber(_dgvVisualizarContaReceberDataSource);
            }

            if (_dgvVisuarEstudoFinanceiroDataSource.Count > 0)
            {
                PreecherDataGridViewEstudoFinanceiro(_dgvVisuarEstudoFinanceiroDataSource);
            }
        }

        /// <summary>
        /// Atualiza todos os textos da UI com a cultura selecionada
        /// </summary>
        private void UpdateUITexts()
        {
            string culture = StringDecimalUtils.CurrentCulture;

            // RadioButtons de ambiente
            rdbAmbienteLocal.Text = GetTranslation("Local", culture);
            rdbAmbienteHomologacao.Text = GetTranslation("Homologação", culture);
            rdbAmbienteProducao.Text = GetTranslation("Produção", culture);

            // Abas (Tab Pages)
            if (tbcInitial.TabPages.Count > 0)
            {
                tbcInitial.TabPages[0].Text = GetTranslation("Cadastro de Conta a Pagar", culture);
                if (tbcInitial.TabPages.Count > 1)
                    tbcInitial.TabPages[1].Text = GetTranslation("Efectuar Pagamento", culture);
                if (tbcInitial.TabPages.Count > 2)
                    tbcInitial.TabPages[2].Text = GetTranslation("Conta a Receber", culture);
                if (tbcInitial.TabPages.Count > 3)
                    tbcInitial.TabPages[3].Text = GetTranslation("Estudos Financeiros", culture);
            }

            // GroupBox de Cadastro
            grbTemplateContaPagar.Text = GetTranslation("Cadastro de Conta a Pagar", culture);
            grbCadastroContaHistorico.Text = GetTranslation("Histórico de Cadastros", culture);
            grbAlerta.Text = GetTranslation("Alerta", culture);

            // Labels do formulário
            lblCadastroContaDataCompra.Text = GetTranslation("Data de Compra: ", culture);
            lblCadastroContaBestDay.Text = GetTranslation("Melhor Dia de Pagamento: ", culture);
            lblCadastroContaDataCriacao.Text = GetTranslation("Data de Criação: ", culture);

            // Checkboxes
            cboCadastroContaHabilitarDate.Text = GetTranslation("Habilitar Data da Compra?", culture);
            cboNaoEnviarMesAnoFinal.Text = GetTranslation("Não enviar Mês/Ano Final?", culture);
            ckbCadastroContaConsideraMesmoMes.Text = GetTranslation("Considerar mesmo Mês/Ano?", culture);
            cboBuscaTodasCategorias.Text = GetTranslation("Buscar todas as categorias?", culture);
        }

        /// <summary>
        /// Traduz um texto da interface conforme a cultura selecionada
        /// </summary>
        private string GetTranslation(string textPT, string culture)
        {
            return culture switch
            {
                "es-ES" => TranslateToSpanish(textPT),
                "en-US" => TranslateToEnglish(textPT),
                "de-DE" => TranslateToGerman(textPT),
                "fr-FR" => TranslateToFrench(textPT),
                _ => textPT // Default to Portuguese
            };
        }

        private string TranslateToSpanish(string textPT)
        {
            return textPT switch
            {
                "Local" => "Local",
                "Homologação" => "Puesta en escena",
                "Produção" => "Producción",
                "Cadastro de Conta a Pagar" => "Registro de Factura a Pagar",
                "Efectuar Pagamento" => "Efectuar Pago",
                "Conta a Receber" => "Cuenta por Cobrar",
                "Estudos Financeiros" => "Estudios Financieros",
                "Histórico de Cadastros" => "Historial de Registros",
                "Alerta" => "Alerta",
                "Data de Compra: " => "Fecha de Compra: ",
                "Melhor Dia de Pagamento: " => "Mejor Día de Pago: ",
                "Data de Criação: " => "Fecha de Creación: ",
                "Habilitar Data da Compra?" => "¿Habilitar Fecha de Compra?",
                "Não enviar Mês/Ano Final?" => "¿No enviar Mes/Año Final?",
                "Considerar mesmo Mês/Ano?" => "¿Considerar el mismo Mes/Año?",
                "Buscar todas as categorias?" => "¿Buscar todas las categorías?",
                _ => textPT
            };
        }

        private string TranslateToEnglish(string textPT)
        {
            return textPT switch
            {
                "Local" => "Local",
                "Homologação" => "Staging",
                "Produção" => "Production",
                "Cadastro de Conta a Pagar" => "Bill To Pay Registration",
                "Efectuar Pagamento" => "Perform Payment",
                "Conta a Receber" => "Receivable Account",
                "Estudos Financeiros" => "Financial Studies",
                "Histórico de Cadastros" => "Registration History",
                "Alerta" => "Alert",
                "Data de Compra: " => "Purchase Date: ",
                "Melhor Dia de Pagamento: " => "Best Payment Day: ",
                "Data de Criação: " => "Creation Date: ",
                "Habilitar Data da Compra?" => "Enable Purchase Date?",
                "Não enviar Mês/Ano Final?" => "Do Not Send Final Month/Year?",
                "Considerar mesmo Mês/Ano?" => "Consider Same Month/Year?",
                "Buscar todas as categorias?" => "Search All Categories?",
                _ => textPT
            };
        }

        private string TranslateToGerman(string textPT)
        {
            return textPT switch
            {
                "Local" => "Lokal",
                "Homologação" => "Staging",
                "Produção" => "Produktion",
                "Cadastro de Conta a Pagar" => "Rechnungsregistrierung",
                "Efectuar Pagamento" => "Zahlung durchführen",
                "Conta a Receber" => "Forderungskonto",
                "Estudos Financeiros" => "Finanzielle Studien",
                "Histórico de Cadastros" => "Registrierungsverlauf",
                "Alerta" => "Warnung",
                "Data de Compra: " => "Kaufdatum: ",
                "Melhor Dia de Pagamento: " => "Bester Zahlungstag: ",
                "Data de Criação: " => "Erstellungsdatum: ",
                "Habilitar Data da Compra?" => "Kaufdatum aktivieren?",
                "Não enviar Mês/Ano Final?" => "Finalen Monat/Jahr nicht senden?",
                "Considerar mesmo Mês/Ano?" => "Denselben Monat/Jahresraum berücksichtigen?",
                "Buscar todas as categorias?" => "Alle Kategorien durchsuchen?",
                _ => textPT
            };
        }

        private string TranslateToFrench(string textPT)
        {
            return textPT switch
            {
                "Local" => "Local",
                "Homologação" => "Intermédiaire",
                "Produção" => "Production",
                "Cadastro de Conta a Pagar" => "Enregistrement de Facture à Payer",
                "Efectuar Pagamento" => "Effectuer le Paiement",
                "Conta a Receber" => "Compte Débiteur",
                "Estudos Financeiros" => "Études Financières",
                "Histórico de Cadastros" => "Historique d'Enregistrement",
                "Alerta" => "Alerte",
                "Data de Compra: " => "Date d'Achat: ",
                "Melhor Dia de Pagamento: " => "Meilleur Jour de Paiement: ",
                "Data de Criação: " => "Date de Création: ",
                "Habilitar Data da Compra?" => "Activer la Date d'Achat?",
                "Não enviar Mês/Ano Final?" => "Ne pas envoyer le Mois/Année final?",
                "Considerar mesmo Mês/Ano?" => "Considérer le même Mois/Année?",
                "Buscar todas as categorias?" => "Rechercher toutes les catégories?",
                _ => textPT
            };
        }

        private void cboCultura_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        /// <summary>
        /// Event handler para mudança de seleção de cultura
        /// </summary>
        private void cboCultura_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboCultura.SelectedItem != null)
            {
                CultureSelectorHelper.ChangeCulture(cboCultura);
                RefreshUIAfterCultureChange();
            }
        }
    }
}