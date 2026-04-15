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
            lblValorMedioTotalLista = new Label();
            lblValorTotalMedioSelecionados = new Label();
            lblValorRestanteRegistroRelacionadoDataGridView = new Label();
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
            dgvRegistroRelacionado.Location = new Point(12, 51);
            dgvRegistroRelacionado.Name = "dgvRegistroRelacionado";
            dgvRegistroRelacionado.ReadOnly = true;
            dgvRegistroRelacionado.RowTemplate.Height = 25;
            dgvRegistroRelacionado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistroRelacionado.Size = new Size(1257, 397);
            dgvRegistroRelacionado.TabIndex = 1;
            dgvRegistroRelacionado.SelectionChanged += DgvRegistroRelacionado_SelectionChanged;
            // 
            // lblInformacoesTotais
            // 
            lblInformacoesTotais.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblInformacoesTotais.AutoSize = true;
            lblInformacoesTotais.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblInformacoesTotais.Location = new Point(1111, 451);
            lblInformacoesTotais.Name = "lblInformacoesTotais";
            lblInformacoesTotais.RightToLeft = RightToLeft.Yes;
            lblInformacoesTotais.Size = new Size(158, 15);
            lblInformacoesTotais.TabIndex = 17;
            lblInformacoesTotais.Text = "Itens Totais: 1 - R$ 100.400,00";
            lblInformacoesTotais.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorMedioTotalLista
            // 
            lblValorMedioTotalLista.AutoSize = true;
            lblValorMedioTotalLista.Font = new Font("Dubai", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorMedioTotalLista.ForeColor = SystemColors.Highlight;
            lblValorMedioTotalLista.Location = new Point(12, 30);
            lblValorMedioTotalLista.Name = "lblValorMedioTotalLista";
            lblValorMedioTotalLista.RightToLeft = RightToLeft.Yes;
            lblValorMedioTotalLista.Size = new Size(181, 22);
            lblValorMedioTotalLista.TabIndex = 20;
            lblValorMedioTotalLista.Text = "Valor Médio Total: R$ 1.400,00";
            lblValorMedioTotalLista.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorTotalMedioSelecionados
            // 
            lblValorTotalMedioSelecionados.AutoSize = true;
            lblValorTotalMedioSelecionados.Font = new Font("Dubai", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorTotalMedioSelecionados.ForeColor = SystemColors.Highlight;
            lblValorTotalMedioSelecionados.Location = new Point(12, 8);
            lblValorTotalMedioSelecionados.Name = "lblValorTotalMedioSelecionados";
            lblValorTotalMedioSelecionados.RightToLeft = RightToLeft.Yes;
            lblValorTotalMedioSelecionados.Size = new Size(223, 22);
            lblValorTotalMedioSelecionados.TabIndex = 21;
            lblValorTotalMedioSelecionados.Text = "Valor Médio Selecionados: R$ 1.400,00";
            lblValorTotalMedioSelecionados.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorRestanteRegistroRelacionadoDataGridView
            // 
            lblValorRestanteRegistroRelacionadoDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblValorRestanteRegistroRelacionadoDataGridView.AutoSize = true;
            lblValorRestanteRegistroRelacionadoDataGridView.Location = new Point(990, 33);
            lblValorRestanteRegistroRelacionadoDataGridView.Name = "lblValorRestanteRegistroRelacionadoDataGridView";
            lblValorRestanteRegistroRelacionadoDataGridView.Size = new Size(279, 15);
            lblValorRestanteRegistroRelacionadoDataGridView.TabIndex = 26;
            lblValorRestanteRegistroRelacionadoDataGridView.Text = "Valor Total dos 900 itens selecionados: R$ 100.400,00";
            lblValorRestanteRegistroRelacionadoDataGridView.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Relacionado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 475);
            Controls.Add(lblValorRestanteRegistroRelacionadoDataGridView);
            Controls.Add(lblValorTotalMedioSelecionados);
            Controls.Add(lblValorMedioTotalLista);
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
        private Label lblValorMedioTotalLista;
        private Label lblValorTotalMedioSelecionados;
        private Label lblValorRestanteRegistroRelacionadoDataGridView;
    }
}