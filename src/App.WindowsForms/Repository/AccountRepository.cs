using App.WindowsForms.Entities;

namespace App.WindowsForms.Repository
{
    public class AccountRepository
    {
        public Dictionary<int, Account> _accounts = new();


        /// <summary>
        /// Variável Privada da Instância
        /// </summary>
        private static AccountRepository _instance = null;
        /// <summary>
        /// Get a instância
        /// </summary>
        public static AccountRepository Instance
        {
            get { return _instance ??= new AccountRepository(); }
        }

        public void AddOnMemory(Account account)
        {
            if (_accounts.Count == 0)
            {
                _accounts.TryAdd(0, new Account() { Id = 0, Name = "Nenhum" });

                _accounts.TryAdd(account.Id, account);
            }
            else
            {
                _accounts.TryAdd(account.Id, account);
            }
        }

        public bool IsCreditCard(string account)
        {
            foreach (var itemAccount in _accounts)
            {
                if (itemAccount.Value.Name == account && itemAccount.Value.IsCreditCard)
                {
                    return true;
                }
            }

            return false;
        }

        public Dictionary<int, Account> GetAccounts()
        {
            return _accounts;
        }

        public IList<Account> GetAccountsOnlyCreditCard()
        {
            IList<Account> accounts = new List<Account>();

            foreach (var itemAccount in _accounts.Values)
            {
                if (itemAccount != null)
                {
                    if (itemAccount.IsCreditCard)
                    {
                        accounts.Add(itemAccount);
                    }
                }
            }

            return accounts;
        }

        public Account? GetAccountByName(string account)
        {
            foreach (var itemAccount in _accounts)
            {
                if (itemAccount.Value.Name == account)
                {
                    return itemAccount.Value;
                }
            }

            return null;
        }
    }
}