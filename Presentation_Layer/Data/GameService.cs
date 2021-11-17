using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class GameService : IGameService
    {
        private string uri = "https://localhost:5000";
        private readonly HttpClient client;

        public GameService()
        {
            client = new HttpClient();
        }
        
        public async Task<Game> GetGameAsync(int id)
        {
            var stringAsync = client.GetStringAsync(uri + $"/Game/{id}");
            var Gamea = await stringAsync;
            var Game = JsonSerializer.Deserialize<Game>(Gamea, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Game;
        }

        public async Task AddGameAsync(Game Game)
        {
            string GameAsJson = JsonSerializer.Serialize(Game);
            HttpContent content = new StringContent(GameAsJson,
                Encoding.UTF8,
                "application/json");
             await client.PostAsync(uri+"/Game", content);
        }

        public async Task<IList<Game>> GetGamesAsync()
        {
            var stringAsync = client.GetStringAsync(uri + "/Games");
            var Game = await stringAsync;
            var Games = JsonSerializer.Deserialize<List<Game>>(Game, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Games;
        }
        
       /* public async Task<IList<Game>> GetUserGamesAsync(User user)
        {
            var stringAsync = client.GetStringAsync(uri + "/UserGames");
            var Game = await stringAsync;
            var Games = JsonSerializer.Deserialize<List<Game>>(Game, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Games;
        }*/

        public async Task UpdateGameAsync(Game Game)
        {
            string GameAsJson = JsonSerializer.Serialize(Game);
            HttpContent content = new StringContent(GameAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/Game/", content);
        }

        public async Task RemoveGameAsync(Game Game)
        {
            await client.DeleteAsync($"{uri}/Game/{Game.Id}");
        }
        
    }
}