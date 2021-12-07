using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public class OrganizerService : IOrganizerService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public OrganizerService()
        {
            client = new HttpClient();
        }

        public async Task<IList<string>> GetOrganizersAsync(int id)
        {
            var stringAsync = client.GetStringAsync(uri + $"/Organizers/{id}");
            var organizers = await stringAsync;
            var organizersList = JsonSerializer.Deserialize<List<string>>(organizers, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return organizersList;
        }
        
        public async Task CoOrganizeEventAsync(int id, string username)
        {
            var organizerAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(organizerAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + $"/Organizers/{id}", content);
        }
        
        public async Task WithdrawEventAsync(int id, string username)
        {
            var organizerAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(organizerAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync(uri + $"/Organizers/{id}", content);
        }
        
        public async Task<EventList> GetCoOrganizerEventsAsync(string username)
        {
            var coOrganizersEvent = client.GetStringAsync(uri + $"/CoOrganizerEvents/?username={username}");
            var coOrganizersEvents = await coOrganizersEvent;
            var eventList = JsonSerializer.Deserialize<EventList>(coOrganizersEvents, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return eventList;
        }
    }
}