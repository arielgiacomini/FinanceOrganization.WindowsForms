namespace App.WindowsForms.ViewModel
{
    public class DeleteBillToPayViewModel
    {
        public Guid[]? Id { get; set; }
        public int[]? IdFixedInvoices { get; set; }

        /// <summary>
        /// Se TRUE Apenas os registros não pagos
        /// </summary>
        public bool JustUnpaid { get; set; }
        /// <summary>
        /// Caso marcada como TRUE é para desconsiderar em eventos futuros que podem ser criados.
        /// </summary>
        public bool DisableFixedInvoice { get; set; }
    }
}