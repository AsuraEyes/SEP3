using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class EventGameListService : IEventGameListService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public EventGameListService()
        {
            client = new HttpClient();
        }
        
        public async Task<IList<Game>> GetAllEventGameListAsync(int id)
        {
            var stringAsync = client.GetStringAsync(uri + $"/EventGameList/{id}");
            var Game = await stringAsync;
            var Games = JsonSerializer.Deserialize<List<Game>>(Game, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Games;
        }
    }
}