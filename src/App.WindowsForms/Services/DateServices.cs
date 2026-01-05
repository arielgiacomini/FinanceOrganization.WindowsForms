using App.Forms.Config;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Newtonsoft.Json;

namespace App.WindowsForms.Services
{
    public static class DateServices
    {
        public static string? Environment { get; set; } = string.Empty;

        public static async Task<SearchDateMonthYearOutput> SearchMonthYears(SearchDateYearMonthViewModel searchViewModel)
        {
            using var client = new HttpClient();

            if (searchViewModel.StartYear.HasValue)
            {
                client.DefaultRequestHeaders.Add("startYear", searchViewModel.StartYear?.ToString());
            }

            string filterUrl = string.Empty;
            if (searchViewModel.EndYear.HasValue)
            {
                filterUrl = "?endYear=" + searchViewModel.EndYear.Value.ToString();
            }

            var result = client.GetAsync(string.Concat(UrlConfig.GetFinanceOrganizationApiUrl(Environment), "/v1/date/month-year-all", filterUrl)).Result;

            if (!result.IsSuccessStatusCode)
            {
                return new SearchDateMonthYearOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            var searchOutput = JsonConvert.DeserializeObject<SearchDateMonthYearOutput>(response);

            if (searchOutput == null)
            {
                return new SearchDateMonthYearOutput();
            }

            return searchOutput;
        }
    }
}