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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Initial));
            tbcInitial = new TabControl();
            tbpCadastroContaPagar = new TabPage();
            grbTemplateContaPagar = new GroupBox();
            ckbCartaoCreditoNaira = new CheckBox();
            cboHabilitarDataCompra = new CheckBox();
            cboNaoEnviarMesAnoFinal = new CheckBox();
            btnContaPagarCadastrar = new Button();
            dgvContaPagar = new DataGridView();
            grbContaPagarHistorico = new GroupBox();
            lblTotalValueGridView = new Label();
            lblContaPagarDataCriacao = new Label();
            rtbContaPagarMensagemAdicional = new RichTextBox();
            lblContaPagarMensagemAdicional = new Label();
            cboContaPagarTipoCadastro = new ComboBox();
            lblContaPagarTipoCadastro = new Label();
            cboContaPagarFrequencia = new ComboBox();
            lblContaPagarFrequencia = new Label();
            cboContaPagarMelhorDiaPagamento = new ComboBox();
            lblContaPagarMelhorDiaPagamento = new Label();
            dtpContaPagarDataCompra = new DateTimePicker();
            lblContaPagarDataCompra = new Label();
            txtContaPagarValor = new TextBox();
            lblContaPagarValor = new Label();
            lblContaPagarNameDescription = new Label();
            cboContaPagarAnoMesFinal = new ComboBox();
            txtContaPagarNameDescription = new TextBox();
            lblContaPagarAnoMesFinal = new Label();
            lblContaPagarCategory = new Label();
            ckbContaPagarConsideraMesmoMes = new CheckBox();
            cboContaPagarCategory = new ComboBox();
            cboContaPagarAnoMesInicial = new ComboBox();
            lblContaPagarTipoConta = new Label();
            lblContaPagarAnoMesInicial = new Label();
            cboContaPagarTipoConta = new ComboBox();
            tbpListarContaPagar = new TabPage();
            lblEventRepeat = new Label();
            lblQtdItensParaFinalizarCadastro = new Label();
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
            dgvEfetuarPagamentoListagem = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dgvContaPagar).BeginInit();
            grbContaPagarHistorico.SuspendLayout();
            tbpListarContaPagar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEfetuarPagamentoListagem).BeginInit();
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
            grbTemplateContaPagar.Controls.Add(ckbCartaoCreditoNaira);
            grbTemplateContaPagar.Controls.Add(cboHabilitarDataCompra);
            grbTemplateContaPagar.Controls.Add(cboNaoEnviarMesAnoFinal);
            grbTemplateContaPagar.Controls.Add(btnContaPagarCadastrar);
            grbTemplateContaPagar.Controls.Add(dgvContaPagar);
            grbTemplateContaPagar.Controls.Add(grbContaPagarHistorico);
            grbTemplateContaPagar.Controls.Add(lblContaPagarDataCriacao);
            grbTemplateContaPagar.Controls.Add(rtbContaPagarMensagemAdicional);
            grbTemplateContaPagar.Controls.Add(lblContaPagarMensagemAdicional);
            grbTemplateContaPagar.Controls.Add(cboContaPagarTipoCadastro);
            grbTemplateContaPagar.Controls.Add(lblContaPagarTipoCadastro);
            grbTemplateContaPagar.Controls.Add(cboContaPagarFrequencia);
            grbTemplateContaPagar.Controls.Add(lblContaPagarFrequencia);
            grbTemplateContaPagar.Controls.Add(cboContaPagarMelhorDiaPagamento);
            grbTemplateContaPagar.Controls.Add(lblContaPagarMelhorDiaPagamento);
            grbTemplateContaPagar.Controls.Add(dtpContaPagarDataCompra);
            grbTemplateContaPagar.Controls.Add(lblContaPagarDataCompra);
            grbTemplateContaPagar.Controls.Add(txtContaPagarValor);
            grbTemplateContaPagar.Controls.Add(lblContaPagarValor);
            grbTemplateContaPagar.Controls.Add(lblContaPagarNameDescription);
            grbTemplateContaPagar.Controls.Add(cboContaPagarAnoMesFinal);
            grbTemplateContaPagar.Controls.Add(txtContaPagarNameDescription);
            grbTemplateContaPagar.Controls.Add(lblContaPagarAnoMesFinal);
            grbTemplateContaPagar.Controls.Add(lblContaPagarCategory);
            grbTemplateContaPagar.Controls.Add(ckbContaPagarConsideraMesmoMes);
            grbTemplateContaPagar.Controls.Add(cboContaPagarCategory);
            grbTemplateContaPagar.Controls.Add(cboContaPagarAnoMesInicial);
            grbTemplateContaPagar.Controls.Add(lblContaPagarTipoConta);
            grbTemplateContaPagar.Controls.Add(lblContaPagarAnoMesInicial);
            grbTemplateContaPagar.Controls.Add(cboContaPagarTipoConta);
            grbTemplateContaPagar.Location = new Point(16, 6);
            grbTemplateContaPagar.Name = "grbTemplateContaPagar";
            grbTemplateContaPagar.Size = new Size(1173, 487);
            grbTemplateContaPagar.TabIndex = 15;
            grbTemplateContaPagar.TabStop = false;
            grbTemplateContaPagar.Text = "Cadastro de Conta a Pagar - Livre";
            // 
            // ckbCartaoCreditoNaira
            // 
            ckbCartaoCreditoNaira.AutoSize = true;
            ckbCartaoCreditoNaira.Enabled = false;
            ckbCartaoCreditoNaira.Location = new Point(305, 134);
            ckbCartaoCreditoNaira.Name = "ckbCartaoCreditoNaira";
            ckbCartaoCreditoNaira.Size = new Size(155, 19);
            ckbCartaoCreditoNaira.TabIndex = 38;
            ckbCartaoCreditoNaira.Text = "Cartão de Crédito Naíra?";
            ckbCartaoCreditoNaira.UseVisualStyleBackColor = true;
            ckbCartaoCreditoNaira.CheckedChanged += CkbCartaoCreditoNaira_CheckedChanged;
            // 
            // cboHabilitarDataCompra
            // 
            cboHabilitarDataCompra.AutoSize = true;
            cboHabilitarDataCompra.Checked = true;
            cboHabilitarDataCompra.CheckState = CheckState.Checked;
            cboHabilitarDataCompra.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboHabilitarDataCompra.Location = new Point(728, 60);
            cboHabilitarDataCompra.Name = "cboHabilitarDataCompra";
            cboHabilitarDataCompra.Size = new Size(161, 17);
            cboHabilitarDataCompra.TabIndex = 37;
            cboHabilitarDataCompra.Text = "Habilitar Data de Compra?";
            cboHabilitarDataCompra.UseVisualStyleBackColor = true;
            cboHabilitarDataCompra.CheckedChanged += CboHabilitarDataCompra_CheckedChanged;
            // 
            // cboNaoEnviarMesAnoFinal
            // 
            cboNaoEnviarMesAnoFinal.AutoSize = true;
            cboNaoEnviarMesAnoFinal.Location = new Point(283, 199);
            cboNaoEnviarMesAnoFinal.Name = "cboNaoEnviarMesAnoFinal";
            cboNaoEnviarMesAnoFinal.Size = new Size(166, 19);
            cboNaoEnviarMesAnoFinal.TabIndex = 30;
            cboNaoEnviarMesAnoFinal.Text = "Não Enviar Ano/Mês Final!";
            cboNaoEnviarMesAnoFinal.UseVisualStyleBackColor = true;
            cboNaoEnviarMesAnoFinal.CheckedChanged += CboNaoEnviarMesAnoFinal_CheckedChanged;
            // 
            // btnContaPagarCadastrar
            // 
            btnContaPagarCadastrar.AutoSize = true;
            btnContaPagarCadastrar.FlatStyle = FlatStyle.System;
            btnContaPagarCadastrar.Location = new Point(960, 187);
            btnContaPagarCadastrar.Name = "btnContaPagarCadastrar";
            btnContaPagarCadastrar.Size = new Size(176, 34);
            btnContaPagarCadastrar.TabIndex = 29;
            btnContaPagarCadastrar.Text = "Cadastrar (Conta a Pagar)";
            btnContaPagarCadastrar.UseVisualStyleBackColor = true;
            btnContaPagarCadastrar.Click += BtnContaPagarCadastrar_Click;
            // 
            // dgvContaPagar
            // 
            dgvContaPagar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvContaPagar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvContaPagar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvContaPagar.BackgroundColor = SystemColors.AppWorkspace;
            dgvContaPagar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContaPagar.Location = new Point(25, 275);
            dgvContaPagar.Name = "dgvContaPagar";
            dgvContaPagar.RowTemplate.Height = 25;
            dgvContaPagar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContaPagar.Size = new Size(1128, 200);
            dgvContaPagar.TabIndex = 15;
            dgvContaPagar.RowsAdded += DgvContaPagar_RowsAdded;
            dgvContaPagar.SelectionChanged += DgvContaPagar_SelectionChanged;
            // 
            // grbContaPagarHistorico
            // 
            grbContaPagarHistorico.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grbContaPagarHistorico.Controls.Add(lblTotalValueGridView);
            grbContaPagarHistorico.Location = new Point(8, 240);
            grbContaPagarHistorico.Name = "grbContaPagarHistorico";
            grbContaPagarHistorico.Size = new Size(1159, 241);
            grbContaPagarHistorico.TabIndex = 28;
            grbContaPagarHistorico.TabStop = false;
            grbContaPagarHistorico.Text = "Últimos cadastros realizados...";
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
            // lblContaPagarDataCriacao
            // 
            lblContaPagarDataCriacao.AutoSize = true;
            lblContaPagarDataCriacao.Location = new Point(940, 159);
            lblContaPagarDataCriacao.Name = "lblContaPagarDataCriacao";
            lblContaPagarDataCriacao.Size = new Size(213, 15);
            lblContaPagarDataCriacao.TabIndex = 27;
            lblContaPagarDataCriacao.Text = "Data de Criação: 15/03/1995 às 05:35:01";
            // 
            // rtbContaPagarMensagemAdicional
            // 
            rtbContaPagarMensagemAdicional.Location = new Point(925, 48);
            rtbContaPagarMensagemAdicional.Name = "rtbContaPagarMensagemAdicional";
            rtbContaPagarMensagemAdicional.Size = new Size(242, 96);
            rtbContaPagarMensagemAdicional.TabIndex = 26;
            rtbContaPagarMensagemAdicional.Text = "";
            // 
            // lblContaPagarMensagemAdicional
            // 
            lblContaPagarMensagemAdicional.AutoSize = true;
            lblContaPagarMensagemAdicional.Location = new Point(922, 30);
            lblContaPagarMensagemAdicional.Name = "lblContaPagarMensagemAdicional";
            lblContaPagarMensagemAdicional.Size = new Size(122, 15);
            lblContaPagarMensagemAdicional.TabIndex = 24;
            lblContaPagarMensagemAdicional.Text = "Mensagem Adicional:";
            // 
            // cboContaPagarTipoCadastro
            // 
            cboContaPagarTipoCadastro.FormattingEnabled = true;
            cboContaPagarTipoCadastro.Location = new Point(652, 195);
            cboContaPagarTipoCadastro.Name = "cboContaPagarTipoCadastro";
            cboContaPagarTipoCadastro.Size = new Size(204, 23);
            cboContaPagarTipoCadastro.TabIndex = 23;
            // 
            // lblContaPagarTipoCadastro
            // 
            lblContaPagarTipoCadastro.AutoSize = true;
            lblContaPagarTipoCadastro.Location = new Point(547, 198);
            lblContaPagarTipoCadastro.Name = "lblContaPagarTipoCadastro";
            lblContaPagarTipoCadastro.Size = new Size(99, 15);
            lblContaPagarTipoCadastro.TabIndex = 22;
            lblContaPagarTipoCadastro.Text = "Tipo de Cadastro:";
            // 
            // cboContaPagarFrequencia
            // 
            cboContaPagarFrequencia.FormattingEnabled = true;
            cboContaPagarFrequencia.Location = new Point(652, 157);
            cboContaPagarFrequencia.Name = "cboContaPagarFrequencia";
            cboContaPagarFrequencia.Size = new Size(161, 23);
            cboContaPagarFrequencia.TabIndex = 21;
            // 
            // lblContaPagarFrequencia
            // 
            lblContaPagarFrequencia.AutoSize = true;
            lblContaPagarFrequencia.Location = new Point(578, 160);
            lblContaPagarFrequencia.Name = "lblContaPagarFrequencia";
            lblContaPagarFrequencia.Size = new Size(68, 15);
            lblContaPagarFrequencia.TabIndex = 20;
            lblContaPagarFrequencia.Text = "Frequência:";
            // 
            // cboContaPagarMelhorDiaPagamento
            // 
            cboContaPagarMelhorDiaPagamento.BackColor = SystemColors.Window;
            cboContaPagarMelhorDiaPagamento.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cboContaPagarMelhorDiaPagamento.FormatString = "N0";
            cboContaPagarMelhorDiaPagamento.FormattingEnabled = true;
            cboContaPagarMelhorDiaPagamento.Location = new Point(652, 119);
            cboContaPagarMelhorDiaPagamento.Name = "cboContaPagarMelhorDiaPagamento";
            cboContaPagarMelhorDiaPagamento.Size = new Size(62, 27);
            cboContaPagarMelhorDiaPagamento.TabIndex = 19;
            // 
            // lblContaPagarMelhorDiaPagamento
            // 
            lblContaPagarMelhorDiaPagamento.AutoSize = true;
            lblContaPagarMelhorDiaPagamento.Location = new Point(499, 122);
            lblContaPagarMelhorDiaPagamento.Name = "lblContaPagarMelhorDiaPagamento";
            lblContaPagarMelhorDiaPagamento.Size = new Size(147, 15);
            lblContaPagarMelhorDiaPagamento.TabIndex = 18;
            lblContaPagarMelhorDiaPagamento.Text = "Melhor dia de Pagamento:";
            // 
            // dtpContaPagarDataCompra
            // 
            dtpContaPagarDataCompra.Location = new Point(652, 83);
            dtpContaPagarDataCompra.Name = "dtpContaPagarDataCompra";
            dtpContaPagarDataCompra.Size = new Size(237, 23);
            dtpContaPagarDataCompra.TabIndex = 17;
            dtpContaPagarDataCompra.ValueChanged += DtpContaPagarDataCompra_ValueChanged;
            // 
            // lblContaPagarDataCompra
            // 
            lblContaPagarDataCompra.AutoSize = true;
            lblContaPagarDataCompra.Location = new Point(553, 89);
            lblContaPagarDataCompra.Name = "lblContaPagarDataCompra";
            lblContaPagarDataCompra.Size = new Size(96, 15);
            lblContaPagarDataCompra.TabIndex = 16;
            lblContaPagarDataCompra.Text = "Data da Compra:";
            // 
            // txtContaPagarValor
            // 
            txtContaPagarValor.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtContaPagarValor.ForeColor = Color.OrangeRed;
            txtContaPagarValor.Location = new Point(652, 27);
            txtContaPagarValor.Name = "txtContaPagarValor";
            txtContaPagarValor.Size = new Size(133, 27);
            txtContaPagarValor.TabIndex = 13;
            txtContaPagarValor.TextAlign = HorizontalAlignment.Right;
            txtContaPagarValor.Enter += TxtContaPagarValor_Enter;
            txtContaPagarValor.Leave += TxtContaPagarValor_Leave;
            // 
            // lblContaPagarValor
            // 
            lblContaPagarValor.AutoSize = true;
            lblContaPagarValor.Location = new Point(594, 30);
            lblContaPagarValor.Name = "lblContaPagarValor";
            lblContaPagarValor.Size = new Size(52, 15);
            lblContaPagarValor.TabIndex = 12;
            lblContaPagarValor.Text = "Valor R$:";
            // 
            // lblContaPagarNameDescription
            // 
            lblContaPagarNameDescription.AutoSize = true;
            lblContaPagarNameDescription.Location = new Point(11, 35);
            lblContaPagarNameDescription.Name = "lblContaPagarNameDescription";
            lblContaPagarNameDescription.Size = new Size(99, 15);
            lblContaPagarNameDescription.TabIndex = 0;
            lblContaPagarNameDescription.Text = "Nome/Descrição:";
            // 
            // cboContaPagarAnoMesFinal
            // 
            cboContaPagarAnoMesFinal.FormattingEnabled = true;
            cboContaPagarAnoMesFinal.Location = new Point(116, 187);
            cboContaPagarAnoMesFinal.Name = "cboContaPagarAnoMesFinal";
            cboContaPagarAnoMesFinal.Size = new Size(161, 23);
            cboContaPagarAnoMesFinal.TabIndex = 11;
            // 
            // txtContaPagarNameDescription
            // 
            txtContaPagarNameDescription.Location = new Point(116, 32);
            txtContaPagarNameDescription.Name = "txtContaPagarNameDescription";
            txtContaPagarNameDescription.Size = new Size(445, 23);
            txtContaPagarNameDescription.TabIndex = 1;
            // 
            // lblContaPagarAnoMesFinal
            // 
            lblContaPagarAnoMesFinal.AutoSize = true;
            lblContaPagarAnoMesFinal.Location = new Point(23, 190);
            lblContaPagarAnoMesFinal.Name = "lblContaPagarAnoMesFinal";
            lblContaPagarAnoMesFinal.Size = new Size(87, 15);
            lblContaPagarAnoMesFinal.TabIndex = 10;
            lblContaPagarAnoMesFinal.Text = "Ano/Mês Final:";
            // 
            // lblContaPagarCategory
            // 
            lblContaPagarCategory.AutoSize = true;
            lblContaPagarCategory.Location = new Point(49, 72);
            lblContaPagarCategory.Name = "lblContaPagarCategory";
            lblContaPagarCategory.Size = new Size(61, 15);
            lblContaPagarCategory.TabIndex = 2;
            lblContaPagarCategory.Text = "Categoria:";
            // 
            // ckbContaPagarConsideraMesmoMes
            // 
            ckbContaPagarConsideraMesmoMes.AutoSize = true;
            ckbContaPagarConsideraMesmoMes.Checked = true;
            ckbContaPagarConsideraMesmoMes.CheckState = CheckState.Checked;
            ckbContaPagarConsideraMesmoMes.Location = new Point(283, 159);
            ckbContaPagarConsideraMesmoMes.Name = "ckbContaPagarConsideraMesmoMes";
            ckbContaPagarConsideraMesmoMes.Size = new Size(124, 34);
            ckbContaPagarConsideraMesmoMes.TabIndex = 9;
            ckbContaPagarConsideraMesmoMes.Text = "Considera como \r\nMês Inicial e Final?";
            ckbContaPagarConsideraMesmoMes.UseVisualStyleBackColor = true;
            ckbContaPagarConsideraMesmoMes.CheckedChanged += CkbContaPagarConsideraMesmoMes_CheckedChanged;
            // 
            // cboContaPagarCategory
            // 
            cboContaPagarCategory.FormattingEnabled = true;
            cboContaPagarCategory.Location = new Point(116, 69);
            cboContaPagarCategory.Name = "cboContaPagarCategory";
            cboContaPagarCategory.Size = new Size(263, 23);
            cboContaPagarCategory.TabIndex = 3;
            // 
            // cboContaPagarAnoMesInicial
            // 
            cboContaPagarAnoMesInicial.FormattingEnabled = true;
            cboContaPagarAnoMesInicial.Location = new Point(116, 151);
            cboContaPagarAnoMesInicial.Name = "cboContaPagarAnoMesInicial";
            cboContaPagarAnoMesInicial.Size = new Size(161, 23);
            cboContaPagarAnoMesInicial.TabIndex = 8;
            cboContaPagarAnoMesInicial.SelectedValueChanged += CboContaPagarAnoMesInicial_SelectedValueChanged;
            cboContaPagarAnoMesInicial.Leave += CboContaPagarAnoMesInicial_Leave;
            // 
            // lblContaPagarTipoConta
            // 
            lblContaPagarTipoConta.AutoSize = true;
            lblContaPagarTipoConta.Location = new Point(28, 111);
            lblContaPagarTipoConta.Name = "lblContaPagarTipoConta";
            lblContaPagarTipoConta.Size = new Size(42, 15);
            lblContaPagarTipoConta.TabIndex = 4;
            lblContaPagarTipoConta.Text = "Conta:";
            // 
            // lblContaPagarAnoMesInicial
            // 
            lblContaPagarAnoMesInicial.AutoSize = true;
            lblContaPagarAnoMesInicial.Location = new Point(19, 154);
            lblContaPagarAnoMesInicial.Name = "lblContaPagarAnoMesInicial";
            lblContaPagarAnoMesInicial.Size = new Size(93, 15);
            lblContaPagarAnoMesInicial.TabIndex = 7;
            lblContaPagarAnoMesInicial.Text = "Ano/Mês Inicial:";
            // 
            // cboContaPagarTipoConta
            // 
            cboContaPagarTipoConta.FormattingEnabled = true;
            cboContaPagarTipoConta.Location = new Point(76, 108);
            cboContaPagarTipoConta.Name = "cboContaPagarTipoConta";
            cboContaPagarTipoConta.Size = new Size(384, 23);
            cboContaPagarTipoConta.TabIndex = 5;
            cboContaPagarTipoConta.SelectedValueChanged += CboContaPagarTipoConta_SelectedValueChanged;
            // 
            // tbpListarContaPagar
            // 
            tbpListarContaPagar.Controls.Add(lblEventRepeat);
            tbpListarContaPagar.Controls.Add(lblQtdItensParaFinalizarCadastro);
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
            tbpListarContaPagar.Controls.Add(dgvEfetuarPagamentoListagem);
            tbpListarContaPagar.Location = new Point(4, 24);
            tbpListarContaPagar.Name = "tbpListarContaPagar";
            tbpListarContaPagar.Size = new Size(1208, 501);
            tbpListarContaPagar.TabIndex = 2;
            tbpListarContaPagar.Text = "Conta a Pagar - Listar";
            tbpListarContaPagar.UseVisualStyleBackColor = true;
            // 
            // lblEventRepeat
            // 
            lblEventRepeat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEventRepeat.AutoSize = true;
            lblEventRepeat.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblEventRepeat.ForeColor = SystemColors.ButtonShadow;
            lblEventRepeat.Location = new Point(551, 64);
            lblEventRepeat.Name = "lblEventRepeat";
            lblEventRepeat.Size = new Size(351, 12);
            lblEventRepeat.TabIndex = 22;
            lblEventRepeat.Text = "A cada 10 segundo(s) é efetuado uma consulta. Evento Repetido: 1000x até o momento.";
            lblEventRepeat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQtdItensParaFinalizarCadastro
            // 
            lblQtdItensParaFinalizarCadastro.AutoSize = true;
            lblQtdItensParaFinalizarCadastro.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblQtdItensParaFinalizarCadastro.ForeColor = Color.OrangeRed;
            lblQtdItensParaFinalizarCadastro.Location = new Point(570, 44);
            lblQtdItensParaFinalizarCadastro.Name = "lblQtdItensParaFinalizarCadastro";
            lblQtdItensParaFinalizarCadastro.Size = new Size(330, 17);
            lblQtdItensParaFinalizarCadastro.TabIndex = 21;
            lblQtdItensParaFinalizarCadastro.Text = "Existem 900 itens para serem finalizados o cadastro.";
            lblQtdItensParaFinalizarCadastro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGridViewSelectedRowsCompleted
            // 
            lblGridViewSelectedRowsCompleted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGridViewSelectedRowsCompleted.AutoSize = true;
            lblGridViewSelectedRowsCompleted.Location = new Point(898, 89);
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
            lblGridViewSelectedRowsRemainingValue.Location = new Point(903, 67);
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
            label1.Location = new Point(352, 91);
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
            lblEfetuarPagamentoItensSelecionadosDataGridView.Location = new Point(923, 45);
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
            lblContaPagarGridViewTotalPago.Location = new Point(10, 65);
            lblContaPagarGridViewTotalPago.Name = "lblContaPagarGridViewTotalPago";
            lblContaPagarGridViewTotalPago.Size = new Size(164, 17);
            lblContaPagarGridViewTotalPago.TabIndex = 13;
            lblContaPagarGridViewTotalPago.Text = "Pago: 100 - R$ 100.000,00";
            // 
            // lblGridViewCartaoCreditoFamilia
            // 
            lblGridViewCartaoCreditoFamilia.AutoSize = true;
            lblGridViewCartaoCreditoFamilia.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblGridViewCartaoCreditoFamilia.ForeColor = SystemColors.ActiveCaptionText;
            lblGridViewCartaoCreditoFamilia.Location = new Point(197, 43);
            lblGridViewCartaoCreditoFamilia.Name = "lblGridViewCartaoCreditoFamilia";
            lblGridViewCartaoCreditoFamilia.Size = new Size(371, 42);
            lblGridViewCartaoCreditoFamilia.TabIndex = 11;
            lblGridViewCartaoCreditoFamilia.Text = "Cartão de Crédito Itaú Personnalité Black Cashback: 10 - R$ 17.00,00\r\nCartão de Crédito Nubank: 10 - R$ 17.00,00\r\nCartão de Crédito: 10 - R$ 17.00,00\r\n";
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
            lblEfetuarPagamentoInformativoDuploCliqueGrid.Location = new Point(10, 91);
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
            // dgvEfetuarPagamentoListagem
            // 
            dgvEfetuarPagamentoListagem.AllowUserToAddRows = false;
            dgvEfetuarPagamentoListagem.AllowUserToDeleteRows = false;
            dgvEfetuarPagamentoListagem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEfetuarPagamentoListagem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEfetuarPagamentoListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvEfetuarPagamentoListagem.BackgroundColor = SystemColors.AppWorkspace;
            dgvEfetuarPagamentoListagem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvEfetuarPagamentoListagem.DefaultCellStyle = dataGridViewCellStyle1;
            dgvEfetuarPagamentoListagem.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEfetuarPagamentoListagem.Location = new Point(10, 111);
            dgvEfetuarPagamentoListagem.Name = "dgvEfetuarPagamentoListagem";
            dgvEfetuarPagamentoListagem.ReadOnly = true;
            dgvEfetuarPagamentoListagem.RowTemplate.Height = 25;
            dgvEfetuarPagamentoListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEfetuarPagamentoListagem.Size = new Size(1193, 382);
            dgvEfetuarPagamentoListagem.TabIndex = 0;
            dgvEfetuarPagamentoListagem.MultiSelectChanged += DgvEfetuarPagamentoListagem_MultiSelectChanged;
            dgvEfetuarPagamentoListagem.CellDoubleClick += DgvEfetuarPagamentoListagem_CellDoubleClick;
            dgvEfetuarPagamentoListagem.CellMouseClick += DgvEfetuarPagamentoListagem_CellMouseClick;
            dgvEfetuarPagamentoListagem.CellMouseDown += EditarRegistroSelecionado_DgvEfetuarPagamentoListagem_CellMouseDown;
            dgvEfetuarPagamentoListagem.ColumnSortModeChanged += DgvEfetuarPagamentoListagem_ColumnSortModeChanged;
            dgvEfetuarPagamentoListagem.RowsAdded += DgvEfetuarPagamentoListagem_RowsAdded;
            dgvEfetuarPagamentoListagem.SelectionChanged += DgvEfetuarPagamentoListagem_SelectionChanged;
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
            tbpListarContaReceber.Text = "Conra a Receber - Listar";
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
            Load += Initial_Load;
            tbcInitial.ResumeLayout(false);
            tbpCadastroContaPagar.ResumeLayout(false);
            grbTemplateContaPagar.ResumeLayout(false);
            grbTemplateContaPagar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaPagar).EndInit();
            grbContaPagarHistorico.ResumeLayout(false);
            grbContaPagarHistorico.PerformLayout();
            tbpListarContaPagar.ResumeLayout(false);
            tbpListarContaPagar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEfetuarPagamentoListagem).EndInit();
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
        private TextBox txtContaPagarValor;
        private Label lblContaPagarValor;
        private Label lblContaPagarNameDescription;
        private ComboBox cboContaPagarAnoMesFinal;
        private TextBox txtContaPagarNameDescription;
        private Label lblContaPagarAnoMesFinal;
        private Label lblContaPagarCategory;
        private CheckBox ckbContaPagarConsideraMesmoMes;
        private ComboBox cboContaPagarCategory;
        private ComboBox cboContaPagarAnoMesInicial;
        private Label lblContaPagarTipoConta;
        private Label lblContaPagarAnoMesInicial;
        private ComboBox cboContaPagarTipoConta;
        private DataGridView dgvContaPagar;
        private DateTimePicker dtpContaPagarDataCompra;
        private Label lblContaPagarDataCompra;
        private Label lblContaPagarMelhorDiaPagamento;
        private ComboBox cboContaPagarMelhorDiaPagamento;
        private ComboBox cboContaPagarFrequencia;
        private Label lblContaPagarFrequencia;
        private ComboBox cboContaPagarTipoCadastro;
        private Label lblContaPagarTipoCadastro;
        private RichTextBox rtbContaPagarMensagemAdicional;
        private Label lblContaPagarMensagemAdicional;
        private Label lblContaPagarDataCriacao;
        private GroupBox grbContaPagarHistorico;
        private Button btnContaPagarCadastrar;
        private TabPage tbpListarContaPagar;
        private DataGridView dgvEfetuarPagamentoListagem;
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
        private CheckBox cboHabilitarDataCompra;
        private TabPage tbpEstudosFinanceiros;
        private DataGridView dgvSearchMonthlyAverageAnalysis;
        private Button btnSearchMonthlyAverageAnalysis;
        private ComboBox cboEstudoFinanceiroMesesAnalises;
        private Label lblEstudoFinanceiroMesesSerAnalisado;
        private CheckBox ckbCartaoCreditoNaira;
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
    }
}