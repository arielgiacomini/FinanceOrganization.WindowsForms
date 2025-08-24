namespace App.Forms.Forms.Edição
{
    partial class FrmEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdit));
            grbTemplateContaPagar = new GroupBox();
            txtValorManipulado = new TextBox();
            lblValorManipulado = new Label();
            cboHabilitarDataCompraOuAcordo = new CheckBox();
            rdbContaPagaOuRecebida_Nao = new RadioButton();
            rdbContaPagaOuRecebida_Sim = new RadioButton();
            txtContaPagarDataPagamentoOuRecebimento = new TextBox();
            lblContaPagarDataPagamentoOuRecebimento = new Label();
            dtpContaDataVencimento = new DateTimePicker();
            lblContaPagarDataVencimento = new Label();
            btnContaAlterar = new Button();
            lblContaPagarDataCriacao = new Label();
            rtbContaPagarMensagemAdicional = new RichTextBox();
            lblContaPagarMensagemAdicional = new Label();
            cboContaPagarTipoCadastro = new ComboBox();
            lblContaPagarTipoCadastro = new Label();
            cboContaPagarFrequencia = new ComboBox();
            lblContaPagarFrequencia = new Label();
            dtpEdicaoContaDataCompraOuAcordo = new DateTimePicker();
            lblContaPagarDataCompra = new Label();
            txtContaPagarValor = new TextBox();
            lblContaPagarValor = new Label();
            lblContaPagarNameDescription = new Label();
            txtContaPagarNameDescription = new TextBox();
            lblContaPagarCategory = new Label();
            cboContaPagarCategory = new ComboBox();
            cboContaPagarAnoMesInicial = new ComboBox();
            lblContaPagarTipoConta = new Label();
            lblContaPagarAnoMes = new Label();
            cboContaPagarTipoConta = new ComboBox();
            grbTemplateContaPagar.SuspendLayout();
            SuspendLayout();
            // 
            // grbTemplateContaPagar
            // 
            grbTemplateContaPagar.Controls.Add(txtValorManipulado);
            grbTemplateContaPagar.Controls.Add(lblValorManipulado);
            grbTemplateContaPagar.Controls.Add(cboHabilitarDataCompraOuAcordo);
            grbTemplateContaPagar.Controls.Add(rdbContaPagaOuRecebida_Nao);
            grbTemplateContaPagar.Controls.Add(rdbContaPagaOuRecebida_Sim);
            grbTemplateContaPagar.Controls.Add(txtContaPagarDataPagamentoOuRecebimento);
            grbTemplateContaPagar.Controls.Add(lblContaPagarDataPagamentoOuRecebimento);
            grbTemplateContaPagar.Controls.Add(dtpContaDataVencimento);
            grbTemplateContaPagar.Controls.Add(lblContaPagarDataVencimento);
            grbTemplateContaPagar.Controls.Add(btnContaAlterar);
            grbTemplateContaPagar.Controls.Add(lblContaPagarDataCriacao);
            grbTemplateContaPagar.Controls.Add(rtbContaPagarMensagemAdicional);
            grbTemplateContaPagar.Controls.Add(lblContaPagarMensagemAdicional);
            grbTemplateContaPagar.Controls.Add(cboContaPagarTipoCadastro);
            grbTemplateContaPagar.Controls.Add(lblContaPagarTipoCadastro);
            grbTemplateContaPagar.Controls.Add(cboContaPagarFrequencia);
            grbTemplateContaPagar.Controls.Add(lblContaPagarFrequencia);
            grbTemplateContaPagar.Controls.Add(dtpEdicaoContaDataCompraOuAcordo);
            grbTemplateContaPagar.Controls.Add(lblContaPagarDataCompra);
            grbTemplateContaPagar.Controls.Add(txtContaPagarValor);
            grbTemplateContaPagar.Controls.Add(lblContaPagarValor);
            grbTemplateContaPagar.Controls.Add(lblContaPagarNameDescription);
            grbTemplateContaPagar.Controls.Add(txtContaPagarNameDescription);
            grbTemplateContaPagar.Controls.Add(lblContaPagarCategory);
            grbTemplateContaPagar.Controls.Add(cboContaPagarCategory);
            grbTemplateContaPagar.Controls.Add(cboContaPagarAnoMesInicial);
            grbTemplateContaPagar.Controls.Add(lblContaPagarTipoConta);
            grbTemplateContaPagar.Controls.Add(lblContaPagarAnoMes);
            grbTemplateContaPagar.Controls.Add(cboContaPagarTipoConta);
            grbTemplateContaPagar.Location = new Point(12, 12);
            grbTemplateContaPagar.Name = "grbTemplateContaPagar";
            grbTemplateContaPagar.Size = new Size(1181, 283);
            grbTemplateContaPagar.TabIndex = 16;
            grbTemplateContaPagar.TabStop = false;
            grbTemplateContaPagar.Text = "Editar uma conta";
            // 
            // txtValorManipulado
            // 
            txtValorManipulado.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtValorManipulado.ForeColor = Color.OrangeRed;
            txtValorManipulado.Location = new Point(684, 60);
            txtValorManipulado.Name = "txtValorManipulado";
            txtValorManipulado.Size = new Size(207, 27);
            txtValorManipulado.TabIndex = 38;
            txtValorManipulado.TextAlign = HorizontalAlignment.Right;
            txtValorManipulado.Enter += TxtValorManipulado_Enter;
            txtValorManipulado.Leave += TxtValorManipulado_Leave;
            // 
            // lblValorManipulado
            // 
            lblValorManipulado.AutoSize = true;
            lblValorManipulado.Location = new Point(559, 66);
            lblValorManipulado.Name = "lblValorManipulado";
            lblValorManipulado.Size = new Size(119, 15);
            lblValorManipulado.TabIndex = 37;
            lblValorManipulado.Text = "Valor Manipulado R$:";
            // 
            // cboHabilitarDataCompraOuAcordo
            // 
            cboHabilitarDataCompraOuAcordo.AutoSize = true;
            cboHabilitarDataCompraOuAcordo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboHabilitarDataCompraOuAcordo.Location = new Point(673, 101);
            cboHabilitarDataCompraOuAcordo.Name = "cboHabilitarDataCompraOuAcordo";
            cboHabilitarDataCompraOuAcordo.Size = new Size(218, 17);
            cboHabilitarDataCompraOuAcordo.TabIndex = 36;
            cboHabilitarDataCompraOuAcordo.Text = "Habilitar Data de Compra ou Acordo?";
            cboHabilitarDataCompraOuAcordo.UseVisualStyleBackColor = true;
            cboHabilitarDataCompraOuAcordo.CheckedChanged += CboHabilitarDataCompra_CheckedChanged;
            // 
            // rdbContaPagaOuRecebida_Nao
            // 
            rdbContaPagaOuRecebida_Nao.AutoSize = true;
            rdbContaPagaOuRecebida_Nao.Location = new Point(768, 247);
            rdbContaPagaOuRecebida_Nao.Name = "rdbContaPagaOuRecebida_Nao";
            rdbContaPagaOuRecebida_Nao.Size = new Size(77, 19);
            rdbContaPagaOuRecebida_Nao.TabIndex = 35;
            rdbContaPagaOuRecebida_Nao.Text = "Não Pago";
            rdbContaPagaOuRecebida_Nao.UseVisualStyleBackColor = true;
            // 
            // rdbContaPagaOuRecebida_Sim
            // 
            rdbContaPagaOuRecebida_Sim.AutoSize = true;
            rdbContaPagaOuRecebida_Sim.Checked = true;
            rdbContaPagaOuRecebida_Sim.Location = new Point(684, 247);
            rdbContaPagaOuRecebida_Sim.Name = "rdbContaPagaOuRecebida_Sim";
            rdbContaPagaOuRecebida_Sim.Size = new Size(52, 19);
            rdbContaPagaOuRecebida_Sim.TabIndex = 34;
            rdbContaPagaOuRecebida_Sim.TabStop = true;
            rdbContaPagaOuRecebida_Sim.Text = "Pago";
            rdbContaPagaOuRecebida_Sim.UseVisualStyleBackColor = true;
            // 
            // txtContaPagarDataPagamentoOuRecebimento
            // 
            txtContaPagarDataPagamentoOuRecebimento.Location = new Point(654, 218);
            txtContaPagarDataPagamentoOuRecebimento.Name = "txtContaPagarDataPagamentoOuRecebimento";
            txtContaPagarDataPagamentoOuRecebimento.Size = new Size(237, 23);
            txtContaPagarDataPagamentoOuRecebimento.TabIndex = 33;
            // 
            // lblContaPagarDataPagamentoOuRecebimento
            // 
            lblContaPagarDataPagamentoOuRecebimento.AutoSize = true;
            lblContaPagarDataPagamentoOuRecebimento.Location = new Point(441, 221);
            lblContaPagarDataPagamentoOuRecebimento.Name = "lblContaPagarDataPagamentoOuRecebimento";
            lblContaPagarDataPagamentoOuRecebimento.Size = new Size(207, 15);
            lblContaPagarDataPagamentoOuRecebimento.TabIndex = 32;
            lblContaPagarDataPagamentoOuRecebimento.Text = "Data de Pagamento ou Recebimento: ";
            lblContaPagarDataPagamentoOuRecebimento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpContaDataVencimento
            // 
            dtpContaDataVencimento.Location = new Point(654, 168);
            dtpContaDataVencimento.Name = "dtpContaDataVencimento";
            dtpContaDataVencimento.Size = new Size(237, 23);
            dtpContaDataVencimento.TabIndex = 31;
            // 
            // lblContaPagarDataVencimento
            // 
            lblContaPagarDataVencimento.AutoSize = true;
            lblContaPagarDataVencimento.Location = new Point(532, 174);
            lblContaPagarDataVencimento.Name = "lblContaPagarDataVencimento";
            lblContaPagarDataVencimento.Size = new Size(116, 15);
            lblContaPagarDataVencimento.TabIndex = 30;
            lblContaPagarDataVencimento.Text = "Data de Vencimento:";
            // 
            // btnContaAlterar
            // 
            btnContaAlterar.AutoSize = true;
            btnContaAlterar.FlatStyle = FlatStyle.System;
            btnContaAlterar.Location = new Point(957, 220);
            btnContaAlterar.Name = "btnContaAlterar";
            btnContaAlterar.Size = new Size(176, 34);
            btnContaAlterar.TabIndex = 29;
            btnContaAlterar.Text = "Efetuar alteração";
            btnContaAlterar.UseVisualStyleBackColor = true;
            btnContaAlterar.Click += BtnContaPagarEditar_Click;
            // 
            // lblContaPagarDataCriacao
            // 
            lblContaPagarDataCriacao.AutoSize = true;
            lblContaPagarDataCriacao.Location = new Point(937, 192);
            lblContaPagarDataCriacao.Name = "lblContaPagarDataCriacao";
            lblContaPagarDataCriacao.Size = new Size(213, 15);
            lblContaPagarDataCriacao.TabIndex = 27;
            lblContaPagarDataCriacao.Text = "Data de Criação: 15/03/1995 às 05:35:01";
            // 
            // rtbContaPagarMensagemAdicional
            // 
            rtbContaPagarMensagemAdicional.Location = new Point(930, 36);
            rtbContaPagarMensagemAdicional.Name = "rtbContaPagarMensagemAdicional";
            rtbContaPagarMensagemAdicional.Size = new Size(242, 148);
            rtbContaPagarMensagemAdicional.TabIndex = 26;
            rtbContaPagarMensagemAdicional.Text = "";
            // 
            // lblContaPagarMensagemAdicional
            // 
            lblContaPagarMensagemAdicional.AutoSize = true;
            lblContaPagarMensagemAdicional.Location = new Point(920, 14);
            lblContaPagarMensagemAdicional.Name = "lblContaPagarMensagemAdicional";
            lblContaPagarMensagemAdicional.Size = new Size(122, 15);
            lblContaPagarMensagemAdicional.TabIndex = 24;
            lblContaPagarMensagemAdicional.Text = "Mensagem Adicional:";
            // 
            // cboContaPagarTipoCadastro
            // 
            cboContaPagarTipoCadastro.FormattingEnabled = true;
            cboContaPagarTipoCadastro.Location = new Point(116, 206);
            cboContaPagarTipoCadastro.Name = "cboContaPagarTipoCadastro";
            cboContaPagarTipoCadastro.Size = new Size(204, 23);
            cboContaPagarTipoCadastro.TabIndex = 23;
            // 
            // lblContaPagarTipoCadastro
            // 
            lblContaPagarTipoCadastro.AutoSize = true;
            lblContaPagarTipoCadastro.Location = new Point(11, 209);
            lblContaPagarTipoCadastro.Name = "lblContaPagarTipoCadastro";
            lblContaPagarTipoCadastro.Size = new Size(99, 15);
            lblContaPagarTipoCadastro.TabIndex = 22;
            lblContaPagarTipoCadastro.Text = "Tipo de Cadastro:";
            // 
            // cboContaPagarFrequencia
            // 
            cboContaPagarFrequencia.FormattingEnabled = true;
            cboContaPagarFrequencia.Location = new Point(116, 248);
            cboContaPagarFrequencia.Name = "cboContaPagarFrequencia";
            cboContaPagarFrequencia.Size = new Size(161, 23);
            cboContaPagarFrequencia.TabIndex = 21;
            // 
            // lblContaPagarFrequencia
            // 
            lblContaPagarFrequencia.AutoSize = true;
            lblContaPagarFrequencia.Location = new Point(42, 251);
            lblContaPagarFrequencia.Name = "lblContaPagarFrequencia";
            lblContaPagarFrequencia.Size = new Size(68, 15);
            lblContaPagarFrequencia.TabIndex = 20;
            lblContaPagarFrequencia.Text = "Frequência:";
            // 
            // dtpEdicaoContaDataCompraOuAcordo
            // 
            dtpEdicaoContaDataCompraOuAcordo.Location = new Point(654, 124);
            dtpEdicaoContaDataCompraOuAcordo.Name = "dtpEdicaoContaDataCompraOuAcordo";
            dtpEdicaoContaDataCompraOuAcordo.Size = new Size(237, 23);
            dtpEdicaoContaDataCompraOuAcordo.TabIndex = 17;
            // 
            // lblContaPagarDataCompra
            // 
            lblContaPagarDataCompra.AutoSize = true;
            lblContaPagarDataCompra.Location = new Point(493, 128);
            lblContaPagarDataCompra.Name = "lblContaPagarDataCompra";
            lblContaPagarDataCompra.Size = new Size(155, 15);
            lblContaPagarDataCompra.TabIndex = 16;
            lblContaPagarDataCompra.Text = "Data da Compra ou Acordo:";
            lblContaPagarDataCompra.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtContaPagarValor
            // 
            txtContaPagarValor.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtContaPagarValor.ForeColor = Color.OrangeRed;
            txtContaPagarValor.Location = new Point(684, 22);
            txtContaPagarValor.Name = "txtContaPagarValor";
            txtContaPagarValor.Size = new Size(207, 27);
            txtContaPagarValor.TabIndex = 13;
            txtContaPagarValor.TextAlign = HorizontalAlignment.Right;
            txtContaPagarValor.Enter += TxtContaPagarValor_Enter;
            txtContaPagarValor.Leave += TxtContaPagarValor_Leave;
            // 
            // lblContaPagarValor
            // 
            lblContaPagarValor.AutoSize = true;
            lblContaPagarValor.Location = new Point(626, 25);
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
            // txtContaPagarNameDescription
            // 
            txtContaPagarNameDescription.Location = new Point(116, 32);
            txtContaPagarNameDescription.Name = "txtContaPagarNameDescription";
            txtContaPagarNameDescription.Size = new Size(445, 23);
            txtContaPagarNameDescription.TabIndex = 1;
            // 
            // lblContaPagarCategory
            // 
            lblContaPagarCategory.AutoSize = true;
            lblContaPagarCategory.Location = new Point(49, 78);
            lblContaPagarCategory.Name = "lblContaPagarCategory";
            lblContaPagarCategory.Size = new Size(61, 15);
            lblContaPagarCategory.TabIndex = 2;
            lblContaPagarCategory.Text = "Categoria:";
            // 
            // cboContaPagarCategory
            // 
            cboContaPagarCategory.FormattingEnabled = true;
            cboContaPagarCategory.Location = new Point(116, 75);
            cboContaPagarCategory.Name = "cboContaPagarCategory";
            cboContaPagarCategory.Size = new Size(188, 23);
            cboContaPagarCategory.TabIndex = 3;
            // 
            // cboContaPagarAnoMesInicial
            // 
            cboContaPagarAnoMesInicial.FormattingEnabled = true;
            cboContaPagarAnoMesInicial.Location = new Point(116, 118);
            cboContaPagarAnoMesInicial.Name = "cboContaPagarAnoMesInicial";
            cboContaPagarAnoMesInicial.Size = new Size(161, 23);
            cboContaPagarAnoMesInicial.TabIndex = 8;
            // 
            // lblContaPagarTipoConta
            // 
            lblContaPagarTipoConta.AutoSize = true;
            lblContaPagarTipoConta.Location = new Point(28, 169);
            lblContaPagarTipoConta.Name = "lblContaPagarTipoConta";
            lblContaPagarTipoConta.Size = new Size(84, 15);
            lblContaPagarTipoConta.TabIndex = 4;
            lblContaPagarTipoConta.Text = "Tipo de Conta:";
            // 
            // lblContaPagarAnoMes
            // 
            lblContaPagarAnoMes.AutoSize = true;
            lblContaPagarAnoMes.Location = new Point(53, 124);
            lblContaPagarAnoMes.Name = "lblContaPagarAnoMes";
            lblContaPagarAnoMes.Size = new Size(59, 15);
            lblContaPagarAnoMes.TabIndex = 7;
            lblContaPagarAnoMes.Text = "Ano/Mês:";
            // 
            // cboContaPagarTipoConta
            // 
            cboContaPagarTipoConta.FormattingEnabled = true;
            cboContaPagarTipoConta.Location = new Point(116, 166);
            cboContaPagarTipoConta.Name = "cboContaPagarTipoConta";
            cboContaPagarTipoConta.Size = new Size(395, 23);
            cboContaPagarTipoConta.TabIndex = 5;
            // 
            // FrmEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(1208, 307);
            Controls.Add(grbTemplateContaPagar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edição de uma Conta";
            Load += FrmEdit_Load;
            grbTemplateContaPagar.ResumeLayout(false);
            grbTemplateContaPagar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbTemplateContaPagar;
        private Button btnContaAlterar;
        private Label lblContaPagarDataCriacao;
        private RichTextBox rtbContaPagarMensagemAdicional;
        private Label lblContaPagarMensagemAdicional;
        private ComboBox cboContaPagarTipoCadastro;
        private Label lblContaPagarTipoCadastro;
        private ComboBox cboContaPagarFrequencia;
        private Label lblContaPagarFrequencia;
        private ComboBox cboContaPagarMelhorDiaPagamento;
        private Label lblContaPagarMelhorDiaPagamento;
        private DateTimePicker dtpEdicaoContaDataCompraOuAcordo;
        private Label lblContaPagarDataCompra;
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
        private Label lblContaPagarAnoMes;
        private ComboBox cboContaPagarTipoConta;
        private DateTimePicker dtpContaDataVencimento;
        private Label lblContaPagarDataVencimento;
        private TextBox txtContaPagarDataPagamentoOuRecebimento;
        private Label lblContaPagarDataPagamentoOuRecebimento;
        private RadioButton rdbContaPagaOuRecebida_Nao;
        private RadioButton rdbContaPagaOuRecebida_Sim;
        private CheckBox cboHabilitarDataCompraOuAcordo;
        private TextBox txtValorManipulado;
        private Label lblValorManipulado;
    }
}