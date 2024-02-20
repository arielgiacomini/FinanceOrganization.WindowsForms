namespace App.WindowsForms.Forms.ExcluirDetalhes
{
    partial class FrmExibirDetalhes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExibirDetalhes));
            dgvExcluirDetalhes = new DataGridView();
            lblExcluirDetalhesItensSelecionadosDataGridView = new Label();
            btnExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExcluirDetalhes).BeginInit();
            SuspendLayout();
            // 
            // dgvExcluirDetalhes
            // 
            dgvExcluirDetalhes.AllowUserToAddRows = false;
            dgvExcluirDetalhes.AllowUserToDeleteRows = false;
            dgvExcluirDetalhes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExcluirDetalhes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvExcluirDetalhes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvExcluirDetalhes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExcluirDetalhes.Location = new Point(12, 49);
            dgvExcluirDetalhes.Name = "dgvExcluirDetalhes";
            dgvExcluirDetalhes.RowTemplate.Height = 25;
            dgvExcluirDetalhes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExcluirDetalhes.Size = new Size(1153, 273);
            dgvExcluirDetalhes.TabIndex = 0;
            dgvExcluirDetalhes.RowsAdded += DgvExcluirDetalhes_RowsAdded;
            dgvExcluirDetalhes.SelectionChanged += DgvExcluirDetalhes_SelectionChanged;
            // 
            // lblExcluirDetalhesItensSelecionadosDataGridView
            // 
            lblExcluirDetalhesItensSelecionadosDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblExcluirDetalhesItensSelecionadosDataGridView.AutoSize = true;
            lblExcluirDetalhesItensSelecionadosDataGridView.Location = new Point(968, 31);
            lblExcluirDetalhesItensSelecionadosDataGridView.Name = "lblExcluirDetalhesItensSelecionadosDataGridView";
            lblExcluirDetalhesItensSelecionadosDataGridView.RightToLeft = RightToLeft.Yes;
            lblExcluirDetalhesItensSelecionadosDataGridView.Size = new Size(197, 15);
            lblExcluirDetalhesItensSelecionadosDataGridView.TabIndex = 16;
            lblExcluirDetalhesItensSelecionadosDataGridView.Text = "Itens Selecionados: 1 - R$ 100.400,00";
            lblExcluirDetalhesItensSelecionadosDataGridView.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcluir.ForeColor = SystemColors.ButtonFace;
            btnExcluir.Location = new Point(12, 12);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(150, 31);
            btnExcluir.TabIndex = 17;
            btnExcluir.Text = "Excluir Registro(s)";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += BtnExcluir_Click;
            // 
            // FrmExibirDetalhes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 334);
            Controls.Add(btnExcluir);
            Controls.Add(lblExcluirDetalhesItensSelecionadosDataGridView);
            Controls.Add(dgvExcluirDetalhes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmExibirDetalhes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Indicar os itens para exclusão";
            Load += FrmExcluirDetalhes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExcluirDetalhes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvExcluirDetalhes;
        private Label lblExcluirDetalhesItensSelecionadosDataGridView;
        private Button btnExcluir;
    }
}