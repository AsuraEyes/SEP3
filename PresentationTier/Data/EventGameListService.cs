using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
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
            var game = await stringAsync;
            var games = JsonSerializer.Deserialize<List<Game>>(game, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return games;
        }

        public async Task UpdateEventGamesAsync(string username, int gameId, int eventId, bool inList)
        {
            var updateAsJson = JsonSerializer.Serialize(new EventGameListUpdate()
                {Username = username, GameId = gameId, EventId = eventId, InList = inList});
            HttpContent content = new StringContent(updateAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/UpdateEventGame", content);
        }
    }
}