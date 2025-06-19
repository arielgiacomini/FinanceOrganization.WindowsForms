namespace App.WindowsForms.Forms.Excluir
{
    partial class Relacionado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relacionado));
            dgvRegistroRelacionado = new DataGridView();
            lblInformacoesTotais = new Label();
            lblRegistrosSelecionados = new Label();
            lblValorMedioTotalLista = new Label();
            lblValorTotalMedioSelecionados = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroRelacionado).BeginInit();
            SuspendLayout();
            // 
            // dgvRegistroRelacionado
            // 
            dgvRegistroRelacionado.AllowUserToAddRows = false;
            dgvRegistroRelacionado.AllowUserToDeleteRows = false;
            dgvRegistroRelacionado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRegistroRelacionado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRegistroRelacionado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvRegistroRelacionado.BackgroundColor = SystemColors.AppWorkspace;
            dgvRegistroRelacionado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvRegistroRelacionado.DefaultCellStyle = dataGridViewCellStyle1;
            dgvRegistroRelacionado.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvRegistroRelacionado.Location = new Point(12, 37);
            dgvRegistroRelacionado.Name = "dgvRegistroRelacionado";
            dgvRegistroRelacionado.ReadOnly = true;
            dgvRegistroRelacionado.RowTemplate.Height = 25;
            dgvRegistroRelacionado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistroRelacionado.Size = new Size(1257, 331);
            dgvRegistroRelacionado.TabIndex = 1;
            dgvRegistroRelacionado.SelectionChanged += DgvRegistroRelacionado_SelectionChanged;
            // 
            // lblInformacoesTotais
            // 
            lblInformacoesTotais.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInformacoesTotais.AutoSize = true;
            lblInformacoesTotais.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblInformacoesTotais.Location = new Point(410, 8);
            lblInformacoesTotais.Name = "lblInformacoesTotais";
            lblInformacoesTotais.RightToLeft = RightToLeft.Yes;
            lblInformacoesTotais.Size = new Size(230, 21);
            lblInformacoesTotais.TabIndex = 17;
            lblInformacoesTotais.Text = "Itens Totais: 1 - R$ 100.400,00";
            lblInformacoesTotais.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRegistrosSelecionados
            // 
            lblRegistrosSelecionados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRegistrosSelecionados.AutoSize = true;
            lblRegistrosSelecionados.Location = new Point(1072, 19);
            lblRegistrosSelecionados.Name = "lblRegistrosSelecionados";
            lblRegistrosSelecionados.RightToLeft = RightToLeft.Yes;
            lblRegistrosSelecionados.Size = new Size(197, 15);
            lblRegistrosSelecionados.TabIndex = 18;
            lblRegistrosSelecionados.Text = "Itens Selecionados: 1 - R$ 100.400,00";
            lblRegistrosSelecionados.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorMedioTotalLista
            // 
            lblValorMedioTotalLista.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblValorMedioTotalLista.AutoSize = true;
            lblValorMedioTotalLista.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorMedioTotalLista.ForeColor = SystemColors.Highlight;
            lblValorMedioTotalLista.Location = new Point(61, 4);
            lblValorMedioTotalLista.Name = "lblValorMedioTotalLista";
            lblValorMedioTotalLista.RightToLeft = RightToLeft.Yes;
            lblValorMedioTotalLista.Size = new Size(258, 32);
            lblValorMedioTotalLista.TabIndex = 20;
            lblValorMedioTotalLista.Text = "Valor Médio Total: R$ 1.400,00";
            lblValorMedioTotalLista.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorTotalMedioSelecionados
            // 
            lblValorTotalMedioSelecionados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblValorTotalMedioSelecionados.AutoSize = true;
            lblValorTotalMedioSelecionados.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorTotalMedioSelecionados.ForeColor = SystemColors.Highlight;
            lblValorTotalMedioSelecionados.Location = new Point(694, 4);
            lblValorTotalMedioSelecionados.Name = "lblValorTotalMedioSelecionados";
            lblValorTotalMedioSelecionados.RightToLeft = RightToLeft.Yes;
            lblValorTotalMedioSelecionados.Size = new Size(320, 32);
            lblValorTotalMedioSelecionados.TabIndex = 21;
            lblValorTotalMedioSelecionados.Text = "Valor Médio Selecionados: R$ 1.400,00";
            lblValorTotalMedioSelecionados.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Relacionado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 380);
            Controls.Add(lblValorTotalMedioSelecionados);
            Controls.Add(lblValorMedioTotalLista);
            Controls.Add(lblRegistrosSelecionados);
            Controls.Add(lblInformacoesTotais);
            Controls.Add(dgvRegistroRelacionado);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Relacionado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalhes - Registros Relacionados";
            Load += FrmRegistroRelacionado_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRegistroRelacionado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRegistroRelacionado;
        private Label lblInformacoesTotais;
        private Label lblRegistrosSelecionados;
        private Label lblValorMedioTotalLista;
        private Label lblValorTotalMedioSelecionados;
    }
}