namespace App.WindowsForms.ViewModel
{
    public class DeleteCashReceivableViewModel
    {
        public Guid[]? Id { get; set; }
        public int[]? IdCashReceivableRegistrations { get; set; }

        /// <summary>
        /// Se TRUE Apenas os registros não recebidos
        /// </summary>
        public bool OnlyNotReceivable { get; set; }
        /// <summary>
        /// Caso marcada como TRUE é para desconsiderar em eventos futuros que podem ser criados.
        /// </summary>
        public bool DisableCashReceivableRegistration { get; set; }
    }
}