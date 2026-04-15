// EXEMPLO PRÁTICO: Como Usar o Sistema Multilíngue

using App.Forms.Config;
using Domain.Utils;

namespace App.Forms.Examples
{
    /// <summary>
    /// Exemplos práticos de como usar o novo sistema multilíngue
    /// </summary>
    public class LocalizationExamples
    {
        // ============================================================
        // EXEMPLO 1: Inicializar cultura no Application Startup
        // ============================================================
        public static void Example1_InitializeApplicationCulture()
        {
            // Isso já é feito automaticamente em Program.cs
            // Mas você pode trocar em tempo de execução:
            
            Program.ChangeApplicationCulture("es-ES");
            Console.WriteLine("✅ Cultura alterada para: Español (España)");
        }

        // ============================================================
        // EXEMPLO 2: Formatar moeda em diferentes culturas
        // ============================================================
        public static void Example2_FormatCurrency()
        {
            decimal valor = 1500.50m;

            // Com pt-BR (Real)
            StringDecimalUtils.SetCulture("pt-BR");
            Console.WriteLine($"PT-BR: {valor.ToString("C")}"); // R$ 1.500,50

            // Com es-ES (Euro)
            StringDecimalUtils.SetCulture("es-ES");
            Console.WriteLine($"ES-ES: {valor.ToString("C")}"); // 1.500,50 €

            // Com en-US (Dólar)
            StringDecimalUtils.SetCulture("en-US");
            Console.WriteLine($"EN-US: {valor.ToString("C")}"); // $1,500.50
        }

        // ============================================================
        // EXEMPLO 3: Formatar datas em diferentes culturas
        // ============================================================
        public static void Example3_FormatDate()
        {
            DateTime data = new DateTime(2025, 2, 13);

            // Com pt-BR
            DateUtils.SetCulture("pt-BR");
            Console.WriteLine($"PT-BR: {DateUtils.GetYearMonthPortugueseByDateTime(data)}"); 
            // Fevereiro/2025

            // Com es-ES
            DateUtils.SetCulture("es-ES");
            Console.WriteLine($"ES-ES: {DateUtils.GetYearMonthPortugueseByDateTime(data)}"); 
            // Febrero/2025

            // Com en-US
            DateUtils.SetCulture("en-US");
            Console.WriteLine($"EN-US: {DateUtils.GetYearMonthPortugueseByDateTime(data)}"); 
            // February/2025
        }

        // ============================================================
        // EXEMPLO 4: Usar LocalizationResources para mensagens
        // ============================================================
        public static void Example4_UseLocalizationResources()
        {
            LocalizationResources.SetCulture("pt-BR");
            Console.WriteLine($"PT-BR: {LocalizationResources.AlertMessages.NoItemsToFinalize}");
            // "Nenhum item para finalizar cadastro."

            LocalizationResources.SetCulture("es-ES");
            Console.WriteLine($"ES-ES: {LocalizationResources.AlertMessages.NoItemsToFinalize}");
            // "Ningún artículo para finalizar el registro."
        }

        // ============================================================
        // EXEMPLO 5: Aplicar em formulário Windows Forms
        // ============================================================
        public static void Example5_ApplyToWinFormsControls(System.Windows.Forms.Form form)
        {
            // Supondo que você tem controles em seu formulário:
            /*
            
            // Mudar para Espanhol
            Program.ChangeApplicationCulture("es-ES");
            
            // Atualizar labels
            form.Controls["lblSalvo"].Text = LocalizationResources.ButtonLabels.Save;
            form.Controls["lblCancelar"].Text = LocalizationResources.ButtonLabels.Cancel;
            form.Controls["lblExcluir"].Text = LocalizationResources.ButtonLabels.Delete;
            
            // Atualizar cabeçalhos de coluna (DataGridView)
            form.Controls["dgvPrincipal"].Columns["colValor"].HeaderText = 
                LocalizationResources.TableHeaders.Value;
            form.Controls["dgvPrincipal"].Columns["colData"].HeaderText = 
                LocalizationResources.TableHeaders.Date;
            
            // Formatar valores monetários (será automático via CultureInfo)
            // Formatar datas (será automático via CultureInfo)
            */
        }

