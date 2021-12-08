using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.GameWebServices.GameLists;
using BusinessTier.MiddlePoint.GameMiddlePoints;
using BusinessTier.MiddlePoint.GameMiddlePoints.GameLists;
using BusinessTier.MiddlePoint.GameMiddlePoints.Games;
using BusinessTier.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.GameControllers
{
    [ApiController]
    [Route ("GameList")]
    public class GameListController : Controller
    {
        private readonly IGameListWebService gameListWebService;
        private readonly IGameListMiddlePoint gameListMiddlePoint;
        private readonly IGameMiddlePoint gameMiddlePoint;
            
        public GameListController(IGameListWebService gameListWebService, IGameListMiddlePoint gameListMiddlePoint, IGameMiddlePoint gameMiddlePoint)
        {
            this.gameListWebService = gameListWebService;
            this.gameListMiddlePoint = gameListMiddlePoint;
            this.gameMiddlePoint = gameMiddlePoint;
        }
        
        [HttpGet]
        [Route("/UserGames")]
        public async Task<ActionResult<IList<Game>>>
            GetUserGamesAsync([FromQuery]String username)
        {
            try
            {
                IList<Game> adults = await gameListWebService.GetUserGameListAsync(username);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("/UpdateGame")]
        public async Task UpdateUserGamesAsync([FromBody] GameListUpdate gameListUpdate)
        {
            await gameListMiddlePoint.GameListUpdate(gameListUpdate);
        }
        
        [HttpGet]
        [Route("/UserGamesIds")]
        public async Task<ActionResult<IList<Game>>>
            GetUserGamesIdsAsync([FromQuery]String username)
        {
            try
            {
                IList<int> adults = await gameMiddlePoint.GetUserGamesIdsAsync(username);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}