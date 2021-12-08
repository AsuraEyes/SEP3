using System;
using System.Threading.Tasks;
using BusinessTier.Data.GameWebServices.GameLists;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.GameMiddlePoints.GameLists
{
    public class GameListMiddlePoint : IGameListMiddlePoint
    {
        private readonly IGameListWebService gameListWebService;
        
        public GameListMiddlePoint(IGameListWebService gameListWebService)
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