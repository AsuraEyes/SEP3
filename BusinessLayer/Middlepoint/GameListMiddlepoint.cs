using System;
using System.Threading.Tasks;
using BusinessLayer.Data;
using BusinessLayer.Models;

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
            if (gameListUpdate.InList)
            {
                //add to list
                try
                {
                    await gameListWebService.AddGameToUserGameListAsync(gameListUpdate.Username, gameListUpdate.GameId);
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
                    await gameListWebService.RemoveGameFromUserGameListAsync(gameListUpdate.Username, gameListUpdate.GameId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}