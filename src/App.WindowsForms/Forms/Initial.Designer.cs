namespace App.Forms.Forms
{
    partial class Initial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Initial));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tbcInitial = new TabControl();
            tbpCadastroContaPagar = new TabPage();
            grbTemplateContaPagar = new GroupBox();
            rdbCadastroContaReceber = new RadioButton();
            rdbCadastroContaPagar = new RadioButton();
            cboCadastroContaHabilitarDate = new CheckBox();
            cboNaoEnviarMesAnoFinal = new CheckBox();
            btnEfetuarCadastroConta = new Button();
            dgvCadastroConta = new DataGridView();
            grbCadastroContaHistorico = new GroupBox();
            lblTotalValueGridView = new Label();
            lblCadastroContaDataCriacao = new Label();
            rtbCadastroContaMensagemAdicional = new RichTextBox();
            lblCadastroContaMensagemAdicional = new Label();
            cboCadastroContaRegistrationType = new ComboBox();
            lblCadastroContaTipoCadastro = new Label();
            cboCadastroContaFrequence = new ComboBox();
            lblCadastroContaFrequencia = new Label();
            cboCadastroContaBestDay = new ComboBox();
            lblCadastroContaBestDay = new Label();
            dtpCadastroContaDate = new DateTimePicker();
            lblCadastroContaDataCompra = new Label();
            txtCadastroContaValue = new TextBox();
            lblCadastroContaValor = new Label();
            lblCadastroContaNameDescription = new Label();
            cboCadastroContaFinallyMonthYear = new ComboBox();
            txtCadastroContaName = new TextBox();
            lblCadastroContaAnoMesFinal = new Label();
            lblCadastroContaCategory = new Label();
            ckbCadastroContaConsideraMesmoMes = new CheckBox();
            cboCadastroContaCategory = new ComboBox();
            cboCadastroContaInititalMonthYear = new ComboBox();
            lblCadastroContaTipoConta = new Label();
            lblCadastroContaAnoMesInicial = new Label();
            cboCadastroContaAccount = new ComboBox();
            tbpListarContaPagar = new TabPage();
            grbAlerta = new GroupBox();
            lblQtdItensParaFinalizarCadastro = new Label();
            lblEventRepeat = new Label();
            lblGridViewSelectedRowsCompleted = new Label();
            lblGridViewSelectedRowsRemainingValue = new Label();
            label1 = new Label();
            btnExcluirInitial = new Button();
            btnExibirDetalhes = new Button();
            lblEfetuarPagamentoItensSelecionadosDataGridView = new Label();
            lblContaPagarGridViewTotalPago = new Label();
            lblGridViewCartaoCreditoFamilia = new Label();
            lblContaPagarGridViewTotais = new Label();
            lblEfetuarPagamentoCategoria = new Label();
            cboEfetuarPagamentoCategoria = new ComboBox();
            lblEfetuarPagamentoInformativoDuploCliqueGrid = new Label();
            btnPagamentoAvulso = new Button();
            btnEfetuarPagamentoBuscar = new Button();
            lblEfetuarPagamentoAnoMes = new Label();
            cboAnoMesContaPagar = new ComboBox();
            dgvContaPagar = new DataGridView();
            tbpListarContaReceber = new TabPage();
            label2 = new Label();
            lblValorRecebido = new Label();
            lblValorTotalContaReceber = new Label();
            lblDgvDoubleClick = new Label();
            btnBuscarContaReceber = new Button();
            lblAnoMes = new Label();
            cboMesAnoContaReceber = new ComboBox();
            dgvContaReceber = new DataGridView();
            tbpEstudosFinanceiros = new TabPage();
            lblEstudoFinanceiroMesesSerAnalisado = new Label();
            cboEstudoFinanceiroMesesAnalises = new ComboBox();
            btnSearchMonthlyAverageAnalysis = new Button();
            dgvSearchMonthlyAverageAnalysis = new DataGridView();
            lblVersion = new Label();
            lblInfoHeader = new Label();
            rdbAmbienteLocal = new RadioButton();
            rdbAmbienteHomologacao = new RadioButton();
            rdbAmbienteProducao = new RadioButton();
            tbcInitial.SuspendLayout();
            tbpCadastroContaPagar.SuspendLayout();
            grbTemplateContaPagar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCadastroConta).BeginInit();
            grbCadastroContaHistorico.SuspendLayout();
            tbpListarContaPagar.SuspendLayout();
            grbAlerta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaPagar).BeginInit();
            tbpListarContaReceber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaReceber).BeginInit();
            tbpEstudosFinanceiros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchMonthlyAverageAnalysis).BeginInit();
            SuspendLayout();
            // 
            // tbcInitial
            // 
            tbcInitial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbcInitial.Controls.Add(tbpCadastroContaPagar);
            tbcInitial.Controls.Add(tbpListarContaPagar);
            tbcInitial.Controls.Add(tbpListarContaReceber);
            tbcInitial.Controls.Add(tbpEstudosFinanceiros);
            tbcInitial.Location = new Point(0, 21);
            tbcInitial.Name = "tbcInitial";
            tbcInitial.SelectedIndex = 0;
            tbcInitial.Size = new Size(1216, 529);
            tbcInitial.TabIndex = 14;
            tbcInitial.SelectedIndexChanged += TbcInitial_SelectedIndexChanged;
            // 
            // tbpCadastroContaPagar
            // 
            tbpCadastroContaPagar.Controls.Add(grbTemplateContaPagar);
            tbpCadastroContaPagar.Location = new Point(4, 24);
            tbpCadastroContaPagar.Name = "tbpCadastroContaPagar";
            tbpCadastroContaPagar.Padding = new Padding(3);
            tbpCadastroContaPagar.Size = new Size(1208, 501);
            tbpCadastroContaPagar.TabIndex = 0;
            tbpCadastroContaPagar.Text = "Cadastro de Contas";
            tbpCadastroContaPagar.UseVisualStyleBackColor = true;
            // 
            // grbTemplateContaPagar
            // 
            grbTemplateContaPagar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grbTemplateContaPagar.Controls.Add(rdbCadastroContaReceber);
            grbTemplateContaPagar.Controls.Add(rdbCadastroContaPagar);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaHabilitarDate);
            grbTemplateContaPagar.Controls.Add(cboNaoEnviarMesAnoFinal);
            grbTemplateContaPagar.Controls.Add(btnEfetuarCadastroConta);
            grbTemplateContaPagar.Controls.Add(dgvCadastroConta);
            grbTemplateContaPagar.Controls.Add(grbCadastroContaHistorico);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaDataCriacao);
            grbTemplateContaPagar.Controls.Add(rtbCadastroContaMensagemAdicional);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaMensagemAdicional);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaRegistrationType);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaTipoCadastro);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaFrequence);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaFrequencia);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaBestDay);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaBestDay);
            grbTemplateContaPagar.Controls.Add(dtpCadastroContaDate);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaDataCompra);
            grbTemplateContaPagar.Controls.Add(txtCadastroContaValue);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaValor);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaNameDescription);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaFinallyMonthYear);
            grbTemplateContaPagar.Controls.Add(txtCadastroContaName);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaAnoMesFinal);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaCategory);
            grbTemplateContaPagar.Controls.Add(ckbCadastroContaConsideraMesmoMes);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaCategory);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaInititalMonthYear);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaTipoConta);
            grbTemplateContaPagar.Controls.Add(lblCadastroContaAnoMesInicial);
            grbTemplateContaPagar.Controls.Add(cboCadastroContaAccount);
            grbTemplateContaPagar.Location = new Point(16, 6);
            grbTemplateContaPagar.Name = "grbTemplateContaPagar";
            grbTemplateContaPagar.Size = new Size(1173, 487);
            grbTemplateContaPagar.TabIndex = 15;
            grbTemplateContaPagar.TabStop = false;
            grbTemplateContaPagar.Text = "Cadastro de Contas Pagar/Receber";
            // 
            // rdbCadastroContaReceber
            // 
            rdbCadastroContaReceber.AutoSize = true;
            rdbCadastroContaReceber.Location = new Point(116, 22);
            rdbCadastroContaReceber.Name = "rdbCadastroContaReceber";
            rdbCadastroContaReceber.Size = new Size(111, 19);
            rdbCadastroContaReceber.TabIndex = 40;
            rdbCadastroContaReceber.TabStop = true;
            rdbCadastroContaReceber.Text = "Conta a Receber";
            rdbCadastroContaReceber.UseVisualStyleBackColor = true;
            rdbCadastroContaReceber.CheckedChanged += RdbCadastroContaReceber_CheckedChanged;
            // 
            // rdbCadastroContaPagar
            // 
            rdbCadastroContaPagar.AutoSize = true;
            rdbCadastroContaPagar.Location = new Point(13, 22);
            rdbCadastroContaPagar.Name = "rdbCadastroContaPagar";
            rdbCadastroContaPagar.Size = new Size(99, 19);
            rdbCadastroContaPagar.TabIndex = 39;
            rdbCadastroContaPagar.Text = "Conta a Pagar";
            rdbCadastroContaPagar.UseVisualStyleBackColor = true;
            // 
            // cboCadastroContaHabilitarDate
            // 
            cboCadastroContaHabilitarDate.AutoSize = true;
            cboCadastroContaHabilitarDate.Checked = true;
            cboCadastroContaHabilitarDate.CheckState = CheckState.Checked;
            cboCadastroContaHabilitarDate.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboCadastroContaHabilitarDate.Location = new Point(728, 60);
            cboCadastroContaHabilitarDate.Name = "cboCadastroContaHabilitarDate";
            cboCadastroContaHabilitarDate.Size = new Size(161, 17);
            cboCadastroContaHabilitarDate.TabIndex = 37;
            cboCadastroContaHabilitarDate.Text = "Habilitar Data de Compra?";
            cboCadastroContaHabilitarDate.UseVisualStyleBackColor = true;
            cboCadastroContaHabilitarDate.CheckedChanged += CboHabilitarDataCompra_CheckedChanged;
            // 
            // cboNaoEnviarMesAnoFinal
            // 
            cboNaoEnviarMesAnoFinal.AutoSize = true;
            cboNaoEnviarMesAnoFinal.Location = new Point(283, 214);
            cboNaoEnviarMesAnoFinal.Name = "cboNaoEnviarMesAnoFinal";
            cboNaoEnviarMesAnoFinal.Size = new Size(166, 19);
            cboNaoEnviarMesAnoFinal.TabIndex = 30;
            cboNaoEnviarMesAnoFinal.Text = "Não Enviar Ano/Mês Final!";
            cboNaoEnviarMesAnoFinal.UseVisualStyleBackColor = true;
            cboNaoEnviarMesAnoFinal.CheckedChanged += CboNaoEnviarMesAnoFinal_CheckedChanged;
            // 
            // btnEfetuarCadastroConta
            // 
            btnEfetuarCadastroConta.AutoSize = true;
            btnEfetuarCadastroConta.BackColor = Color.SeaGreen;
            btnEfetuarCadastroConta.FlatStyle = FlatStyle.System;
            btnEfetuarCadastroConta.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEfetuarCadastroConta.Location = new Point(960, 187);
            btnEfetuarCadastroConta.Name = "btnEfetuarCadastroConta";
            btnEfetuarCadastroConta.Size = new Size(176, 34);
            btnEfetuarCadastroConta.TabIndex = 29;
            btnEfetuarCadastroConta.Text = "Efetuar Cadastro";
            btnEfetuarCadastroConta.UseVisualStyleBackColor = false;
            btnEfetuarCadastroConta.Click += BtnEfetuarCadastroConta_Click;
            // 
            // dgvCadastroConta
            // 
            dgvCadastroConta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCadastroConta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvCadastroConta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvCadastroConta.BackgroundColor = SystemColors.AppWorkspace;
            dgvCadastroConta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCadastroConta.Location = new Point(25, 275);
            dgvCadastroConta.Name = "dgvCadastroConta";
            dgvCadastroConta.RowTemplate.Height = 25;
            dgvCadastroConta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCadastroConta.Size = new Size(1128, 200);
            dgvCadastroConta.TabIndex = 15;
            dgvCadastroConta.RowsAdded += DgvCadastroContaPagar_RowsAdded;
            dgvCadastroConta.SelectionChanged += DgvContaPagar_SelectionChanged;
            // 
            // grbCadastroContaHistorico
            // 
            grbCadastroContaHistorico.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grbCadastroContaHistorico.Controls.Add(lblTotalValueGridView);
            grbCadastroContaHistorico.Location = new Point(8, 240);
            grbCadastroContaHistorico.Name = "grbCadastroContaHistorico";
            grbCadastroContaHistorico.Size = new Size(1159, 241);
            grbCadastroContaHistorico.TabIndex = 28;
            grbCadastroContaHistorico.TabStop = false;
            grbCadastroContaHistorico.Text = "Últimos cadastros realizados...";
            // 
            // lblTotalValueGridView
            // 
            lblTotalValueGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalValueGridView.AutoSize = true;
            lblTotalValueGridView.Location = new Point(833, 17);
            lblTotalValueGridView.Name = "lblTotalValueGridView";
            lblTotalValueGridView.RightToLeft = RightToLeft.Yes;
            lblTotalValueGridView.Size = new Size(312, 15);
            lblTotalValueGridView.TabIndex = 39;
            lblTotalValueGridView.Text = "Valor Total dos 900 itens cadastrados abaixo: R$ 100.400,00";
            lblTotalValueGridView.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCadastroContaDataCriacao
            // 
            lblCadastroContaDataCriacao.AutoSize = true;
            lblCadastroContaDataCriacao.Location = new Point(940, 159);
            lblCadastroContaDataCriacao.Name = "lblCadastroContaDataCriacao";
            lblCadastroContaDataCriacao.Size = new Size(213, 15);
            lblCadastroContaDataCriacao.TabIndex = 27;
            lblCadastroContaDataCriacao.Text = "Data de Criação: 15/03/1995 às 05:35:01";
            // 
            // rtbCadastroContaMensagemAdicional
            // 
            rtbCadastroContaMensagemAdicional.Location = new Point(925, 48);
            rtbCadastroContaMensagemAdicional.Name = "rtbCadastroContaMensagemAdicional";
            rtbCadastroContaMensagemAdicional.Size = new Size(242, 96);
            rtbCadastroContaMensagemAdicional.TabIndex = 26;
            rtbCadastroContaMensagemAdicional.Text = "";
            // 
            // lblCadastroContaMensagemAdicional
            // 
            lblCadastroContaMensagemAdicional.AutoSize = true;
            lblCadastroContaMensagemAdicional.Location = new Point(922, 30);
            lblCadastroContaMensagemAdicional.Name = "lblCadastroContaMensagemAdicional";
            lblCadastroContaMensagemAdicional.Size = new Size(122, 15);
            lblCadastroContaMensagemAdicional.TabIndex = 24;
            lblCadastroContaMensagemAdicional.Text = "Mensagem Adicional:";
            // 
            // cboCadastroContaRegistrationType
            // 
            cboCadastroContaRegistrationType.FormattingEnabled = true;
            cboCadastroContaRegistrationType.Location = new Point(652, 195);
            cboCadastroContaRegistrationType.Name = "cboCadastroContaRegistrationType";
            cboCadastroContaRegistrationType.Size = new Size(204, 23);
            cboCadastroContaRegistrationType.TabIndex = 23;
            // 
            // lblCadastroContaTipoCadastro
            // 
            lblCadastroContaTipoCadastro.AutoSize = true;
            lblCadastroContaTipoCadastro.Location = new Point(547, 198);
            lblCadastroContaTipoCadastro.Name = "lblCadastroContaTipoCadastro";
            lblCadastroContaTipoCadastro.Size = new Size(99, 15);
            lblCadastroContaTipoCadastro.TabIndex = 22;
            lblCadastroContaTipoCadastro.Text = "Tipo de Cadastro:";
            // 
            // cboCadastroContaFrequence
            // 
            cboCadastroContaFrequence.FormattingEnabled = true;
            cboCadastroContaFrequence.Location = new Point(652, 157);
            cboCadastroContaFrequence.Name = "cboCadastroContaFrequence";
            cboCadastroContaFrequence.Size = new Size(161, 23);
            cboCadastroContaFrequence.TabIndex = 21;
            // 
            // lblCadastroContaFrequencia
            // 
            lblCadastroContaFrequencia.AutoSize = true;
            lblCadastroContaFrequencia.Location = new Point(578, 160);
            lblCadastroContaFrequencia.Name = "lblCadastroContaFrequencia";
            lblCadastroContaFrequencia.Size = new Size(68, 15);
            lblCadastroContaFrequencia.TabIndex = 20;
            lblCadastroContaFrequencia.Text = "Frequência:";
            // 
            // cboCadastroContaBestDay
            // 
            cboCadastroContaBestDay.BackColor = SystemColors.Window;
            cboCadastroContaBestDay.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cboCadastroContaBestDay.FormatString = "N0";
            cboCadastroContaBestDay.FormattingEnabled = true;
            cboCadastroContaBestDay.Location = new Point(656, 119);
            cboCadastroContaBestDay.Name = "cboCadastroContaBestDay";
            cboCadastroContaBestDay.Size = new Size(62, 27);
            cboCadastroContaBestDay.TabIndex = 19;
            // 
            // lblCadastroContaBestDay
            // 
            lblCadastroContaBestDay.AutoSize = true;
            lblCadastroContaBestDay.Location = new Point(499, 122);
            lblCadastroContaBestDay.Name = "lblCadastroContaBestDay";
            lblCadastroContaBestDay.Size = new Size(147, 15);
            lblCadastroContaBestDay.TabIndex = 18;
            lblCadastroContaBestDay.Text = "Melhor dia de Pagamento:";
            // 
            // dtpCadastroContaDate
            // 
            dtpCadastroContaDate.Location = new Point(676, 83);
            dtpCadastroContaDate.Name = "dtpCadastroContaDate";
            dtpCadastroContaDate.Size = new Size(237, 23);
            dtpCadastroContaDate.TabIndex = 17;
            dtpCadastroContaDate.ValueChanged += DtpContaPagarDataCompra_ValueChanged;
            // 
            // lblCadastroContaDataCompra
            // 
            lblCadastroContaDataCompra.AutoSize = true;
            lblCadastroContaDataCompra.Location = new Point(553, 89);
            lblCadastroContaDataCompra.Name = "lblCadastroContaDataCompra";
            lblCadastroContaDataCompra.Size = new Size(96, 15);
            lblCadastroContaDataCompra.TabIndex = 16;
            lblCadastroContaDataCompra.Text = "Data da Compra:";
            // 
            // txtCadastroContaValue
            // 
            txtCadastroContaValue.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtCadastroContaValue.ForeColor = Color.OrangeRed;
            txtCadastroContaValue.Location = new Point(652, 27);
            txtCadastroContaValue.Name = "txtCadastroContaValue";
            txtCadastroContaValue.Size = new Size(133, 27);
            txtCadastroContaValue.TabIndex = 13;
            txtCadastroContaValue.TextAlign = HorizontalAlignment.Right;
            txtCadastroContaValue.Enter += TxtContaPagarValor_Enter;
            txtCadastroContaValue.Leave += TxtContaPagarValor_Leave;
            // 
            // lblCadastroContaValor
            // 
            lblCadastroContaValor.AutoSize = true;
            lblCadastroContaValor.Location = new Point(594, 30);
            lblCadastroContaValor.Name = "lblCadastroContaValor";
            lblCadastroContaValor.Size = new Size(52, 15);
            lblCadastroContaValor.TabIndex = 12;
            lblCadastroContaValor.Text = "Valor R$:";
            // 
            // lblCadastroContaNameDescription
            // 
            lblCadastroContaNameDescription.AutoSize = true;
            lblCadastroContaNameDescription.Location = new Point(11, 50);
            lblCadastroContaNameDescription.Name = "lblCadastroContaNameDescription";
            lblCadastroContaNameDescription.Size = new Size(99, 15);
            lblCadastroContaNameDescription.TabIndex = 0;
            lblCadastroContaNameDescription.Text = "Nome/Descrição:";
            // 
            // cboCadastroContaFinallyMonthYear
            // 
            cboCadastroContaFinallyMonthYear.FormattingEnabled = true;
            cboCadastroContaFinallyMonthYear.Location = new Point(116, 202);
            cboCadastroContaFinallyMonthYear.Name = "cboCadastroContaFinallyMonthYear";
            cboCadastroContaFinallyMonthYear.Size = new Size(161, 23);
            cboCadastroContaFinallyMonthYear.TabIndex = 11;
            // 
            // txtCadastroContaName
            // 
            txtCadastroContaName.Location = new Point(116, 47);
            txtCadastroContaName.Name = "txtCadastroContaName";
            txtCadastroContaName.Size = new Size(445, 23);
            txtCadastroContaName.TabIndex = 1;
            // 
            // lblCadastroContaAnoMesFinal
            // 
            lblCadastroContaAnoMesFinal.AutoSize = true;
            lblCadastroContaAnoMesFinal.Location = new Point(23, 205);
            lblCadastroContaAnoMesFinal.Name = "lblCadastroContaAnoMesFinal";
            lblCadastroContaAnoMesFinal.Size = new Size(87, 15);
            lblCadastroContaAnoMesFinal.TabIndex = 10;
            lblCadastroContaAnoMesFinal.Text = "Ano/Mês Final:";
            // 
            // lblCadastroContaCategory
            // 
            lblCadastroContaCategory.AutoSize = true;
            lblCadastroContaCategory.Location = new Point(49, 87);
            lblCadastroContaCategory.Name = "lblCadastroContaCategory";
            lblCadastroContaCategory.Size = new Size(61, 15);
            lblCadastroContaCategory.TabIndex = 2;
            lblCadastroContaCategory.Text = "Categoria:";
            // 
            // ckbCadastroContaConsideraMesmoMes
            // 
            ckbCadastroContaConsideraMesmoMes.AutoSize = true;
            ckbCadastroContaConsideraMesmoMes.Checked = true;
            ckbCadastroContaConsideraMesmoMes.CheckState = CheckState.Checked;
            ckbCadastroContaConsideraMesmoMes.Location = new Point(283, 174);
            ckbCadastroContaConsideraMesmoMes.Name = "ckbCadastroContaConsideraMesmoMes";
            ckbCadastroContaConsideraMesmoMes.Size = new Size(124, 34);
            ckbCadastroContaConsideraMesmoMes.TabIndex = 9;
            ckbCadastroContaConsideraMesmoMes.Text = "Considera como \r\nMês Inicial e Final?";
            ckbCadastroContaConsideraMesmoMes.UseVisualStyleBackColor = true;
            ckbCadastroContaConsideraMesmoMes.CheckedChanged += CkbContaPagarConsideraMesmoMes_CheckedChanged;
            // 
            // cboCadastroContaCategory
            // 
            cboCadastroContaCategory.FormattingEnabled = true;
            cboCadastroContaCategory.Location = new Point(116, 84);
            cboCadastroContaCategory.Name = "cboCadastroContaCategory";
            cboCadastroContaCategory.Size = new Size(263, 23);
            cboCadastroContaCategory.TabIndex = 3;
            // 
            // cboCadastroContaInititalMonthYear
            // 
            cboCadastroContaInititalMonthYear.FormattingEnabled = true;
            cboCadastroContaInititalMonthYear.Location = new Point(116, 166);
            cboCadastroContaInititalMonthYear.Name = "cboCadastroContaInititalMonthYear";
            cboCadastroContaInititalMonthYear.Size = new Size(161, 23);
            cboCadastroContaInititalMonthYear.TabIndex = 8;
            cboCadastroContaInititalMonthYear.SelectedValueChanged += CboContaPagarAnoMesInicial_SelectedValueChanged;
            cboCadastroContaInititalMonthYear.Leave += CboContaPagarAnoMesInicial_Leave;
            // 
            // lblCadastroContaTipoConta
            // 
            lblCadastroContaTipoConta.AutoSize = true;
            lblCadastroContaTipoConta.Location = new Point(28, 126);
            lblCadastroContaTipoConta.Name = "lblCadastroContaTipoConta";
            lblCadastroContaTipoConta.Size = new Size(42, 15);
            lblCadastroContaTipoConta.TabIndex = 4;
            lblCadastroContaTipoConta.Text = "Conta:";
            // 
            // lblCadastroContaAnoMesInicial
            // 
            lblCadastroContaAnoMesInicial.AutoSize = true;
            lblCadastroContaAnoMesInicial.Location = new Point(19, 169);
            lblCadastroContaAnoMesInicial.Name = "lblCadastroContaAnoMesInicial";
            lblCadastroContaAnoMesInicial.Size = new Size(93, 15);
            lblCadastroContaAnoMesInicial.TabIndex = 7;
            lblCadastroContaAnoMesInicial.Text = "Ano/Mês Inicial:";
            // 
            // cboCadastroContaAccount
            // 
            cboCadastroContaAccount.FormattingEnabled = true;
            cboCadastroContaAccount.Location = new Point(76, 123);
            cboCadastroContaAccount.Name = "cboCadastroContaAccount";
            cboCadastroContaAccount.Size = new Size(384, 23);
            cboCadastroContaAccount.TabIndex = 5;
            cboCadastroContaAccount.SelectedValueChanged += CboContaPagarTipoConta_SelectedValueChanged;
            // 
            // tbpListarContaPagar
            // 
            tbpListarContaPagar.Controls.Add(grbAlerta);
            tbpListarContaPagar.Controls.Add(lblGridViewSelectedRowsCompleted);
            tbpListarContaPagar.Controls.Add(lblGridViewSelectedRowsRemainingValue);
            tbpListarContaPagar.Controls.Add(label1);
            tbpListarContaPagar.Controls.Add(btnExcluirInitial);
            tbpListarContaPagar.Controls.Add(btnExibirDetalhes);
            tbpListarContaPagar.Controls.Add(lblEfetuarPagamentoItensSelecionadosDataGridView);
            tbpListarContaPagar.Controls.Add(lblContaPagarGridViewTotalPago);
            tbpListarContaPagar.Controls.Add(lblGridViewCartaoCreditoFamilia);
            tbpListarContaPagar.Controls.Add(lblContaPagarGridViewTotais);
            tbpListarContaPagar.Controls.Add(lblEfetuarPagamentoCategoria);
            tbpListarContaPagar.Controls.Add(cboEfetuarPagamentoCategoria);
            tbpListarContaPagar.Controls.Add(lblEfetuarPagamentoInformativoDuploCliqueGrid);
            tbpListarContaPagar.Controls.Add(btnPagamentoAvulso);
            tbpListarContaPagar.Controls.Add(btnEfetuarPagamentoBuscar);
            tbpListarContaPagar.Controls.Add(lblEfetuarPagamentoAnoMes);
            tbpListarContaPagar.Controls.Add(cboAnoMesContaPagar);
            tbpListarContaPagar.Controls.Add(dgvContaPagar);
            tbpListarContaPagar.Location = new Point(4, 24);
            tbpListarContaPagar.Name = "tbpListarContaPagar";
            tbpListarContaPagar.Size = new Size(1208, 501);
            tbpListarContaPagar.TabIndex = 2;
            tbpListarContaPagar.Text = "Contas a Pagar";
            tbpListarContaPagar.UseVisualStyleBackColor = true;
            // 
            // grbAlerta
            // 
            grbAlerta.Controls.Add(lblQtdItensParaFinalizarCadastro);
            grbAlerta.Controls.Add(lblEventRepeat);
            grbAlerta.Location = new Point(840, 88);
            grbAlerta.Name = "grbAlerta";
            grbAlerta.Size = new Size(363, 51);
            grbAlerta.TabIndex = 23;
            grbAlerta.TabStop = false;
            grbAlerta.Text = "Alertas";
            grbAlerta.Visible = false;
            // 
            // lblQtdItensParaFinalizarCadastro
            // 
            lblQtdItensParaFinalizarCadastro.AutoSize = true;
            lblQtdItensParaFinalizarCadastro.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblQtdItensParaFinalizarCadastro.ForeColor = Color.OrangeRed;
            lblQtdItensParaFinalizarCadastro.Location = new Point(6, 14);
            lblQtdItensParaFinalizarCadastro.Name = "lblQtdItensParaFinalizarCadastro";
            lblQtdItensParaFinalizarCadastro.Size = new Size(330, 17);
            lblQtdItensParaFinalizarCadastro.TabIndex = 21;
            lblQtdItensParaFinalizarCadastro.Text = "Existem 900 itens para serem finalizados o cadastro.";
            lblQtdItensParaFinalizarCadastro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEventRepeat
            // 
            lblEventRepeat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEventRepeat.AutoSize = true;
            lblEventRepeat.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblEventRepeat.ForeColor = SystemColors.ButtonShadow;
            lblEventRepeat.Location = new Point(6, 31);
            lblEventRepeat.Name = "lblEventRepeat";
            lblEventRepeat.Size = new Size(351, 12);
            lblEventRepeat.TabIndex = 22;
            lblEventRepeat.Text = "A cada 10 segundo(s) é efetuado uma consulta. Evento Repetido: 1000x até o momento.";
            lblEventRepeat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGridViewSelectedRowsCompleted
            // 
            lblGridViewSelectedRowsCompleted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGridViewSelectedRowsCompleted.AutoSize = true;
            lblGridViewSelectedRowsCompleted.Location = new Point(899, 73);
            lblGridViewSelectedRowsCompleted.Name = "lblGridViewSelectedRowsCompleted";
            lblGridViewSelectedRowsCompleted.RightToLeft = RightToLeft.Yes;
            lblGridViewSelectedRowsCompleted.Size = new Size(304, 15);
            lblGridViewSelectedRowsCompleted.TabIndex = 20;
            lblGridViewSelectedRowsCompleted.Text = "Valor Realizado dos 900 itens selecionados: R$ 100.400,00";
            lblGridViewSelectedRowsCompleted.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGridViewSelectedRowsRemainingValue
            // 
            lblGridViewSelectedRowsRemainingValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGridViewSelectedRowsRemainingValue.AutoSize = true;
            lblGridViewSelectedRowsRemainingValue.Location = new Point(904, 58);
            lblGridViewSelectedRowsRemainingValue.Name = "lblGridViewSelectedRowsRemainingValue";
            lblGridViewSelectedRowsRemainingValue.RightToLeft = RightToLeft.Yes;
            lblGridViewSelectedRowsRemainingValue.Size = new Size(299, 15);
            lblGridViewSelectedRowsRemainingValue.TabIndex = 19;
            lblGridViewSelectedRowsRemainingValue.Text = "Valor Restante dos 900 itens selecionados: R$ 100.400,00";
            lblGridViewSelectedRowsRemainingValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonShadow;
            label1.Location = new Point(10, 112);
            label1.Name = "label1";
            label1.Size = new Size(523, 15);
            label1.TabIndex = 18;
            label1.Text = "Ao efetuar clique único com botão direito na linha do grid será aberto a tela de edição do registro.\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnExcluirInitial
            // 
            btnExcluirInitial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExcluirInitial.BackColor = Color.IndianRed;
            btnExcluirInitial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExcluirInitial.ForeColor = SystemColors.ButtonFace;
            btnExcluirInitial.Location = new Point(1031, 4);
            btnExcluirInitial.Name = "btnExcluirInitial";
            btnExcluirInitial.Size = new Size(172, 38);
            btnExcluirInitial.TabIndex = 17;
            btnExcluirInitial.Text = "Excluir Registro(s)";
            btnExcluirInitial.UseVisualStyleBackColor = false;
            btnExcluirInitial.Click += BtnExcluirInitial_Click;
            // 
            // btnExibirDetalhes
            // 
            btnExibirDetalhes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExibirDetalhes.BackColor = Color.Teal;
            btnExibirDetalhes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExibirDetalhes.ForeColor = SystemColors.ButtonFace;
            btnExibirDetalhes.Location = new Point(853, 4);
            btnExibirDetalhes.Name = "btnExibirDetalhes";
            btnExibirDetalhes.Size = new Size(172, 38);
            btnExibirDetalhes.TabIndex = 16;
            btnExibirDetalhes.Text = "Exibir Detalhe(s)";
            btnExibirDetalhes.UseVisualStyleBackColor = false;
            btnExibirDetalhes.Click += BtnDetalhesContas_Click;
            // 
            // lblEfetuarPagamentoItensSelecionadosDataGridView
            // 
            lblEfetuarPagamentoItensSelecionadosDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEfetuarPagamentoItensSelecionadosDataGridView.AutoSize = true;
            lblEfetuarPagamentoItensSelecionadosDataGridView.Location = new Point(924, 43);
            lblEfetuarPagamentoItensSelecionadosDataGridView.Name = "lblEfetuarPagamentoItensSelecionadosDataGridView";
            lblEfetuarPagamentoItensSelecionadosDataGridView.RightToLeft = RightToLeft.Yes;
            lblEfetuarPagamentoItensSelecionadosDataGridView.Size = new Size(279, 15);
            lblEfetuarPagamentoItensSelecionadosDataGridView.TabIndex = 15;
            lblEfetuarPagamentoItensSelecionadosDataGridView.Text = "Valor Total dos 900 itens selecionados: R$ 100.400,00";
            lblEfetuarPagamentoItensSelecionadosDataGridView.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblContaPagarGridViewTotalPago
            // 
            lblContaPagarGridViewTotalPago.AutoSize = true;
            lblContaPagarGridViewTotalPago.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblContaPagarGridViewTotalPago.ForeColor = Color.Green;
            lblContaPagarGridViewTotalPago.Location = new Point(10, 73);
            lblContaPagarGridViewTotalPago.Name = "lblContaPagarGridViewTotalPago";
            lblContaPagarGridViewTotalPago.Size = new Size(164, 17);
            lblContaPagarGridViewTotalPago.TabIndex = 13;
            lblContaPagarGridViewTotalPago.Text = "Pago: 100 - R$ 100.000,00";
            // 
            // lblGridViewCartaoCreditoFamilia
            // 
            lblGridViewCartaoCreditoFamilia.AutoSize = true;
            lblGridViewCartaoCreditoFamilia.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblGridViewCartaoCreditoFamilia.ForeColor = SystemColors.ActiveCaptionText;
            lblGridViewCartaoCreditoFamilia.Location = new Point(244, 46);
            lblGridViewCartaoCreditoFamilia.Name = "lblGridViewCartaoCreditoFamilia";
            lblGridViewCartaoCreditoFamilia.Size = new Size(594, 45);
            lblGridViewCartaoCreditoFamilia.TabIndex = 11;
            lblGridViewCartaoCreditoFamilia.Text = resources.GetString("lblGridViewCartaoCreditoFamilia.Text");
            lblGridViewCartaoCreditoFamilia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblContaPagarGridViewTotais
            // 
            lblContaPagarGridViewTotais.AutoSize = true;
            lblContaPagarGridViewTotais.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblContaPagarGridViewTotais.ForeColor = Color.OrangeRed;
            lblContaPagarGridViewTotais.Location = new Point(10, 42);
            lblContaPagarGridViewTotais.Name = "lblContaPagarGridViewTotais";
            lblContaPagarGridViewTotais.Size = new Size(187, 20);
            lblContaPagarGridViewTotais.TabIndex = 9;
            lblContaPagarGridViewTotais.Text = "Total: 134 - R$ 33.300,00";
            // 
            // lblEfetuarPagamentoCategoria
            // 
            lblEfetuarPagamentoCategoria.AutoSize = true;
            lblEfetuarPagamentoCategoria.Location = new Point(354, 11);
            lblEfetuarPagamentoCategoria.Name = "lblEfetuarPagamentoCategoria";
            lblEfetuarPagamentoCategoria.Size = new Size(61, 15);
            lblEfetuarPagamentoCategoria.TabIndex = 7;
            lblEfetuarPagamentoCategoria.Text = "Categoria:";
            // 
            // cboEfetuarPagamentoCategoria
            // 
            cboEfetuarPagamentoCategoria.FormattingEnabled = true;
            cboEfetuarPagamentoCategoria.Location = new Point(421, 8);
            cboEfetuarPagamentoCategoria.Name = "cboEfetuarPagamentoCategoria";
            cboEfetuarPagamentoCategoria.Size = new Size(188, 23);
            cboEfetuarPagamentoCategoria.TabIndex = 8;
            cboEfetuarPagamentoCategoria.SelectedValueChanged += CboEfetuarPagamentoCategoria_SelectedValueChanged;
            // 
            // lblEfetuarPagamentoInformativoDuploCliqueGrid
            // 
            lblEfetuarPagamentoInformativoDuploCliqueGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEfetuarPagamentoInformativoDuploCliqueGrid.AutoSize = true;
            lblEfetuarPagamentoInformativoDuploCliqueGrid.ForeColor = SystemColors.ButtonShadow;
            lblEfetuarPagamentoInformativoDuploCliqueGrid.Location = new Point(10, 127);
            lblEfetuarPagamentoInformativoDuploCliqueGrid.Name = "lblEfetuarPagamentoInformativoDuploCliqueGrid";
            lblEfetuarPagamentoInformativoDuploCliqueGrid.Size = new Size(334, 15);
            lblEfetuarPagamentoInformativoDuploCliqueGrid.TabIndex = 6;
            lblEfetuarPagamentoInformativoDuploCliqueGrid.Text = "Ao efetuar duplo clique na linha do Grid abre para Pagamento";
            lblEfetuarPagamentoInformativoDuploCliqueGrid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPagamentoAvulso
            // 
            btnPagamentoAvulso.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPagamentoAvulso.BackColor = Color.SeaGreen;
            btnPagamentoAvulso.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPagamentoAvulso.ForeColor = Color.White;
            btnPagamentoAvulso.Location = new Point(657, 4);
            btnPagamentoAvulso.Name = "btnPagamentoAvulso";
            btnPagamentoAvulso.Size = new Size(190, 38);
            btnPagamentoAvulso.TabIndex = 4;
            btnPagamentoAvulso.Text = "Pagar Cartão de Crédito";
            btnPagamentoAvulso.UseVisualStyleBackColor = false;
            btnPagamentoAvulso.Click += BtnPagamentoAvulso_Click;
            // 
            // btnEfetuarPagamentoBuscar
            // 
            btnEfetuarPagamentoBuscar.Location = new Point(244, 8);
            btnEfetuarPagamentoBuscar.Name = "btnEfetuarPagamentoBuscar";
            btnEfetuarPagamentoBuscar.Size = new Size(99, 23);
            btnEfetuarPagamentoBuscar.TabIndex = 3;
            btnEfetuarPagamentoBuscar.Text = "Buscar Dados";
            btnEfetuarPagamentoBuscar.UseVisualStyleBackColor = true;
            btnEfetuarPagamentoBuscar.Click += BtnEfetuarPagamentoBuscar_Click;
            // 
            // lblEfetuarPagamentoAnoMes
            // 
            lblEfetuarPagamentoAnoMes.AutoSize = true;
            lblEfetuarPagamentoAnoMes.Location = new Point(8, 12);
            lblEfetuarPagamentoAnoMes.Name = "lblEfetuarPagamentoAnoMes";
            lblEfetuarPagamentoAnoMes.Size = new Size(59, 15);
            lblEfetuarPagamentoAnoMes.TabIndex = 2;
            lblEfetuarPagamentoAnoMes.Text = "Ano/Mês:";
            // 
            // cboAnoMesContaPagar
            // 
            cboAnoMesContaPagar.FormattingEnabled = true;
            cboAnoMesContaPagar.Location = new Point(73, 9);
            cboAnoMesContaPagar.Name = "cboAnoMesContaPagar";
            cboAnoMesContaPagar.Size = new Size(156, 23);
            cboAnoMesContaPagar.TabIndex = 1;
            // 
            // dgvContaPagar
            // 
            dgvContaPagar.AllowUserToAddRows = false;
            dgvContaPagar.AllowUserToDeleteRows = false;
            dgvContaPagar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvContaPagar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvContaPagar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvContaPagar.BackgroundColor = SystemColors.AppWorkspace;
            dgvContaPagar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvContaPagar.DefaultCellStyle = dataGridViewCellStyle1;
            dgvContaPagar.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvContaPagar.Location = new Point(10, 145);
            dgvContaPagar.Name = "dgvContaPagar";
            dgvContaPagar.ReadOnly = true;
            dgvContaPagar.RowTemplate.Height = 25;
            dgvContaPagar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContaPagar.Size = new Size(1193, 348);
            dgvContaPagar.TabIndex = 0;
            dgvContaPagar.MultiSelectChanged += DgvEfetuarPagamentoListagem_MultiSelectChanged;
            dgvContaPagar.CellDoubleClick += DgvEfetuarPagamentoListagem_CellDoubleClick;
            dgvContaPagar.CellMouseClick += DgvEfetuarPagamentoListagem_CellMouseClick;
            dgvContaPagar.CellMouseDown += EditarRegistroSelecionado_DgvEfetuarPagamentoListagem_CellMouseDown;
            dgvContaPagar.ColumnSortModeChanged += DgvEfetuarPagamentoListagem_ColumnSortModeChanged;
            dgvContaPagar.RowsAdded += DgvContaPagar_RowsAdded;
            dgvContaPagar.SelectionChanged += DgvEfetuarPagamentoListagem_SelectionChanged;
            // 
            // tbpListarContaReceber
            // 
            tbpListarContaReceber.Controls.Add(label2);
            tbpListarContaReceber.Controls.Add(lblValorRecebido);
            tbpListarContaReceber.Controls.Add(lblValorTotalContaReceber);
            tbpListarContaReceber.Controls.Add(lblDgvDoubleClick);
            tbpListarContaReceber.Controls.Add(btnBuscarContaReceber);
            tbpListarContaReceber.Controls.Add(lblAnoMes);
            tbpListarContaReceber.Controls.Add(cboMesAnoContaReceber);
            tbpListarContaReceber.Controls.Add(dgvContaReceber);
            tbpListarContaReceber.Location = new Point(4, 24);
            tbpListarContaReceber.Name = "tbpListarContaReceber";
            tbpListarContaReceber.Padding = new Padding(3);
            tbpListarContaReceber.Size = new Size(1208, 501);
            tbpListarContaReceber.TabIndex = 4;
            tbpListarContaReceber.Text = "Contas a Receber";
            tbpListarContaReceber.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonShadow;
            label2.Location = new Point(399, 95);
            label2.Name = "label2";
            label2.Size = new Size(523, 15);
            label2.TabIndex = 25;
            label2.Text = "Ao efetuar clique único com botão direito na linha do grid será aberto a tela de edição do registro.\r\n";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValorRecebido
            // 
            lblValorRecebido.AutoSize = true;
            lblValorRecebido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorRecebido.ForeColor = Color.Green;
            lblValorRecebido.Location = new Point(10, 69);
            lblValorRecebido.Name = "lblValorRecebido";
            lblValorRecebido.Size = new Size(189, 17);
            lblValorRecebido.TabIndex = 24;
            lblValorRecebido.Text = "Recebido: 100 - R$ 100.000,00";
            // 
            // lblValorTotalContaReceber
            // 
            lblValorTotalContaReceber.AutoSize = true;
            lblValorTotalContaReceber.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorTotalContaReceber.ForeColor = Color.DarkOrange;
            lblValorTotalContaReceber.Location = new Point(10, 46);
            lblValorTotalContaReceber.Name = "lblValorTotalContaReceber";
            lblValorTotalContaReceber.Size = new Size(187, 20);
            lblValorTotalContaReceber.TabIndex = 23;
            lblValorTotalContaReceber.Text = "Total: 134 - R$ 33.300,00";
            // 
            // lblDgvDoubleClick
            // 
            lblDgvDoubleClick.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDgvDoubleClick.AutoSize = true;
            lblDgvDoubleClick.ForeColor = SystemColors.ButtonShadow;
            lblDgvDoubleClick.Location = new Point(10, 95);
            lblDgvDoubleClick.Name = "lblDgvDoubleClick";
            lblDgvDoubleClick.Size = new Size(378, 15);
            lblDgvDoubleClick.TabIndex = 22;
            lblDgvDoubleClick.Text = "Ao efetuar duplo clique na linha do Grid abre para Recebimento Conta\r\n";
            lblDgvDoubleClick.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBuscarContaReceber
            // 
            btnBuscarContaReceber.Location = new Point(245, 6);
            btnBuscarContaReceber.Name = "btnBuscarContaReceber";
            btnBuscarContaReceber.Size = new Size(99, 23);
            btnBuscarContaReceber.TabIndex = 21;
            btnBuscarContaReceber.Text = "Buscar Dados";
            btnBuscarContaReceber.UseVisualStyleBackColor = true;
            btnBuscarContaReceber.Click += BtnBuscarContaReceber_Click;
            // 
            // lblAnoMes
            // 
            lblAnoMes.AutoSize = true;
            lblAnoMes.Location = new Point(9, 10);
            lblAnoMes.Name = "lblAnoMes";
            lblAnoMes.Size = new Size(59, 15);
            lblAnoMes.TabIndex = 20;
            lblAnoMes.Text = "Ano/Mês:";
            // 
            // cboMesAnoContaReceber
            // 
            cboMesAnoContaReceber.FormattingEnabled = true;
            cboMesAnoContaReceber.Location = new Point(74, 7);
            cboMesAnoContaReceber.Name = "cboMesAnoContaReceber";
            cboMesAnoContaReceber.Size = new Size(156, 23);
            cboMesAnoContaReceber.TabIndex = 19;
            // 
            // dgvContaReceber
            // 
            dgvContaReceber.AllowUserToAddRows = false;
            dgvContaReceber.AllowUserToDeleteRows = false;
            dgvContaReceber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvContaReceber.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvContaReceber.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvContaReceber.BackgroundColor = SystemColors.AppWorkspace;
            dgvContaReceber.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvContaReceber.DefaultCellStyle = dataGridViewCellStyle2;
            dgvContaReceber.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvContaReceber.Location = new Point(8, 113);
            dgvContaReceber.Name = "dgvContaReceber";
            dgvContaReceber.ReadOnly = true;
            dgvContaReceber.RowTemplate.Height = 25;
            dgvContaReceber.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContaReceber.Size = new Size(1193, 382);
            dgvContaReceber.TabIndex = 1;
            dgvContaReceber.CellMouseDown += EditarRegistroSelecionadoContaReceber_CellMouseDown;
            dgvContaReceber.RowsAdded += DgvContaReceber_RowsAdded;
            // 
            // tbpEstudosFinanceiros
            // 
            tbpEstudosFinanceiros.Controls.Add(lblEstudoFinanceiroMesesSerAnalisado);
            tbpEstudosFinanceiros.Controls.Add(cboEstudoFinanceiroMesesAnalises);
            tbpEstudosFinanceiros.Controls.Add(btnSearchMonthlyAverageAnalysis);
            tbpEstudosFinanceiros.Controls.Add(dgvSearchMonthlyAverageAnalysis);
            tbpEstudosFinanceiros.Location = new Point(4, 24);
            tbpEstudosFinanceiros.Name = "tbpEstudosFinanceiros";
            tbpEstudosFinanceiros.Padding = new Padding(3);
            tbpEstudosFinanceiros.Size = new Size(1208, 501);
            tbpEstudosFinanceiros.TabIndex = 3;
            tbpEstudosFinanceiros.Text = "Estudos Financeiros";
            tbpEstudosFinanceiros.UseVisualStyleBackColor = true;
            // 
            // lblEstudoFinanceiroMesesSerAnalisado
            // 
            lblEstudoFinanceiroMesesSerAnalisado.AutoSize = true;
            lblEstudoFinanceiroMesesSerAnalisado.Location = new Point(8, 14);
            lblEstudoFinanceiroMesesSerAnalisado.Name = "lblEstudoFinanceiroMesesSerAnalisado";
            lblEstudoFinanceiroMesesSerAnalisado.Size = new Size(194, 15);
            lblEstudoFinanceiroMesesSerAnalisado.TabIndex = 3;
            lblEstudoFinanceiroMesesSerAnalisado.Text = "Quantos Meses quer ter de Análise?";
            // 
            // cboEstudoFinanceiroMesesAnalises
            // 
            cboEstudoFinanceiroMesesAnalises.FormattingEnabled = true;
            cboEstudoFinanceiroMesesAnalises.Location = new Point(207, 10);
            cboEstudoFinanceiroMesesAnalises.Name = "cboEstudoFinanceiroMesesAnalises";
            cboEstudoFinanceiroMesesAnalises.Size = new Size(121, 23);
            cboEstudoFinanceiroMesesAnalises.TabIndex = 2;
            // 
            // btnSearchMonthlyAverageAnalysis
            // 
            btnSearchMonthlyAverageAnalysis.Location = new Point(334, 10);
            btnSearchMonthlyAverageAnalysis.Name = "btnSearchMonthlyAverageAnalysis";
            btnSearchMonthlyAverageAnalysis.Size = new Size(75, 23);
            btnSearchMonthlyAverageAnalysis.TabIndex = 1;
            btnSearchMonthlyAverageAnalysis.Text = "Buscar";
            btnSearchMonthlyAverageAnalysis.UseVisualStyleBackColor = true;
            btnSearchMonthlyAverageAnalysis.Click += BtnSearchMonthlyAverageAnalysis_Click;
            // 
            // dgvSearchMonthlyAverageAnalysis
            // 
            dgvSearchMonthlyAverageAnalysis.AllowUserToAddRows = false;
            dgvSearchMonthlyAverageAnalysis.AllowUserToDeleteRows = false;
            dgvSearchMonthlyAverageAnalysis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSearchMonthlyAverageAnalysis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSearchMonthlyAverageAnalysis.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvSearchMonthlyAverageAnalysis.BackgroundColor = SystemColors.AppWorkspace;
            dgvSearchMonthlyAverageAnalysis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchMonthlyAverageAnalysis.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearchMonthlyAverageAnalysis.Location = new Point(6, 40);
            dgvSearchMonthlyAverageAnalysis.Name = "dgvSearchMonthlyAverageAnalysis";
            dgvSearchMonthlyAverageAnalysis.ReadOnly = true;
            dgvSearchMonthlyAverageAnalysis.RowTemplate.Height = 25;
            dgvSearchMonthlyAverageAnalysis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearchMonthlyAverageAnalysis.Size = new Size(908, 413);
            dgvSearchMonthlyAverageAnalysis.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVersion.BackColor = Color.DarkOrange;
            lblVersion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblVersion.ForeColor = Color.DimGray;
            lblVersion.Location = new Point(1113, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.RightToLeft = RightToLeft.Yes;
            lblVersion.Size = new Size(103, 21);
            lblVersion.TabIndex = 30;
            lblVersion.Text = "Versão: 1.1.0";
            // 
            // lblInfoHeader
            // 
            lblInfoHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfoHeader.BackColor = Color.DarkOrange;
            lblInfoHeader.FlatStyle = FlatStyle.Popup;
            lblInfoHeader.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblInfoHeader.ForeColor = Color.DimGray;
            lblInfoHeader.Location = new Point(231, 0);
            lblInfoHeader.Margin = new Padding(0);
            lblInfoHeader.Name = "lblInfoHeader";
            lblInfoHeader.Size = new Size(983, 21);
            lblInfoHeader.TabIndex = 31;
            lblInfoHeader.Text = "Ambiente: Produção | API Url Destino: ";
            lblInfoHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rdbAmbienteLocal
            // 
            rdbAmbienteLocal.BackColor = Color.DarkOrange;
            rdbAmbienteLocal.Location = new Point(1, 0);
            rdbAmbienteLocal.Name = "rdbAmbienteLocal";
            rdbAmbienteLocal.Size = new Size(57, 21);
            rdbAmbienteLocal.TabIndex = 32;
            rdbAmbienteLocal.Text = "Local";
            rdbAmbienteLocal.TextAlign = ContentAlignment.MiddleRight;
            rdbAmbienteLocal.UseVisualStyleBackColor = false;
            rdbAmbienteLocal.CheckedChanged += RdbAmbienteLocal_CheckedChanged;
            // 
            // rdbAmbienteHomologacao
            // 
            rdbAmbienteHomologacao.BackColor = Color.DarkOrange;
            rdbAmbienteHomologacao.Location = new Point(58, 0);
            rdbAmbienteHomologacao.Name = "rdbAmbienteHomologacao";
            rdbAmbienteHomologacao.Size = new Size(105, 21);
            rdbAmbienteHomologacao.TabIndex = 33;
            rdbAmbienteHomologacao.Text = "Homologação";
            rdbAmbienteHomologacao.TextAlign = ContentAlignment.MiddleRight;
            rdbAmbienteHomologacao.UseVisualStyleBackColor = false;
            rdbAmbienteHomologacao.CheckedChanged += RdbAmbienteHomologacao_CheckedChanged;
            // 
            // rdbAmbienteProducao
            // 
            rdbAmbienteProducao.BackColor = Color.DarkOrange;
            rdbAmbienteProducao.Checked = true;
            rdbAmbienteProducao.Location = new Point(161, 0);
            rdbAmbienteProducao.Name = "rdbAmbienteProducao";
            rdbAmbienteProducao.Size = new Size(80, 21);
            rdbAmbienteProducao.TabIndex = 34;
            rdbAmbienteProducao.TabStop = true;
            rdbAmbienteProducao.Text = "Produção";
            rdbAmbienteProducao.TextAlign = ContentAlignment.MiddleRight;
            rdbAmbienteProducao.UseVisualStyleBackColor = false;
            rdbAmbienteProducao.CheckedChanged += RdbAmbienteProducao_CheckedChanged;
            // 
            // Initial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 550);
            Controls.Add(rdbAmbienteProducao);
            Controls.Add(rdbAmbienteHomologacao);
            Controls.Add(rdbAmbienteLocal);
            Controls.Add(lblVersion);
            Controls.Add(lblInfoHeader);
            Controls.Add(tbcInitial);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Initial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela inicial - Organização Financeira";
            WindowState = FormWindowState.Maximized;
            Load += Initial_Load;
            tbcInitial.ResumeLayout(false);
            tbpCadastroContaPagar.ResumeLayout(false);
            grbTemplateContaPagar.ResumeLayout(false);
            grbTemplateContaPagar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCadastroConta).EndInit();
            grbCadastroContaHistorico.ResumeLayout(false);
            grbCadastroContaHistorico.PerformLayout();
            tbpListarContaPagar.ResumeLayout(false);
            tbpListarContaPagar.PerformLayout();
            grbAlerta.ResumeLayout(false);
            grbAlerta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaPagar).EndInit();
            tbpListarContaReceber.ResumeLayout(false);
            tbpListarContaReceber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaReceber).EndInit();
            tbpEstudosFinanceiros.ResumeLayout(false);
            tbpEstudosFinanceiros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchMonthlyAverageAnalysis).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tbcInitial;
        private TabPage tbpCadastroContaPagar;
        private GroupBox grbTemplateContaPagar;
        private TextBox txtCadastroContaValue;
        private Label lblCadastroContaValor;
        private Label lblCadastroContaNameDescription;
        private ComboBox cboCadastroContaFinallyMonthYear;
        private TextBox txtCadastroContaName;
        private Label lblCadastroContaAnoMesFinal;
        private Label lblCadastroContaCategory;
        private CheckBox ckbCadastroContaConsideraMesmoMes;
        private ComboBox cboCadastroContaCategory;
        private ComboBox cboCadastroContaInititalMonthYear;
        private Label lblCadastroContaTipoConta;
        private Label lblCadastroContaAnoMesInicial;
        private ComboBox cboCadastroContaAccount;
        private DataGridView dgvCadastroConta;
        private DateTimePicker dtpCadastroContaDate;
        private Label lblCadastroContaDataCompra;
        private Label lblCadastroContaBestDay;
        private ComboBox cboCadastroContaBestDay;
        private ComboBox cboCadastroContaFrequence;
        private Label lblCadastroContaFrequencia;
        private ComboBox cboCadastroContaRegistrationType;
        private Label lblCadastroContaTipoCadastro;
        private RichTextBox rtbCadastroContaMensagemAdicional;
        private Label lblCadastroContaMensagemAdicional;
        private Label lblCadastroContaDataCriacao;
        private GroupBox grbCadastroContaHistorico;
        private Button btnEfetuarCadastroConta;
        private TabPage tbpListarContaPagar;
        private DataGridView dgvContaPagar;
        private Label lblEfetuarPagamentoAnoMes;
        private ComboBox cboAnoMesContaPagar;
        private Button btnEfetuarPagamentoBuscar;
        private Button btnPagamentoAvulso;
        private Label lblEfetuarPagamentoInformativoDuploCliqueGrid;
        private Label lblEfetuarPagamentoCategoria;
        private ComboBox cboEfetuarPagamentoCategoria;
        private Label lblContaPagarGridViewTotais;
        private Label lblGridViewCartaoCreditoFamilia;
        private Label lblContaPagarGridViewTotalPago;
        private Label lblVersion;
        private Label lblInfoHeader;
        private RadioButton rdbAmbienteLocal;
        private RadioButton rdbAmbienteHomologacao;
        private RadioButton rdbAmbienteProducao;
        private Label lblEfetuarPagamentoLinhasSelecionadasDataGridView;
        private Label lblEfetuarPagamentoItensSelecionadosDataGridView;
        private Button btnExcluir;
        private CheckBox cboApenasNaoPagos;
        private Button btnExibirDetalhes;
        private CheckBox cboNaoEnviarMesAnoFinal;
        private CheckBox cboCadastroContaHabilitarDate;
        private TabPage tbpEstudosFinanceiros;
        private DataGridView dgvSearchMonthlyAverageAnalysis;
        private Button btnSearchMonthlyAverageAnalysis;
        private ComboBox cboEstudoFinanceiroMesesAnalises;
        private Label lblEstudoFinanceiroMesesSerAnalisado;
        private Button btnExcluirInitial;
        private Label label1;
        private Label lblGridViewSelectedRowsRemainingValue;
        private Label lblGridViewSelectedRowsCompleted;
        private Label lblQtdItensParaFinalizarCadastro;
        private Label lblEventRepeat;
        private Label lblTotalValueGridView;
        private TabPage tbpListarContaReceber;
        private Label label2;
        private Label lblValorRecebido;
        private Label lblValorTotalContaReceber;
        private Label lblDgvDoubleClick;
        private Button btnBuscarContaReceber;
        private Label lblAnoMes;
        private ComboBox cboMesAnoContaReceber;
        private DataGridView dgvContaReceber;
        private GroupBox grbAlerta;
        private RadioButton rdbCadastroContaReceber;
        private RadioButton rdbCadastroContaPagar;
    }
}