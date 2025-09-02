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

        public static async Task<CreateCashReceivableOutput> CreateCashReceivable(CreateCashReceivableViewModel createViewModel)
        {
            using var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(createViewModel), Encoding.UTF8, "application/json");

            var result = client.PostAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/cash-receivable/register", content).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new CreateCashReceivableOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CreateCashReceivableOutput>(response) ?? new CreateCashReceivableOutput();
        }

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

        public static async Task<EditCashReceivableOutput> UpdateCashReceivable(EditCashReceivableViewModel viewModel)
        {
            using var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
            var result = client.PutAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/cash-receivable/edit", content).Result;
            if (!result.IsSuccessStatusCode)
            {
                return new EditCashReceivableOutput();
            }
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EditCashReceivableOutput>(response) ?? new EditCashReceivableOutput();
        }
    }
}