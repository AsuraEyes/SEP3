using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation_Layer.Data
{
    public class OrganizerService : IOrganizerService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient Client;

        public OrganizerService()
        {
            Client = new HttpClient();
        }

        public async Task<IList<string>> GetOrganizersAsync(int id)
        {
            var stringAsync = Client.GetStringAsync(uri + $"/Organizers/{id}");
            var organizers = await stringAsync;
            var organizersList = JsonSerializer.Deserialize<List<string>>(organizers, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return organizersList;
        }
        
        public async Task CoOrganizeEvent(int id, string username)
        {
            var organizerAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(organizerAsJson, Encoding.UTF8, "application/json");
            await Client.PostAsync(uri + $"/Organizers/{id}", content);
        }
        
        public async Task WithdrawEvent(int id, string username)
        {
            var organizerAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(organizerAsJson, Encoding.UTF8, "application/json");
            await Client.PatchAsync(uri + $"/Organizers/{id}", content);
        }
    }
}