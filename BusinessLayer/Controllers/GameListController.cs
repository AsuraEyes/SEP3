using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route ("GameList")]
    public class GameListController : Controller
    {
        private IGameListWebService gameListWebService;
        private IGameMiddlepoint gameMiddlepoint;
            
        public GameListController(IGameListWebService gameListWebService, IGameMiddlepoint gameMiddlepoint)
        {
            this.gameListWebService = gameListWebService;
            this.gameMiddlepoint = gameMiddlepoint;
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
        
        [HttpGet]
        [Route("/UserGamesIds")]
        public async Task<ActionResult<IList<Game>>>
            GetUserGamesIdsAsync([FromQuery]String username)
        {
            try
            {
                IList<int> adults = await gameMiddlepoint.GetUserGamesIdsAsync(username);
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