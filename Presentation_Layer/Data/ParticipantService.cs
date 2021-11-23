using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
    }
}