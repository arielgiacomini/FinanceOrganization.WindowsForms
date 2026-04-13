using App.Forms.Config;
using Domain.Utils;
using System.Globalization;

namespace App.Forms.UI
{
    /// <summary>
    /// Helper class para gerenciar seleção de cultura/idioma na interface do usuário
    /// </summary>
    public class CultureSelectorHelper
    {
        /// <summary>
        /// Inicializa um ComboBox com as culturas disponíveis
        /// </summary>
        public static void InitializeCultureComboBox(ComboBox comboBox)
        {
            if (comboBox == null)
                return;

            comboBox.Items.Clear();
            
            var availableCultures = Program.GetAvailableCultures();
            
            foreach (var culture in availableCultures)
            {
                comboBox.Items.Add(new CultureItem { Code = culture.Key, DisplayName = culture.Value });
            }

            // Selecionar a cultura atual
            string currentCulture = StringDecimalUtils.CurrentCulture;
            var selectedItem = comboBox.Items.Cast<CultureItem>().FirstOrDefault(x => x.Code == currentCulture);
            
            if (selectedItem != null)
            {
                comboBox.SelectedItem = selectedItem;
            }
            else
            {
                comboBox.SelectedIndex = 0;
            }

            comboBox.DisplayMember = nameof(CultureItem.DisplayName);
        }

        /// <summary>
        /// Muda a cultura da aplicação com base na seleção do ComboBox
        /// </summary>
        public static void ChangeCulture(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is CultureItem selectedCulture)
            {
                Program.ChangeApplicationCulture(selectedCulture.Code);
            }
        }

        /// <summary>
        /// Obtém o código da cultura selecionada
        /// </summary>
        public static string? GetSelectedCultureCode(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is CultureItem selectedCulture)
            {
                return selectedCulture.Code;
            }

            return null;
        }
    }

    /// <summary>
    /// Classe para representar um item de cultura no ComboBox
    /// </summary>
    public class CultureItem
    {
        public string Code { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        public override string ToString()
        {
            return DisplayName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is CultureItem other)
            {
                return Code == other.Code;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