        // ============================================================
        // EXEMPLO 6: Converter string em decimal com cultura específica
        // ============================================================
        public static void Example6_ParseCurrencyString()
        {
            // String vindo do usuário em Espanhol
            string inputEspanha = "1.500,50 €";
            string inputBrasil = "R$ 1.500,50";

            // Converter com cultura correta
            decimal valorEspanha = StringDecimalUtils.TranslateStringEmDecimal(inputEspanha, false, "es-ES");
            decimal valorBrasil = StringDecimalUtils.TranslateStringEmDecimal(inputBrasil, false, "pt-BR");

            Console.WriteLine($"Espanha: {valorEspanha} → {valorEspanha.ToString("C", new System.Globalization.CultureInfo("es-ES"))}");
            Console.WriteLine($"Brasil: {valorBrasil} → {valorBrasil.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}");
        }

        // ============================================================
        // EXEMPLO 7: Mostrar todas as culturas disponíveis
        // ============================================================
        public static void Example7_DisplayAvailableCultures()
        {
            var culturas = Program.GetAvailableCultures();
            
            Console.WriteLine("Culturas disponíveis:");
            foreach (var cultura in culturas)
            {
                Console.WriteLine($"  • {cultura.Value}");
            }
        }

        // ============================================================
        // EXEMPLO 8: Criar um menu para o usuário escolher idioma
        // ============================================================
        public static void Example8_CultureSelectionMenu()
        {
            /*
            var culturas = Program.GetAvailableCultures();
            
            // Criar ComboBox no formulário
            ComboBox cboCultura = new ComboBox();
            cboCultura.DataSource = culturas.ToList();
            cboCultura.DisplayMember = "Value"; // Mostra o nome amigável
            cboCultura.ValueMember = "Key";     // Valor real (pt-BR, es-ES, etc)
            
            // Evento de mudança
            cboCultura.SelectedValueChanged += (s, e) => 
            {
                Program.ChangeApplicationCulture(cboCultura.SelectedValue.ToString());
                // Recarregar formulário ou avisar ao usuário
            };
            */
        }

        // ============================================================
        // EXEMPLO 9: Obter nome do mês em qualquer idioma
        // ============================================================
        public static void Example9_GetMonthNameAnyLanguage()
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                string mesPortugues = DateUtils.GetMonthName(mes, "pt-BR");
                string mesEspanhol = DateUtils.GetMonthName(mes, "es-ES");
                string mesIngles = DateUtils.GetMonthName(mes, "en-US");
                
                Console.WriteLine($"{mesPortugues.PadRight(12)} | {mesEspanhol.PadRight(12)} | {mesIngles}");
            }
        }

        // ============================================================
        // EXEMPLO 10: Modo de integração completa para um formulário
        // ============================================================
        public static void Example10_CompleteFormIntegration()
        {
            /*
            // Na forma Load:
            public partial class MyForm : Form
            {
                private void MyForm_Load(object sender, EventArgs e)
                {
                    // Sincronizar com a cultura global
                    UpdateUIWithCurrentCulture();
                    
                    // Assinar evento de mudança de cultura (se implementar)
                    // CultureManager.CultureChanged += UpdateUIWithCurrentCulture;
                }

                private void UpdateUIWithCurrentCulture()
                {
                    // Atualizar textos
                    this.Text = "Gerenciador Financeiro"; // Manter nome do form
                    
                    // Botões
                    btnSalvar.Text = LocalizationResources.ButtonLabels.Save;
                    btnCancelar.Text = LocalizationResources.ButtonLabels.Cancel;
                    btnExcluir.Text = LocalizationResources.ButtonLabels.Delete;
                    
                    // Labels
                    lblTitulo.Text = "Contas a Pagar"; // Traduzir também
                    
                    // Cabeçalhos de tabela
                    dgvDados.Columns["colValor"].HeaderText = 
                        LocalizationResources.TableHeaders.Value;
                    dgvDados.Columns["colData"].HeaderText = 
                        LocalizationResources.TableHeaders.Date;
                    
                    // Mensagens dinâmicas serão atualizadas automaticamente
                    // quando usarem LocalizationResources
                }
            }
            */
        }
    }
}
