using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.Events
{
    public class EventService : IEventService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public EventService()
        {
            client = new HttpClient();
        }

        public async Task<EventList> GetFilteredEventsAsync(FilterREST filterRest)
        {
            var filters =
                $"?byDate={filterRest.ByDate}&byAvailability={filterRest.ByAvailability}&currentPage={filterRest.CurrentPage}&categoryId={filterRest.CategoryId}&resultsPerPage={filterRest.ResultsPerPage}";
            var stringAsync = client.GetStringAsync(uri + $"/FilteredEvents"+filters);
            var eventList = await stringAsync;
            var events = JsonSerializer.Deserialize<EventList>(eventList, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            return events;
        }
        
        public async Task<Event> GetEventAsync(int id)
        {
            var stringAsync = client.GetStringAsync(uri + $"/Event/{id}");
            var eventString = await stringAsync;
            var deserializedEvent = JsonSerializer.Deserialize<Event>(eventString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserializedEvent;
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            var eventAsJson = JsonSerializer.Serialize(newEvent);
            HttpContent content = new StringContent(eventAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Event", content);
        }
        
        public async Task CancelEventAsync(Event eventToBeCancelled)
        {
            await client.DeleteAsync($"{uri}/Event/{eventToBeCancelled.Id}");
        }

        public async Task EditEventAsync(Event eventToBeEdited)
        {
            var eventAsJson = JsonSerializer.Serialize(eventToBeEdited);
            HttpContent content = new StringContent(eventAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Event", content);
        }
    }
}