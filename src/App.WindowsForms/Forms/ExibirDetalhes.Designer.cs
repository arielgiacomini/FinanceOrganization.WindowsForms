﻿using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExibirDetalhes));
            dgvExcluirDetalhes = new DataGridView();
            lblExcluirDetalhesItensSelecionadosDataGridView = new Label();
            btnExcluir = new Button();
            btnShowDetails = new Button();
            lblValorMedioOnlyPagos = new Label();
            lblTotaisRegistrosEValores = new Label();
            lblRunTimeLoad = new Label();
            btnAtualizar = new Button();
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
            dgvExcluirDetalhes.BackgroundColor = SystemColors.AppWorkspace;
            dgvExcluirDetalhes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvExcluirDetalhes.DefaultCellStyle = dataGridViewCellStyle1;
            dgvExcluirDetalhes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvExcluirDetalhes.Location = new Point(12, 49);
            dgvExcluirDetalhes.Name = "dgvExcluirDetalhes";
            dgvExcluirDetalhes.ReadOnly = true;
            dgvExcluirDetalhes.RowTemplate.Height = 25;
            dgvExcluirDetalhes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExcluirDetalhes.Size = new Size(1257, 436);
            dgvExcluirDetalhes.TabIndex = 0;
            dgvExcluirDetalhes.CellMouseDown += EditarRegistroSelecionado_dgvExcluirDetalhes_CellMouseDown;
            dgvExcluirDetalhes.RowsAdded += DgvExcluirDetalhes_RowsAdded;
            dgvExcluirDetalhes.SelectionChanged += DgvExcluirDetalhes_SelectionChanged;
            // 
            // lblExcluirDetalhesItensSelecionadosDataGridView
            // 
            lblExcluirDetalhesItensSelecionadosDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblExcluirDetalhesItensSelecionadosDataGridView.AutoSize = true;
            lblExcluirDetalhesItensSelecionadosDataGridView.Location = new Point(1072, 31);
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
            lblValorMedioOnlyPagos.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point);
            lblValorMedioOnlyPagos.ForeColor = SystemColors.Highlight;
            lblValorMedioOnlyPagos.Location = new Point(335, 9);
            lblValorMedioOnlyPagos.Name = "lblValorMedioOnlyPagos";
            lblValorMedioOnlyPagos.RightToLeft = RightToLeft.Yes;
            lblValorMedioOnlyPagos.Size = new Size(212, 32);
            lblValorMedioOnlyPagos.TabIndex = 19;
            lblValorMedioOnlyPagos.Text = "Valor Médio: R$ 1.400,00";
            lblValorMedioOnlyPagos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotaisRegistrosEValores
            // 
            lblTotaisRegistrosEValores.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotaisRegistrosEValores.AutoSize = true;
            lblTotaisRegistrosEValores.Location = new Point(1009, 488);
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
            lblRunTimeLoad.Location = new Point(12, 488);
            lblRunTimeLoad.Name = "lblRunTimeLoad";
            lblRunTimeLoad.RightToLeft = RightToLeft.Yes;
            lblRunTimeLoad.Size = new Size(64, 15);
            lblRunTimeLoad.TabIndex = 21;
            lblRunTimeLoad.Text = "00:00:01.00";
            lblRunTimeLoad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.LawnGreen;
            btnAtualizar.ForeColor = SystemColors.ControlDarkDark;
            btnAtualizar.Location = new Point(1183, 5);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(86, 23);
            btnAtualizar.TabIndex = 22;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += BtnAtualizar_Click;
            // 
            // FrmExibirDetalhes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 514);
            Controls.Add(btnAtualizar);
            Controls.Add(lblRunTimeLoad);
            Controls.Add(lblTotaisRegistrosEValores);
            Controls.Add(lblValorMedioOnlyPagos);
            Controls.Add(btnShowDetails);
            Controls.Add(btnExcluir);
            Controls.Add(lblExcluirDetalhesItensSelecionadosDataGridView);
            Controls.Add(dgvExcluirDetalhes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmExibirDetalhes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista todos os itens relacionados a conta selecionada";
            Load += FrmExcluirDetalhes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExcluirDetalhes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvExcluirDetalhes;
        private Label lblExcluirDetalhesItensSelecionadosDataGridView;
        private Button btnExcluir;
        private Button btnShowDetails;
        private Label lblValorMedioOnlyPagos;
        private Label lblTotaisRegistrosEValores;
        private Label lblRunTimeLoad;
        private Button btnAtualizar;
    }
}