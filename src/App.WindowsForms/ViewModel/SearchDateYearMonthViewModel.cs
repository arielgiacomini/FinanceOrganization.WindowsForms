namespace App.WindowsForms.ViewModel
{
    public class SearchDateYearMonthViewModel
    {
        /// <summary>
        /// Ano inicial para filtro. Ex.: 2020
        /// </summary>
        public int? StartYear { get; set; }
        /// <summary>
        /// Ano final para filtro. Ex.: 2023
        /// </summary>
        public int? EndYear { get; set; }
    }
}