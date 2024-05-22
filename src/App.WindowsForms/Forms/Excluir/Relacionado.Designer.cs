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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relacionado));
            dgvRegistroRelacionado = new DataGridView();
            lblInformacoesTotais = new Label();
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRegistroRelacionado.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRegistroRelacionado.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvRegistroRelacionado.Location = new Point(12, 37);
            dgvRegistroRelacionado.Name = "dgvRegistroRelacionado";
            dgvRegistroRelacionado.ReadOnly = true;
            dgvRegistroRelacionado.RowTemplate.Height = 25;
            dgvRegistroRelacionado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistroRelacionado.Size = new Size(1257, 271);
            dgvRegistroRelacionado.TabIndex = 1;
            // 
            // lblInformacoesTotais
            // 
            lblInformacoesTotais.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInformacoesTotais.AutoSize = true;
            lblInformacoesTotais.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblInformacoesTotais.Location = new Point(533, 9);
            lblInformacoesTotais.Name = "lblInformacoesTotais";
            lblInformacoesTotais.RightToLeft = RightToLeft.Yes;
            lblInformacoesTotais.Size = new Size(230, 21);
            lblInformacoesTotais.TabIndex = 17;
            lblInformacoesTotais.Text = "Itens Totais: 1 - R$ 100.400,00";
            lblInformacoesTotais.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Relacionado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 320);
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
    }
}