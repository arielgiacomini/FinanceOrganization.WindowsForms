namespace App.WindowsForms.Forms.ExcluirDetalhes
{
    partial class FrmExcluirDetalhes
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
            dgvExcluirDetalhes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvExcluirDetalhes).BeginInit();
            SuspendLayout();
            // 
            // dgvExcluirDetalhes
            // 
            dgvExcluirDetalhes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExcluirDetalhes.Location = new Point(12, 34);
            dgvExcluirDetalhes.Name = "dgvExcluirDetalhes";
            dgvExcluirDetalhes.RowTemplate.Height = 25;
            dgvExcluirDetalhes.Size = new Size(950, 404);
            dgvExcluirDetalhes.TabIndex = 0;
            // 
            // FrmExcluirDetalhes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 450);
            Controls.Add(dgvExcluirDetalhes);
            Name = "FrmExcluirDetalhes";
            Text = "ExcluirDetalhes";
            Load += FrmExcluirDetalhes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExcluirDetalhes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvExcluirDetalhes;
    }
}