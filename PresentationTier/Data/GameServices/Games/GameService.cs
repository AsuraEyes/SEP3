using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.GameServices.Games
{
    public class GameService : IGameService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public GameService()
        {
            client = new HttpClient();
        }
        
        public async Task<Game> GetGameAsync(int id)
        {
            var stringAsync = await client.GetStringAsync(uri + $"/Game/{id}");
            var game = JsonSerializer.Deserialize<Game>(stringAsync, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return game;
        }

        public async Task SuggestGameAsync(Game game)
        {
            var gameAsJson = JsonSerializer.Serialize(game);
            HttpContent content = new StringContent(gameAsJson,
                Encoding.UTF8,
                "application/json");
             await client.PostAsync(uri+"/SuggestedGames", content);
        }
        
        public async Task CreateGameAsync(Game game)
        {
            var gameAsJson = JsonSerializer.Serialize(game);
            HttpContent content = new StringContent(gameAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+ "/Game", content);
        }

        public async Task<IList<Game>> GetLimitedSearchGGLAsync(FilterREST filterRest)
        {
            var search = $"?Search={filterRest.Search}&CurrentPage={filterRest.CurrentPage}";
            var stringAsync = client.GetStringAsync(uri + "/Game/GGL" + search);
            var game = await stringAsync;
            var games = JsonSerializer.Deserialize<List<Game>>(game, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return games;
        }
        
        public async Task<IList<Game>> GetSuggestedGamesAsync()
        {
            var stringAsync = client.GetStringAsync(uri + "/SuggestedGames");
            var game = await stringAsync;
            var games = JsonSerializer.Deserialize<List<Game>>(game, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return games;
        }

        public async Task EditGameAsync(Game game)
        {
            var gameAsJson = JsonSerializer.Serialize(game);
            HttpContent content = new StringContent(gameAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync(uri+"/Game", content);
        }

        public async Task EditGameApprovalAsync(Game game)
        {
            var gameAsJson = JsonSerializer.Serialize(game);
            HttpContent content = new StringContent(gameAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/Game/Approval", content);
        }

        public async Task RemoveGameAsync(Game game)
        {
            await client.DeleteAsync($"{uri}/Game/{game.Id}");
        }
        
    }
}