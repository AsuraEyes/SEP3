using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class EventService : IEventService
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient Client;
        
        public EventService()
        {
            Client = new HttpClient();
        }
        public async Task<IList<Event>> GetEventsAsync()
        {
            var stringAsync = Client.GetStringAsync(uri + "/Games");
            var Event = await stringAsync;
            var Events = JsonSerializer.Deserialize<List<Event>>(Event, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Events;
        }
    }
}