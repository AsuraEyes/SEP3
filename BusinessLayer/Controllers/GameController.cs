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
    [Route ("Game")]
    public class GameController : Controller
    {
        //private readonly IUserService UserService;
        private IGameWebService soapWebService;
        private IGameMiddlepoint gameMiddlepoint;

        public GameController(IGameWebService soapWebService, GameMiddlepoint gameMiddlepoint)
        {
            this.soapWebService = soapWebService;
            this.gameMiddlepoint = gameMiddlepoint;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Game>> getGame(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var response = await soapWebService.GetGameAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/Games")]
        public async Task<ActionResult<IList<Game>>>
            GetGamesAsync()
        {
            try
            {
                IList<Game> games = await soapWebService.GetGamesAsync();
                return Ok(games);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
       [HttpGet]
        [Route("/UserGames/{username}")]
        public async Task<ActionResult<IList<Game>>>
            GetUserGamesAsync([FromRoute]String username)
        {
            try
            {
                IList<Game> adults = await soapWebService.GetUserGamesAsync(username);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> RemoveGameAsync([FromRoute] int id)
        {
            try
            {
                await soapWebService.RemoveGameAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Game>> AddGameAsync([FromBody] Game Game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await soapWebService.AddGameAsync(Game);
                return Created($"/{Game.id}", Game); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("/Game/CreateGame")]
        public async Task<ActionResult<Game>> AddGameAsyncAdmin([FromBody] Game Game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await gameMiddlepoint.AddGameAsync(Game);
                return Created($"/{Game.id}", Game); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<Game>> UpdateGameAsync([FromBody] Game Game)
        {
            try
            {
                await soapWebService.EditGameAsync(Game);
                return Ok(Game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}