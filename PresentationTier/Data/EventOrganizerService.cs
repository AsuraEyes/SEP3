using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public class EventOrganizerService : IEventOrganizerService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public EventOrganizerService()
        {
            client = new HttpClient();
        }

        public async Task<EventList> GetOrganizerEventsAsync(string username)
        {
            var organizersEvent = client.GetStringAsync(uri + $"/OrganizerEvents?username={username}");
            var organizersEvents = await organizersEvent;
            var eventList = JsonSerializer.Deserialize<EventList>(organizersEvents, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return eventList;
        }
    }
}