using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route ("GameList")]
    public class GameListController : Controller
    {
        private readonly IGameListWebService gameListWebService;
        private readonly IGameListMiddlepoint gameListMiddlePoint;
        private readonly IGameMiddlepoint gameMiddlePoint;
            
        public GameListController(IGameListWebService gameListWebService, IGameListMiddlepoint gameListMiddlePoint, IGameMiddlepoint gameMiddlePoint)
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