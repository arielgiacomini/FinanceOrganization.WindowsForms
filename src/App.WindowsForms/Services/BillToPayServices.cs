using App.Forms.Config;
using App.Forms.Services.Output;
using App.Forms.ViewModel;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Newtonsoft.Json;
using System.Text;

namespace App.Forms.Services
{
    public static class BillToPayServices
    {
        public static string? Environment { get; set; } = string.Empty;

        public static async Task<CreateBillToPayOutput> CreateBillToPay(CreateBillToPayViewModel createBillToPayViewModel)
        {
            using var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(createBillToPayViewModel), Encoding.UTF8, "application/json");

            var result = client.PostAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/bills-to-pay/register", content).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new CreateBillToPayOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CreateBillToPayOutput>(response) ?? new CreateBillToPayOutput();
        }

        public static async Task<SearchBillToPayOutput> SearchBillToPay(SearchBillToPayViewModel searchBillToPayViewModel)
        {
            using var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(searchBillToPayViewModel), Encoding.UTF8, "application/json");

            var result = client.PostAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/bills-to-pay/search", content).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new SearchBillToPayOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SearchBillToPayOutput>(response) ?? new SearchBillToPayOutput();
        }

        public static async Task<PayBillToPayOutput> PayBillToPay(PayBillToPayViewModel payBillToPayViewModel)
        {
            using var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(payBillToPayViewModel), Encoding.UTF8, "application/json");

            var result = client.PatchAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/bills-to-pay/pay", content).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new PayBillToPayOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PayBillToPayOutput>(response) ?? new PayBillToPayOutput();
        }

        public static async Task<EditBillToPayOutput> EditBillToPay(EditBillToPayViewModel editBillToPayViewModel)
        {
            using var client = new HttpClient();

            var json = JsonConvert.SerializeObject(editBillToPayViewModel);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = client.PutAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/bills-to-pay/edit", content).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new EditBillToPayOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EditBillToPayOutput>(response) ?? new EditBillToPayOutput();
        }

        public static async Task<DeleteBillToPayOutput> DeleteBillToPay(DeleteBillToPayViewModel deleteBillToPayViewModel)
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Delete, $"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/bills-to-pay/delete")
            {
                Content = new StringContent(JsonConvert.SerializeObject(deleteBillToPayViewModel), Encoding.UTF8, "application/json")
            };

            var result = await client.SendAsync(request);

            if (!result.IsSuccessStatusCode)
            {
                var output = new DeleteBillToPayOutput();

                output.Output.Status = OutputStatus.HasInternalError;
                output.Output.Data = result.Content;

                return output;
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DeleteBillToPayOutput>(response) ?? new DeleteBillToPayOutput();
        }

        public static async Task<SearchMonthlyAverageAnalysisOutput> SearchMonthlyAverageAnalysis(SearchMonthlyAverageAnalysisViewModel viewModel)
        {
            using var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");

            var result = client.PostAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/bills-to-pay/SearchMonthlyAverageAnalysis", content).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new SearchMonthlyAverageAnalysisOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SearchMonthlyAverageAnalysisOutput>(response) ?? new SearchMonthlyAverageAnalysisOutput();
        }
    }
}