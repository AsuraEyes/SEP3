using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class GameMiddlePoint : IGameMiddlePoint
    {
        private readonly IGameWebService gameWebService;
        private readonly IGameListWebService gameListWebService;

        public GameMiddlePoint(IGameWebService gameWebService, IGameListWebService gameListWebService )
        {
            this.gameWebService = gameWebService;
            this.gameListWebService = gameListWebService;
        }

        public async Task<IList<Game>> GetGGLAsync()
        {
            var ggl = await gameWebService.GetGamesAsync(true);
            return ggl;
        }
        
        public async Task<IList<Game>> GetSuggestedGamesAsync()
        {
            var suggestedGames = await gameWebService.GetGamesAsync(false);
            return suggestedGames;
        }

        public async Task AddGameAsync(Game game)
        {
            game.approved = true;
            await gameWebService.SuggestGameAsync(game);
        }
        
        public async Task<IList<int>> GetUserGamesIdsAsync(string user)
        {
            var userGames = await gameListWebService.GetUserGameListAsync(user);
            return userGames.Select(g => g.id).ToList();
        }

        public async Task UpdateGameApprovalAsync(Game game)
        {
            game.approved = true;
            await gameWebService.EditGameAsync(game);
        }
    }
}