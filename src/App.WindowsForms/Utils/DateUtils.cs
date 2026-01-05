namespace Domain.Utils
{
    public static class DateUtils
    {
        public static string GetYearMonthPortugueseByDateTime(DateTime dateTime)
        {
            var year = dateTime.Year;
            var month = MonthNamePortuguese(dateTime.Month);

            var mesAno = string.Concat(month, "/", year);

            return mesAno;
        }

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