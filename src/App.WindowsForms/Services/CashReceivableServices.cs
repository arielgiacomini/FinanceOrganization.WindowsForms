using App.Forms.Config;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Newtonsoft.Json;
using System.Text;

namespace App.WindowsForms.Services
{
    public static class CashReceivableServices
    {
        public static string? Environment { get; set; } = string.Empty;

        public static async Task<SearchCashReceivableOutput> SearchCashReceivable(SearchCashReceivableViewModel viewModel)
        {
            using var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");

            var result = client.PostAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/cash-receivable/search", content).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new SearchCashReceivableOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SearchCashReceivableOutput>(response) ?? new SearchCashReceivableOutput();
        }
    }
}