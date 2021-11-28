using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class GameMiddlepoint : IGameMiddlepoint
    {
        private IGameWebService GameWebService;
        private Game game;

        public GameMiddlepoint(IGameWebService gameWebService)
        {
            GameWebService = gameWebService;
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
            this.game = game;
            game.approved = true;
            await GameWebService.AddGameAsync(game);
        }
    }
}