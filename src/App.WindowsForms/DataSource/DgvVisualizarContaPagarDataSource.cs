using App.WindowsForms.Entities;

namespace App.Forms.DataSource
{
    public class DgvVisualizarContaPagarDataSource
    {
        public Guid Id { get; set; }
        public int IdBillToPayRegistration { get; set; }
        /// <summary>
        /// Conta vinculada, Ex: Itaú, Cartão de Crédito, VA, VR, etc...
        /// </summary>
        public string? Account { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        /// <summary>
        /// Valor Restante
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Valor Pago
        /// </summary>
        public decimal DetailsAmount { get; set; }
        /// <summary>
        /// Valor total somado, com o gasto pré configurado da conta fixa + os gastos realizados realmente
        /// </summary>
        ///
        public decimal TotalValue
        {
            get
            {
                return Value + DetailsAmount;
            }
            private set { }
        }
        /// <summary>
        /// Quantidade de SubCompras relacionadas a este gasto
        /// </summary>
        public int DetailsQuantity { get; set; } = 0;
        /// <summary>
        /// Data de Compra do determinado item
        /// </summary>
        public DateTime? PurchaseDate { get; set; }
        /// <summary>
        /// Data de Vencimento
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// Mês/Ano de Referência para Contas à pagar
        /// </summary>
        public string? YearMonth { get; set; }
        public string? Frequence { get; set; }
        /// <summary>
        /// Este campo faz parte do processo de identificação do item, deixando as opções de compra livre ou conta fixa.
        /// </summary>
        public string? RegistrationType { get; set; }
        /// <summary>
        /// Data de Pagamento
        /// </summary>
        public string? PayDay { get; set; }
        public bool HasPay { get; set; }
        public string? AdditionalMessage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public IList<Details>? Details { get; set; }
        public Account? AccountObject { get; set; }
    }

    public class Details
    {
        public Guid Id { get; set; }
        public int IdFixedInvoice { get; set; }
        /// <summary>
        /// Conta vinculada, Ex: Itaú, Cartão de Crédito, VA, VR, etc...
        /// </summary>
        public string? Account { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal Value { get; set; }
        /// <summary>
        /// Data de Compra do determinado item
        /// </summary>
        public DateTime? PurchaseDate { get; set; }
        /// <summary>
        /// Data de Vencimento
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// Mês/Ano de Referência para Contas à pagar
        /// </summary>
        public string? YearMonth { get; set; }
        public string? Frequence { get; set; }
        /// <summary>
        /// Este campo faz parte do processo de identificação do item, deixando as opções de compra livre ou conta fixa.
        /// </summary>
        public string? RegistrationType { get; set; }
        /// <summary>
        /// Data de Pagamento
        /// </summary>
        public string? PayDay { get; set; }
        public bool HasPay { get; set; }
        public string? AdditionalMessage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastChangeDate { get; set; }
    }
}