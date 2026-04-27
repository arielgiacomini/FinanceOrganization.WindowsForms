using System.Windows.Forms;

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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExibirDetalhes));
            dgvExcluirDetalhes = new DataGridView();
            lblValorTotalExibirDetalhesDataGridView = new Label();
            btnExcluir = new Button();
            btnShowDetails = new Button();
            lblValorMedioOnlyPagos = new Label();
            lblTotaisRegistrosEValores = new Label();
            lblRunTimeLoad = new Label();
            btnAtualizar = new Button();
            lblValorRestanteExibirDetalhesDataGridView = new Label();
            lblValorRealizadoExibirDetalhesDataGridView = new Label();
            cmsDgvExcluirDetalhesActions = new ContextMenuStrip(components);
            toolEditarRegistro = new ToolStripMenuItem();
            toolDesabilitarRegistro = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvExcluirDetalhes).BeginInit();
            cmsDgvExcluirDetalhesActions.SuspendLayout();
            SuspendLayout();
            // 
            // dgvExcluirDetalhes
            // 
            dgvExcluirDetalhes.AllowUserToAddRows = false;
            dgvExcluirDetalhes.AllowUserToDeleteRows = false;
            dgvExcluirDetalhes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExcluirDetalhes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvExcluirDetalhes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvExcluirDetalhes.BackgroundColor = SystemColors.AppWorkspace;
            dgvExcluirDetalhes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvExcluirDetalhes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvExcluirDetalhes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvExcluirDetalhes.Location = new Point(12, 87);
            dgvExcluirDetalhes.Name = "dgvExcluirDetalhes";
            dgvExcluirDetalhes.ReadOnly = true;
            dgvExcluirDetalhes.RowTemplate.Height = 25;
            dgvExcluirDetalhes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExcluirDetalhes.Size = new Size(1340, 474);
            dgvExcluirDetalhes.TabIndex = 0;
            dgvExcluirDetalhes.RowsAdded += DgvExcluirDetalhes_RowsAdded;
            dgvExcluirDetalhes.SelectionChanged += DgvExcluirDetalhes_SelectionChanged;
            // 
            // lblValorTotalExibirDetalhesDataGridView
            // 
            lblValorTotalExibirDetalhesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblValorTotalExibirDetalhesDataGridView.Location = new Point(1073, 69);
            lblValorTotalExibirDetalhesDataGridView.Name = "lblValorTotalExibirDetalhesDataGridView";
            lblValorTotalExibirDetalhesDataGridView.RightToLeft = RightToLeft.No;
            lblValorTotalExibirDetalhesDataGridView.Size = new Size(279, 15);
            lblValorTotalExibirDetalhesDataGridView.TabIndex = 16;
            lblValorTotalExibirDetalhesDataGridView.Text = "Valor Total dos 900 itens selecionados: R$ 100.400,00";
            lblValorTotalExibirDetalhesDataGridView.TextAlign = ContentAlignment.MiddleRight;
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
            // btnShowDetails
            // 
            btnShowDetails.BackColor = Color.MediumBlue;
            btnShowDetails.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnShowDetails.ForeColor = SystemColors.ButtonFace;
            btnShowDetails.Location = new Point(168, 12);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(150, 31);
            btnShowDetails.TabIndex = 18;
            btnShowDetails.Text = "Detalhes Registro(s)";
            btnShowDetails.UseVisualStyleBackColor = false;
            btnShowDetails.Click += BtnShowDetails_Click;
            // 
            // lblValorMedioOnlyPagos
            // 
            lblValorMedioOnlyPagos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblValorMedioOnlyPagos.AutoSize = true;
            lblValorMedioOnlyPagos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorMedioOnlyPagos.ForeColor = SystemColors.Highlight;
            lblValorMedioOnlyPagos.Location = new Point(13, 46);
            lblValorMedioOnlyPagos.Name = "lblValorMedioOnlyPagos";
            lblValorMedioOnlyPagos.RightToLeft = RightToLeft.Yes;
            lblValorMedioOnlyPagos.Size = new Size(149, 22);
            lblValorMedioOnlyPagos.TabIndex = 19;
            lblValorMedioOnlyPagos.Text = "Valor Médio: R$ 1.400,00";
            lblValorMedioOnlyPagos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotaisRegistrosEValores
            // 
            lblTotaisRegistrosEValores.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotaisRegistrosEValores.Location = new Point(1092, 566);
            lblTotaisRegistrosEValores.Margin = new Padding(3, 0, 0, 0);
            lblTotaisRegistrosEValores.Name = "lblTotaisRegistrosEValores";
            lblTotaisRegistrosEValores.RightToLeft = RightToLeft.Yes;
            lblTotaisRegistrosEValores.Size = new Size(260, 15);
            lblTotaisRegistrosEValores.TabIndex = 20;
            lblTotaisRegistrosEValores.Text = "Quantidade de Registros: 1 - Total: R$ 100.400,00";
            lblTotaisRegistrosEValores.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRunTimeLoad
            // 
            lblRunTimeLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRunTimeLoad.AutoSize = true;
            lblRunTimeLoad.Location = new Point(12, 564);
            lblRunTimeLoad.Name = "lblRunTimeLoad";
            lblRunTimeLoad.RightToLeft = RightToLeft.Yes;
            lblRunTimeLoad.Size = new Size(64, 15);
            lblRunTimeLoad.TabIndex = 21;
            lblRunTimeLoad.Text = "00:00:01.00";
            lblRunTimeLoad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAtualizar.BackColor = Color.LawnGreen;
            btnAtualizar.ForeColor = SystemColors.ControlDarkDark;
            btnAtualizar.Location = new Point(1266, 5);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(86, 23);
            btnAtualizar.TabIndex = 22;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += BtnAtualizar_Click;
            // 
            // lblValorRestanteExibirDetalhesDataGridView
            // 
            lblValorRestanteExibirDetalhesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblValorRestanteExibirDetalhesDataGridView.Location = new Point(1053, 31);
            lblValorRestanteExibirDetalhesDataGridView.Name = "lblValorRestanteExibirDetalhesDataGridView";
            lblValorRestanteExibirDetalhesDataGridView.Size = new Size(299, 15);
            lblValorRestanteExibirDetalhesDataGridView.TabIndex = 23;
            lblValorRestanteExibirDetalhesDataGridView.Text = "Valor Restante dos 900 itens selecionados: R$ 100.400,00";
            lblValorRestanteExibirDetalhesDataGridView.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorRealizadoExibirDetalhesDataGridView
            // 
            lblValorRealizadoExibirDetalhesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblValorRealizadoExibirDetalhesDataGridView.Location = new Point(1048, 49);
            lblValorRealizadoExibirDetalhesDataGridView.Name = "lblValorRealizadoExibirDetalhesDataGridView";
            lblValorRealizadoExibirDetalhesDataGridView.Size = new Size(304, 15);
            lblValorRealizadoExibirDetalhesDataGridView.TabIndex = 24;
            lblValorRealizadoExibirDetalhesDataGridView.Text = "Valor Realizado dos 900 itens selecionados: R$ 100.400,00";
            lblValorRealizadoExibirDetalhesDataGridView.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmsDgvExcluirDetalhesActions
            // 
            cmsDgvExcluirDetalhesActions.Items.AddRange(new ToolStripItem[] { toolEditarRegistro, toolDesabilitarRegistro });
            cmsDgvExcluirDetalhesActions.Name = "cmsDgvExcluirDetalhesActions";
            cmsDgvExcluirDetalhesActions.Size = new Size(181, 70);
            // 
            // toolEditarRegistro
            // 
            toolEditarRegistro.Name = "toolEditarRegistro";
            toolEditarRegistro.Size = new Size(180, 22);
            toolEditarRegistro.Text = "Editar Registro";
            toolEditarRegistro.Click += ToolEditarRegistro_Click;
            // 
            // toolDesabilitarRegistro
            // 
            toolDesabilitarRegistro.Name = "toolDesabilitarRegistro";
            toolDesabilitarRegistro.Size = new Size(180, 22);
            toolDesabilitarRegistro.Text = "Desabilitar Registro";
            toolDesabilitarRegistro.Click += ToolDesabilitarRegistro_Click;
            // 
            // FrmExibirDetalhes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 590);
            Controls.Add(lblValorRealizadoExibirDetalhesDataGridView);
            Controls.Add(lblValorRestanteExibirDetalhesDataGridView);
            Controls.Add(btnAtualizar);
            Controls.Add(lblRunTimeLoad);
            Controls.Add(lblTotaisRegistrosEValores);
            Controls.Add(lblValorMedioOnlyPagos);
            Controls.Add(btnShowDetails);
            Controls.Add(btnExcluir);
            Controls.Add(lblValorTotalExibirDetalhesDataGridView);
            Controls.Add(dgvExcluirDetalhes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmExibirDetalhes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista todos os itens relacionados a conta selecionada";
            Load += FrmExcluirDetalhes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExcluirDetalhes).EndInit();
            cmsDgvExcluirDetalhesActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvExcluirDetalhes;
        private Label lblValorTotalExibirDetalhesDataGridView;
        private Button btnExcluir;
        private Button btnShowDetails;
        private Label lblValorMedioOnlyPagos;
        private Label lblTotaisRegistrosEValores;
        private Label lblRunTimeLoad;
        private Button btnAtualizar;
        private Label lblValorRestanteExibirDetalhesDataGridView;
        private Label lblValorRealizadoExibirDetalhesDataGridView;
        private ContextMenuStrip cmsDgvExcluirDetalhesActions;
        private ToolStripMenuItem toolEditarRegistro;
        private ToolStripMenuItem toolDesabilitarRegistro;
    }
}