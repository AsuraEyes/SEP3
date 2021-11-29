using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class GameListService: IGameListService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public GameListService()
        {
            client = new HttpClient();
        }
        public async Task<IList<Game>> GetUserGamesAsync(string username)
        {
            var stringAsync = client.GetStringAsync(uri + $"/UserGames/?username={username}");
            var Game = await stringAsync;
            var Games = JsonSerializer.Deserialize<List<Game>>(Game, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Games;
        }
        
        public async Task<IList<int>> GetUserGamesIdsAsync(string username)
        {
            var stringAsync = client.GetStringAsync(uri + $"/UserGamesIds/?username={username}");
            var ids = await stringAsync;
            var gamesIds = JsonSerializer.Deserialize<List<int>>(ids, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return gamesIds;
        }
    }
}