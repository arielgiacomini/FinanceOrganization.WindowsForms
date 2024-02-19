namespace App.Forms.ViewModel
{
    public class SearchBillToPayViewModel
    {
        public Guid[]? Id { get; set; }
        public int[]? IdFixedInvoices { get; set; }

        /// <summary>
        /// Mês/Ano de referência, gastos do determinado período.
        /// </summary>
        public string? YearMonth { get; set; }
    }
}