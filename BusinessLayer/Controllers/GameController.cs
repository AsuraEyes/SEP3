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
        private IGameWebService gameWebService;
        private IGameMiddlepoint gameMiddlepoint;

        public GameController(IGameWebService gameWebService, IGameMiddlepoint gameMiddlepoint)
        {
            this.gameWebService = gameWebService;
            this.gameMiddlepoint = gameMiddlepoint;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Game>> getGame(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var response = await gameWebService.GetGameAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/GGL")]
        public async Task<ActionResult<IList<Game>>>
            GetGGLAsync()
        {
            try
            {
                IList<Game> games = await gameMiddlepoint.GetGGLAsync();
                return Ok(games);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/SuggestedGames")]
        public async Task<ActionResult<IList<Game>>>
            GetSuggestedGamesAsync()
        {
            try
            {
                IList<Game> games = await gameMiddlepoint.GetSuggestedGamesAsync();
                return Ok(games);
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
                await gameWebService.RemoveGameAsync(id);
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
                await gameWebService.AddGameAsync(Game);
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
        public async Task<ActionResult<Game>> UpdateGameApprovalAsync([FromBody] Game Game)
        {
            try
            {
                await gameMiddlepoint.UpdateGameApprovalAsync(Game);
                return Ok(Game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("/Game/EditGame")]
        public async Task<ActionResult<Game>> EditGameAsync([FromBody] Game Game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await gameWebService.EditGameAsync(Game);
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