using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.Categories
{
    public class CategoryService: ICategoryService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CategoryService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            var stringAsync = client.GetStringAsync(uri + "/Categories");
            var category = await stringAsync;
            var categories = JsonSerializer.Deserialize<List<Category>>(category, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return categories;
        }
    }
}