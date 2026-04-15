using System.Globalization;

namespace Domain.Utils
{
    public class StringDecimalUtils
    {
        /// <summary>
        /// Gets the current culture for currency formatting.
        /// Defaults to pt-BR if not explicitly set.
        /// </summary>
        public static string CurrentCulture { get; set; } = "pt-BR";

        public static bool VerificaSeEhNumero(string valor, string? cultureName = null)
        {
            cultureName ??= CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);

            if (decimal.TryParse(valor, NumberStyles.Currency, cultureInfo, out var _))
            {
                return true;
            }

            if (decimal.TryParse(valor, NumberStyles.Number, cultureInfo, out var _))
            {
                return true;
            }

            return false;
        }

        public static decimal TranslateStringEmDecimal(string valor, bool ehPercentual = false, string? cultureName = null)
        {
            cultureName ??= CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);
            decimal result = default;
            bool flag = VerificaSeEhNumero(valor, cultureName);

            // Try to parse as currency first
            if (decimal.TryParse(valor, NumberStyles.Currency, cultureInfo, out var currencyResult))
            {
                return currencyResult;
            }

            // Check for percentage
            if (valor.Contains('%'))
            {
                result = Convert.ToDecimal(valor.Replace("%", "").Trim(), cultureInfo) / 100m;
                return result;
            }

            // Check for comma-separated number (common in European format)
            if (valor.Contains(',') && !valor.Contains('%'))
            {
                if (decimal.TryParse(valor, NumberStyles.Number, cultureInfo, out var numberResult))
                {
                    return numberResult;
                }
            }

            // Try standard decimal parsing
            if (flag && !ehPercentual)
            {
                if (decimal.TryParse(valor, NumberStyles.Number, cultureInfo, out var standardResult))
                {
                    return standardResult;
                }
            }

            // Handle percentage conversion
            if (flag && ehPercentual)
            {
                result = Convert.ToDecimal(valor, cultureInfo);
                result /= 100m;
                return result;
            }

            return result;
        }

        public static string TranslateValorEmStringDinheiro(string valor, string? cultureName = null)
        {
            cultureName ??= CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);

            if (string.IsNullOrWhiteSpace(valor) || valor == "")
            {
                return (0m).ToString("C", cultureInfo);
            }

            // Check if value is zero in any format
            if (decimal.TryParse(valor, NumberStyles.Currency | NumberStyles.Number, cultureInfo, out var parsedValue))
            {
                if (parsedValue == 0)
                {
                    return (0m).ToString("C", cultureInfo);
                }

                return parsedValue.ToString("C", cultureInfo);
            }

            // If it's already a valid currency string, return as is
            if (VerificaSeEhNumero(valor, cultureName))
            {
                var numericValue = TranslateStringEmDecimal(valor, false, cultureName);
                return numericValue.ToString("C", cultureInfo);
            }

            return valor;
        }

        /// <summary>
        /// Sets the global culture for currency and number formatting.
        /// </summary>
        /// <param name="cultureName">Culture name (e.g., "pt-BR", "es-ES", "en-US")</param>
        public static void SetCulture(string cultureName)
        {
            try
            {
                // Validate culture exists
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