using BenchmarkDotNet.Attributes;
using System.Windows.Forms;
using Microsoft.VSDiagnostics;

namespace App.WindowsForms.Benchmarks
{
    [CPUUsageDiagnoser]
    public class ConfigureColumnBenchmark
    {
        private DataGridView _dgvExcluirDetalhes = null!;
        [GlobalSetup]
        public void Setup()
        {
            _dgvExcluirDetalhes = new DataGridView();
            // Create 19 columns (same as in PreecherDataGridViewDetalhes)
            for (int i = 0; i < 19; i++)
            {
                _dgvExcluirDetalhes.Columns.Add(new DataGridViewTextBoxColumn { Name = $"Column{i}", HeaderText = $"Header{i}" });
            }
        }

        [Benchmark]
        public void ConfigureColumns_CurrentImplementation()
        {
            // Simulate the current ConfigureColumn behavior called 19 times
            ConfigureColumn(0, "Id", false);
            ConfigureColumn(1, "Id da tabela pai", false);
            ConfigureColumn(2, "Conta", false);
            ConfigureColumn(3, "Descrição");
            ConfigureColumn(4, "Categoria");
            ConfigureColumn(5, "R$ Restante", true, "C2", DataGridViewContentAlignment.MiddleRight);
            ConfigureColumn(6, "R$ Realizado", true, "C2", DataGridViewContentAlignment.MiddleRight);
            ConfigureColumn(7, "R$ Total", true, "C2", DataGridViewContentAlignment.MiddleRight);
            ConfigureColumn(8, "Qtd Compras", true);
            ConfigureColumn(9, "Data de Compra");
            ConfigureColumn(10, "Vencimento");
            ConfigureColumn(11, "Mês/Ano");
            ConfigureColumn(12, "Frequência");
            ConfigureColumn(13, "Tipo");
            ConfigureColumn(14, "Data de Pagamento");
            ConfigureColumn(15, "Pago?");
            ConfigureColumn(16, "Mensagem", true, null, DataGridViewContentAlignment.MiddleLeft);
            ConfigureColumn(17, "Data de Criação", false);
            ConfigureColumn(18, "Data de Alteração", false);
        }

        [Benchmark]
        public void ConfigureColumns_WithBeginUpdate()
        {
            // Optimized version with SuspendLayout/ResumeLayout
            _dgvExcluirDetalhes.SuspendLayout();
            try
            {
                ConfigureColumn(0, "Id", false);
                ConfigureColumn(1, "Id da tabela pai", false);
                ConfigureColumn(2, "Conta", false);
                ConfigureColumn(3, "Descrição");
                ConfigureColumn(4, "Categoria");
                ConfigureColumn(5, "R$ Restante", true, "C2", DataGridViewContentAlignment.MiddleRight);
                ConfigureColumn(6, "R$ Realizado", true, "C2", DataGridViewContentAlignment.MiddleRight);
                ConfigureColumn(7, "R$ Total", true, "C2", DataGridViewContentAlignment.MiddleRight);
                ConfigureColumn(8, "Qtd Compras", true);
                ConfigureColumn(9, "Data de Compra");
                ConfigureColumn(10, "Vencimento");
                ConfigureColumn(11, "Mês/Ano");
                ConfigureColumn(12, "Frequência");
                ConfigureColumn(13, "Tipo");
                ConfigureColumn(14, "Data de Pagamento");
                ConfigureColumn(15, "Pago?");
                ConfigureColumn(16, "Mensagem", true, null, DataGridViewContentAlignment.MiddleLeft);
                ConfigureColumn(17, "Data de Criação", false);
                ConfigureColumn(18, "Data de Alteração", false);
            }
            finally
            {
                _dgvExcluirDetalhes.ResumeLayout(false);
            }
        }

        [Benchmark]
        public void ConfigureColumns_Optimized()
        {
            // Optimized version with property checks to avoid unnecessary setters
            ConfigureColumnOptimized(0, "Id", false);
            ConfigureColumnOptimized(1, "Id da tabela pai", false);
            ConfigureColumnOptimized(2, "Conta", false);
            ConfigureColumnOptimized(3, "Descrição");
            ConfigureColumnOptimized(4, "Categoria");
            ConfigureColumnOptimized(5, "R$ Restante", true, "C2", DataGridViewContentAlignment.MiddleRight);
            ConfigureColumnOptimized(6, "R$ Realizado", true, "C2", DataGridViewContentAlignment.MiddleRight);
            ConfigureColumnOptimized(7, "R$ Total", true, "C2", DataGridViewContentAlignment.MiddleRight);
            ConfigureColumnOptimized(8, "Qtd Compras", true);
            ConfigureColumnOptimized(9, "Data de Compra");
            ConfigureColumnOptimized(10, "Vencimento");
            ConfigureColumnOptimized(11, "Mês/Ano");
            ConfigureColumnOptimized(12, "Frequência");
            ConfigureColumnOptimized(13, "Tipo");
            ConfigureColumnOptimized(14, "Data de Pagamento");
            ConfigureColumnOptimized(15, "Pago?");
            ConfigureColumnOptimized(16, "Mensagem", true, null, DataGridViewContentAlignment.MiddleLeft);
            ConfigureColumnOptimized(17, "Data de Criação", false);
            ConfigureColumnOptimized(18, "Data de Alteração", false);
        }

        private void ConfigureColumn(int columnIndex, string headerText, bool visible = true, string? format = null, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.NotSet)
        {
            if (columnIndex >= _dgvExcluirDetalhes.Columns.Count)
                return;
            var column = _dgvExcluirDetalhes.Columns[columnIndex];
            column.HeaderText = headerText;
            column.Visible = visible;
            if (!string.IsNullOrEmpty(format))
            {
                column.DefaultCellStyle.Format = format;
            }

            if (alignment != DataGridViewContentAlignment.NotSet)
            {
                column.DefaultCellStyle.Alignment = alignment;
            }
        }

        private void ConfigureColumnOptimized(int columnIndex, string headerText, bool visible = true, string? format = null, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.NotSet)
        {
            if (columnIndex >= _dgvExcluirDetalhes.Columns.Count)
                return;

            var column = _dgvExcluirDetalhes.Columns[columnIndex];

            // Only set HeaderText if different (avoids unnecessary property setter overhead)
            if (column.HeaderText != headerText)
            {
                column.HeaderText = headerText;
            }

            // Only set Visible if different
            if (column.Visible != visible)
            {
                column.Visible = visible;
            }

            // Only modify DefaultCellStyle if needed
            if (!string.IsNullOrEmpty(format) || alignment != DataGridViewContentAlignment.NotSet)
            {
                var style = column.DefaultCellStyle;

                if (!string.IsNullOrEmpty(format) && style.Format != format)
                {
                    style.Format = format;
                }

                if (alignment != DataGridViewContentAlignment.NotSet && style.Alignment != alignment)
                {
                    style.Alignment = alignment;
                }
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _dgvExcluirDetalhes?.Dispose();
        }
    }
}