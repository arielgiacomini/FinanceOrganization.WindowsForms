using App.WindowsForms.Entities;

namespace Domain.Entities
{
    public static class AccountFixed
    {
        public const string CARTAO_CREDITO = "Cartão de Crédito";
        public const string CARTAO_DEBITO = "Cartão de Débito";
        public const string CARTAO_VALE_ALIMENTACAO = "Cartão VA";
        public const string CARTAO_VALE_REFEICAO = "Cartão VR";
        public const string ITAU = "Itaú";

        public static IList<Account> GetAccountsFixed()
        {
            var accounts = new List<Account>
            {
                new() { Id = 1, Name = AccountFixed.CARTAO_CREDITO },
                new() { Id = 2, Name = AccountFixed.CARTAO_DEBITO },
                new() { Id = 3, Name = AccountFixed.CARTAO_VALE_ALIMENTACAO },
                new() { Id = 4, Name = AccountFixed.CARTAO_VALE_REFEICAO },
                new() { Id = 5, Name = AccountFixed.ITAU }
            };

            return accounts;
        }
    }
}