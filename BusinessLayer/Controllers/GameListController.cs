using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route ("GameList")]
    public class GameListController : Controller
    {
        private IGameListWebService gameListWebService;
            
        public GameListController(IGameListWebService gameListWebService)
        {
            this.gameListWebService = gameListWebService;
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
    }
}