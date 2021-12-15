using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.GameWebServices.GameLists;
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
        public async Task<ActionResult<IList<Game>>>
            GetUserGamesAsync([FromQuery]string username)
        {
            try
            {
                var adults = await gameListWebService.GetUserGameListAsync(username);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task EditUserGamesAsync([FromBody] GameListUpdate gameListUpdate)
        {
            await gameListMiddlePoint.GameListUpdate(gameListUpdate);
        }
        
        [HttpGet]
        [Route("Ids")]
        public async Task<ActionResult<IList<Game>>>
            GetUserGamesIdsAsync([FromQuery]string username)
        {
            try
            {
                var adults = await gameMiddlePoint.GetUserGamesIdsAsync(username);
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