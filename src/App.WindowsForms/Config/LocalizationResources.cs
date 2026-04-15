using System.Globalization;

namespace App.Forms.Config
{
    /// <summary>
    /// Centralized localization resource manager for all application messages.
    /// Supports multiple languages: pt-BR, es-ES, en-US, de-DE, fr-FR
    /// </summary>
    public static class LocalizationResources
    {
        public static string CurrentCulture { get; set; } = "pt-BR";

        /// <summary>
        /// Sets the global culture for localization
        /// </summary>
        public static void SetCulture(string cultureName)
        {
            try
            {
                var testCulture = new CultureInfo(cultureName);
                CurrentCulture = cultureName;
            }
            catch (CultureNotFoundException)
            {
                throw new ArgumentException($"Culture '{cultureName}' is not supported.", nameof(cultureName));
            }
        }
    }
}
