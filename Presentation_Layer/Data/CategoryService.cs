using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class CategoryService: ICategoryService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient Client;

        public CategoryService()
        {
            Client = new HttpClient();
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            var stringAsync = Client.GetStringAsync(uri + "/Categories");
            var Category = await stringAsync;
            var Categories = JsonSerializer.Deserialize<List<Category>>(Category, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Categories;
        }
    }
}