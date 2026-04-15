using System.Globalization;

namespace Domain.Utils
{
    public static class DateUtils
    {
        /// <summary>
        /// Gets the current culture for date formatting.
        /// Defaults to pt-BR if not explicitly set.
        /// </summary>
        public static string CurrentCulture { get; set; } = "pt-BR";

        public static string GetYearMonthPortugueseByDateTime(DateTime dateTime, string? cultureName = null)
        {
            var year = dateTime.Year;
            var month = GetMonthName(dateTime.Month, cultureName);

            var mesAno = string.Concat(char.ToUpper(month[0]) + month.Substring(1), "/", year);

            return mesAno;
        }

        /// <summary>
        /// Gets the month name based on the specified culture.
        /// </summary>
        /// <param name="monthNumber">Month number (1-12)</param>
        /// <param name="cultureName">Culture name (e.g., "pt-BR", "es-ES"). If null, uses CurrentCulture</param>
        /// <returns>Localized month name</returns>
        public static string GetMonthName(int monthNumber, string? cultureName = null)
        {
            cultureName ??= CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);

            if (monthNumber < 1 || monthNumber > 12)
            {
                return GetNotIdentifiedMessage(cultureName, monthNumber);
            }

            return cultureInfo.DateTimeFormat.GetMonthName(monthNumber);
        }

        /// <summary>
        /// Gets the abbreviated month name based on the specified culture.
        /// </summary>
        /// <param name="monthNumber">Month number (1-12)</param>
        /// <param name="cultureName">Culture name (e.g., "pt-BR", "es-ES"). If null, uses CurrentCulture</param>
        /// <returns>Localized abbreviated month name</returns>
        public static string GetAbbreviatedMonthName(int monthNumber, string? cultureName = null)
        {
            cultureName ??= CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);

            if (monthNumber < 1 || monthNumber > 12)
            {
                return GetNotIdentifiedMessage(cultureName, monthNumber);
            }

            return cultureInfo.DateTimeFormat.GetAbbreviatedMonthName(monthNumber);
        }

        /// <summary>
        /// Formats a date string with day name based on the specified culture.
        /// </summary>
        /// <param name="dateTime">The date to format</param>
        /// <param name="cultureName">Culture name (e.g., "pt-BR", "es-ES"). If null, uses CurrentCulture</param>
        /// <returns>Formatted date string (e.g., "segunda-feira, 13 de fevereiro de 2025")</returns>
        public static string FormatDateLong(DateTime dateTime, string? cultureName = null)
        {
            cultureName ??= CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);

            return dateTime.ToString("dddd, dd \\de MMMM \\de yyyy", cultureInfo);
        }

        /// <summary>
        /// Formats a date string in short format based on the specified culture.
        /// </summary>
        /// <param name="dateTime">The date to format</param>
        /// <param name="cultureName">Culture name (e.g., "pt-BR", "es-ES"). If null, uses CurrentCulture</param>
        /// <returns>Formatted date string (e.g., "13/02/2025")</returns>
        public static string FormatDateShort(DateTime dateTime, string? cultureName = null)
        {
            cultureName ??= CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);

            return dateTime.ToString("d", cultureInfo);
        }

        /// <summary>
        /// Sets the global culture for date and month formatting.
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

        private static string GetNotIdentifiedMessage(string cultureName, int monthNumber)
        {
            return cultureName switch
            {
                "es-ES" or "es" => $"No identificado: [{monthNumber}]",
                "en-US" or "en" => $"Not identified: [{monthNumber}]",
                "de-DE" or "de" => $"Nicht identifiziert: [{monthNumber}]",
                "fr-FR" or "fr" => $"Non identifié: [{monthNumber}]",
                _ => $"Não identificado: [{monthNumber}]" // Default to Portuguese
            };
        }

        /// <summary>
        /// Legacy method for backward compatibility. Gets month name in Portuguese.
        /// </summary>
        private static string MonthNamePortuguese(int month)
        {
            var monthBrazilian = string.Empty;

            switch (month)
            {
                case 1:
                    monthBrazilian = "Janeiro";
                    break;
                case 2:
                    monthBrazilian = "Fevereiro";
                    break;
                case 3:
                    monthBrazilian = "Março";
                    break;
                case 4:
                    monthBrazilian = "Abril";
                    break;
                case 5:
                    monthBrazilian = "Maio";
                    break;
                case 6:
                    monthBrazilian = "Junho";
                    break;
                case 7:
                    monthBrazilian = "Julho";
                    break;
                case 8:
                    monthBrazilian = "Agosto";
                    break;
                case 9:
                    monthBrazilian = "Setembro";
                    break;
                case 10:
                    monthBrazilian = "Outubro";
                    break;
                case 11:
                    monthBrazilian = "Novembro";
                    break;
                case 12:
                    monthBrazilian = "Dezembro";
                    break;
                default:
                    monthBrazilian = $"Não identificado: [{month}]";
                    break;
            }

            return monthBrazilian;
        }

        public static DateTime? GetDateTimeOfString(string? dateTime)
        {
            DateTime? dateTimeResult;

            if (dateTime is null)
            {
                return null;
            }

            try
            {
                dateTimeResult = Convert.ToDateTime(dateTime);
            }
            catch
            {
                dateTimeResult = null;
            }

            return dateTimeResult;
        }
    }
}