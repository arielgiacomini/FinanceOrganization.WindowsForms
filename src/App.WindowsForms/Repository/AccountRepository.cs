using App.WindowsForms.Entities;

namespace App.WindowsForms.Repository
{
    public class AccountRepository
    {
        public Dictionary<int, Account> _accounts = new();

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
                if (itemAccount.Value.Name.StartsWith(account))
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
                    if (itemAccount.Name.StartsWith("Cartão de Crédito"))
                    {
                        accounts.Add(itemAccount);
                    }
                }
            }

            return accounts;
        }
    }
}