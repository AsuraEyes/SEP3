using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class GameMiddlepoint : IGameMiddlepoint
    {
        private GameWebService GameWebService;
        private Game game;

        public GameMiddlepoint(GameWebService gameWebService)
        {
            GameWebService = gameWebService;
        }

        public async Task AddGameAsync(Game game)
        {
            this.game = game;
            game.approved = true;
            await GameWebService.AddGameAsync(game);
        }
    }
}