using App.Forms.Config;
using App.WindowsForms.Enums;
using App.WindowsForms.Services.Output;
using App.WindowsForms.ViewModel;
using Newtonsoft.Json;

namespace App.WindowsForms.Services
{
    public static class CategoryServices
    {
        public static string? Environment { get; set; } = string.Empty;

        public static async Task<SearchCategoryOutput> SearchCategories(SearchCategoryViewModel searchCategory)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("accountType", searchCategory.AccountType?.GetDescription());
            var result = client.GetAsync($"{UrlConfig.GetFinanceOrganizationApiUrl(Environment)}/v1/category/search").Result;

            if (!result.IsSuccessStatusCode)
            {
                return new SearchCategoryOutput();
            }

            var response = await result.Content.ReadAsStringAsync();

            var arrayString = JsonConvert.DeserializeObject<string[]>(response);

            SearchCategoryOutput searchCategoryOutput = new SearchCategoryOutput();
            searchCategoryOutput.Categories = arrayString;

            return searchCategoryOutput;
        }
    }
}