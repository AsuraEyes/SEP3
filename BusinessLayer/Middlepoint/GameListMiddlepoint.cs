using System;
using System.Threading.Tasks;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class GameListMiddlepoint : IGameListMiddlepoint
    {
        private IGameListWebService gameListWebService;
        
        public GameListMiddlepoint(IGameListWebService gameListWebService)
        {
            this.gameListWebService = gameListWebService;
        }

        public async Task GameListUpdate(GameListUpdate gameListUpdate)
        {
            if (gameListUpdate.inList)
            {
                //add to list
                try
                {
                    await gameListWebService.AddGameToUserGameListAsync(gameListUpdate.username, gameListUpdate.gameId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                //remove from list
                try
                {
                    await gameListWebService.RemoveGameFromUserGameList(gameListUpdate.username, gameListUpdate.gameId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}