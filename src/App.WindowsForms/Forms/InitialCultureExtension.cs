using App.Forms.Config;
using App.Forms.UI;

namespace App.Forms.Forms
{
    /// <summary>
    /// Extensão para Initial.cs com suporte a seleção de cultura/idioma
    /// 
    /// INSTRUÇÕES DE INTEGRAÇÃO:
    /// 
    /// 1. No Designer do Initial.cs, adicione um ComboBox na toolbar ou panel superior:
    ///    - Name: cboCultura
    ///    - DropDownStyle: DropDownList
    ///    - Location: Parte superior direita do formulário
    /// 
    /// 2. No evento Load do formulário, adicione:
    ///    InitializeCultureSelector();
    /// 
    /// 3. No evento SelectedValueChanged do ComboBox, adicione:
    ///    CboCultura_SelectedValueChanged(sender, e);
    /// 
    /// EXEMPLO DE IMPLEMENTAÇÃO:
    /// 
    ///     // No formulário designer, adicione na toolbar/panel:
    ///     private ComboBox cboCultura;
    ///     
    ///     // No Initial_Load adicione:
    ///     InitializeCultureSelector();
    ///     
    ///     // Crie este evento:
    ///     private void CboCultura_SelectedValueChanged(object sender, EventArgs e)
    ///     {
    ///         CultureSelectorHelper.ChangeCulture(cboCultura);
    ///         RefreshUITexts();
    ///     }
    /// </summary>
    public partial class InitialCultureExtension
    {
        /// <summary>
        /// Inicializa o seletor de cultura no formulário
        /// Use isto no evento Initial_Load
        /// </summary>
        public static void InitializeCultureSelector(ComboBox cboCultura)
        {
            try
            {
                CultureSelectorHelper.InitializeCultureComboBox(cboCultura);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao inicializar seletor de cultura: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza os textos da UI quando a cultura mudar
        /// Use isto quando o ComboBox de cultura for alterado
        /// </summary>
        public static void RefreshUITextsOnCultureChange()
        {
            // Quando implementar, aqui você atualizará:
            // - Labels com mensagens de alerta
            // - Cabeçalhos de tabela
            // - Tooltips
            // - Mensagens de status
            // - Etc.
            
            MessageBox.Show(
                "Idioma/Moeda alterados com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

    /// <summary>
    /// GUIA RÁPIDO DE INTEGRAÇÃO NO INITIAL.CS:
    /// 
    /// PASSO 1: Adicione a importação no topo:
    ///     using App.Forms.UI;
    /// 
    /// PASSO 2: Adicione a propriedade no formulário:
    ///     private ComboBox cboCultura;
    /// 
    /// PASSO 3: No Initial_Load, após InitializeComponent(), adicione:
    ///     // Criar e adicionar ComboBox de cultura
    ///     cboCultura = new ComboBox
    ///     {
    ///         Name = "cboCultura",
    ///         DropDownStyle = ComboBoxStyle.DropDownList,
    ///         Width = 250,
    ///         Location = new Point(this.Width - 270, 12),
    ///         Anchor = AnchorStyles.Top | AnchorStyles.Right,
    ///         DropDownHeight = 150
    ///     };
    ///     cboCultura.SelectedValueChanged += CboCultura_SelectedValueChanged;
    ///     
    ///     // Inicializar com as culturas disponíveis
    ///     CultureSelectorHelper.InitializeCultureComboBox(cboCultura);
    ///     
    ///     // Adicionar ao formulário (em um panel superior ou diretamente no form)
    ///     this.Controls.Add(cboCultura);
    /// 
    /// PASSO 4: Crie o evento de mudança:
    ///     private void CboCultura_SelectedValueChanged(object sender, EventArgs e)
    ///     {
    ///         CultureSelectorHelper.ChangeCulture(cboCultura);
    ///         // Opcionalmente, recarregue a UI se necessário
    ///         // this.Refresh();
    ///     }
    /// 
    /// PRONTO! Agora o usuário pode selecionar o idioma/moeda desejado.
    /// </summary>
    public class InitialIntegrationGuide
    {
        // Este é um exemplo de como integraria tudo junto
        public static void ExampleImplementation()
        {
            /*
            
            // Em Initial.cs, adicione isto:
            
            using App.Forms.UI;  // <- Add this import
            
            public partial class Initial : Form
            {
                private ComboBox cboCultura;  // <- Add this field
                
                private async void Initial_Load(object sender, EventArgs e)
                {
                    // ... código existente ...
                    
                    // Criar ComboBox de cultura
                    cboCultura = new ComboBox
                    {
                        Name = "cboCultura",
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Width = 280,
                        Location = new Point(this.Width - 300, 8),
                        Anchor = AnchorStyles.Top | AnchorStyles.Right,
                        Font = new Font("Arial", 9),
                        DropDownHeight = 150
                    };
                    cboCultura.SelectedValueChanged += CboCultura_SelectedValueChanged;
                    
                    // Inicializar culturas
                    CultureSelectorHelper.InitializeCultureComboBox(cboCultura);
                    
                    // Adicionar ao formulário (encontre um panel ou use this.Controls)
                    // Exemplo: pnlToolbar.Controls.Add(cboCultura);
                    // Ou: this.Controls.Add(cboCultura);
                    
                    // ... resto do código ...
                }
                
                private void CboCultura_SelectedValueChanged(object sender, EventArgs e)
                {
                    CultureSelectorHelper.ChangeCulture(cboCultura);
                    
                    // Opcionalmente, você pode recarregar dados se necessário
                    // lblInfoHeader.Text = AdjusteInfoHeader(DateTime.Now);
                    // this.Refresh();
                }
            }
            
            */
        }
    }
}
