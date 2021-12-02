using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class GameMiddlepoint : IGameMiddlepoint
    {
        private IGameWebService GameWebService;
        private IGameListWebService gameListWebService;

        public GameMiddlepoint(IGameWebService gameWebService, IGameListWebService gameListWebService )
        {
            GameWebService = gameWebService;
            this.gameListWebService = gameListWebService;
        }

        public async Task<IList<Game>> GetGGLAsync()
        {
            var ggl = await GameWebService.GetGamesAsync(true);
            return ggl;
        }
        
        public async Task<IList<Game>> GetSuggestedGamesAsync()
        {
            var suggestedGames = await GameWebService.GetGamesAsync(false);
            return suggestedGames;
        }

        public async Task AddGameAsync(Game game)
        {
            Console.WriteLine("Game name: " + game.name);
            game.approved = true;
            await GameWebService.AddGameAsync(game);
        }
        
        public async Task<IList<int>> GetUserGamesIdsAsync(string user)
        {
            var userGames = await gameListWebService.GetUserGameListAsync(user);
            return userGames.Select(g => g.id).ToList();
        }

        public async Task UpdateGameApprovalAsync(Game game)
        {
            game.approved = true;
            await GameWebService.EditGameAsync(game);
        }
    }
}