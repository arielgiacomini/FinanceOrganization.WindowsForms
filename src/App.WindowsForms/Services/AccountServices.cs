using App.Forms.Config;
using App.WindowsForms.Entities;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Domain.Entities;
using Newtonsoft.Json;

namespace App.WindowsForms.Services
{
    public static class AccountServices
    {
        public static string? Environment { get; set; } = string.Empty;

        public static async Task<IList<Account>> SearchAccounts(SearchAccountViewModel viewModel)
        {
            using var client = new HttpClient();

            var result = client.GetAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/account/search-all").Result;

            if (!result.IsSuccessStatusCode)
            {
                return AccountFixed.GetAccountsFixed();
            }

            var response = await result.Content.ReadAsStringAsync();

            var output = JsonConvert.DeserializeObject<SearchAccountOutput>(response);

            if (output == null)
            {
                return AccountFixed.GetAccountsFixed();
            }

            IList<Account> accounts = new List<Account>(output.Quantidade);

            foreach (var account in output.Data)
            {
                accounts.Add(new Account()
                {
                    Id = account.Id,
                    Name = account.Name!,
                    DueDate = account.DueDate,
                    ClosingDay = account.ClosingDay,
                    ConsiderPaid = account.ConsiderPaid,
                    AccountAgency = account.AccountAgency,
                    AccountNumber = account.AccountNumber,
                    AccountDigit = account.AccountDigit,
                    CardNumber = account.CardNumber,
                    CommissionPercentage = account.CommissionPercentage,
                    Enable = account.Enable,
                    CreationDate = account.CreationDate,
                    LastChangeDate = account.LastChangeDate,
                    IsCreditCard = account.IsCreditCard
                });
            }

            return accounts;
        }
    }
}