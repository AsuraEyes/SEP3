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

        public async Task AddGameAsync(Game game)
        {
            this.game = game;
            game.approved = true;
            await GameWebService.AddGameAsync(game);
        }
    }
}