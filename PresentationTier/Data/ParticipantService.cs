using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public class ParticipantService : IParticipantService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public ParticipantService()
        {
            client = new HttpClient();
        }

        public async Task<IList<string>> GetParticipantsAsync(int id)
        {
            var stringAsync = client.GetStringAsync(uri + $"/Participants/{id}");
            var participants = await stringAsync;
            var participantsList = JsonSerializer.Deserialize<List<string>>(participants, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return participantsList;
        }
        
        public async Task JoinEventAsync(int id, string username)
        {
            var participantAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(participantAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri+$"/{id}", content);
        }
        
        public async Task WithdrawEventAsync(int id, string username)
        {
            var participantAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(participantAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync(uri+$"/{id}", content);
        }

        public async Task<EventList> GetParticipantEventsAsync(string username)
        {
            var participantsEvent = client.GetStringAsync(uri + $"/ParticipantEvents/?username={username}");
            var participantsEvents = await participantsEvent;
            var eventList = JsonSerializer.Deserialize<EventList>(participantsEvents, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return eventList;
        }
    }
}