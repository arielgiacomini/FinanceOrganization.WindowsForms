using App.Forms.Config;
using App.Forms.Forms;
using Domain.Utils;
using Serilog;
using System.Globalization;

namespace App.Forms
{
    public static class Program
    {
        /// <summary>
        /// Available cultures for the application
        /// </summary>
        private static readonly Dictionary<string, (string Name, string DisplayName)> AvailableCultures = new()
        {
            { "pt-BR", ("pt-BR", "🇧🇷 Português (Brasil) - Real (R$)") },
            { "es-ES", ("es-ES", "🇪🇸 Español (España) - Euro (€)") },
            { "en-US", ("en-US", "🇺🇸 English (USA) - Dollar ($)") },
            { "de-DE", ("de-DE", "🇩🇪 Deutsch (Deutschland) - Euro (€)") },
            { "fr-FR", ("fr-FR", "🇫🇷 Français (France) - Euro (€)") }
        };

        public static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                // Initialize culture settings
                InitializeCultureSettings();

                ApplicationConfiguration
                    .Initialize();

                Application.Run(new Initial(GetInfoHeader()));
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Initializes the culture settings for the application
        /// </summary>
        private static void InitializeCultureSettings()
        {
            // Try to load from settings, default to pt-BR if not found
            string? savedCulture = LoadCultureFromSettings();
            string selectedCulture = savedCulture ?? "pt-BR";

            // For production environments, you might want to auto-detect based on system locale
            // Uncomment below if desired:
            // string systemCulture = CultureInfo.CurrentCulture.Name;
            // if (AvailableCultures.ContainsKey(systemCulture))
            // {
            //     selectedCulture = systemCulture;
            // }

            // Apply the selected culture
            SetApplicationCulture(selectedCulture);
        }

        /// <summary>
        /// Sets the culture for the entire application
        /// </summary>
        private static void SetApplicationCulture(string cultureName)
        {
            if (!AvailableCultures.ContainsKey(cultureName))
            {
                Log.Warning("Culture '{Culture}' not found. Using default 'pt-BR'", cultureName);
                cultureName = "pt-BR";
            }

            try
            {
                // Set the current culture for the thread
                var cultureInfo = new CultureInfo(cultureName);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                // Set global culture in utility classes
                StringDecimalUtils.SetCulture(cultureName);
                DateUtils.SetCulture(cultureName);
                LocalizationResources.SetCulture(cultureName);

                Log.Information("Application culture set to: {Culture} ({DisplayName})", 
                    cultureName, AvailableCultures[cultureName].DisplayName);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error setting culture to '{Culture}'", cultureName);
                throw;
            }
        }

        /// <summary>
        /// Loads the saved culture preference from settings
        /// </summary>
        private static string? LoadCultureFromSettings()
        {
            try
            {
                // This assumes you have a config key in App.config or appsettings.json
                // Adjust according to your configuration provider
                var cultureSetting = System.Configuration.ConfigurationManager.AppSettings["application.culture"];
                return string.IsNullOrWhiteSpace(cultureSetting) ? null : cultureSetting;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the list of available cultures for UI selection
        /// </summary>
        public static IReadOnlyDictionary<string, string> GetAvailableCultures()
        {
            return AvailableCultures.ToDictionary(x => x.Key, x => x.Value.DisplayName);
        }

        /// <summary>
        /// Changes the application culture at runtime
        /// </summary>
        public static void ChangeApplicationCulture(string cultureName)
        {
            SetApplicationCulture(cultureName);
            SaveCultureToSettings(cultureName);
        }

        /// <summary>
        /// Saves the culture preference to settings for future sessions
        /// </summary>
        private static void SaveCultureToSettings(string cultureName)
        {
            try
            {
                // This is a simple implementation. In production, you might want to use
                // a proper settings file or database to persist the preference
                var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                    System.Configuration.ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["application.culture"] == null)
                {
                    config.AppSettings.Settings.Add("application.culture", cultureName);
                }
                else
                {
                    config.AppSettings.Settings["application.culture"].Value = cultureName;
                }

                config.Save(System.Configuration.ConfigurationSaveMode.Modified);
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Could not save culture preference to settings");
            }
        }

        private static InfoHeader? GetInfoHeader()
        {
            var enviroment = UrlConfig.GetEnviromentInitialize();
            var urlAPI = UrlConfig.GetFinanceOrganizationApiUrl(enviroment);

            if (string.IsNullOrWhiteSpace(urlAPI))
            {
                return null;
            }

            bool productionEnviroment = false;

            if (urlAPI.StartsWith("http://api.financeiro.arielgiacomini.com.br"))
            {
                productionEnviroment = true;
            }

            var infoHeader = new InfoHeader
            {
                IsProductionEnvironment = productionEnviroment,
                Url = urlAPI,
                Version = Info.GetVersionString(),
                Environment = enviroment
            };

            return infoHeader;
        }
    }
}