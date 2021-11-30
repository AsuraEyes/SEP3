using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class ParticipantService : IParticipantService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient Client;

        public ParticipantService()
        {
            Client = new HttpClient();
        }

        public async Task<IList<string>> GetParticipantsAsync(int id)
        {
            var stringAsync = Client.GetStringAsync(uri + $"/Participants/{id}");
            var Participants = await stringAsync;
            var ParticipantsList = JsonSerializer.Deserialize<List<string>>(Participants, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return ParticipantsList;
        }
        
        public async Task JoinEvent(int id, string username)
        {
            var participantAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(participantAsJson, Encoding.UTF8, "application/json");
            await Client.PostAsync(uri+$"/{id}", content);
        }
        
        public async Task WithdrawEvent(int id, string username)
        {
            var participantAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(participantAsJson, Encoding.UTF8, "application/json");
            await Client.PatchAsync(uri+$"/{id}", content);
        }

        public async Task<EventList> GetParticipantEvents(string username)
        {
            var participantsEvent = Client.GetStringAsync(uri + $"/ParticipantEvents/?username={username}");
            var participantsEvents = await participantsEvent;
            var eventList = JsonSerializer.Deserialize<EventList>(participantsEvents, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return eventList;
        }
    }
}