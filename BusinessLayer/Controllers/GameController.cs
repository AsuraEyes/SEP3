using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route ("Game")]
    public class GameController : Controller
    {
        //private readonly IUserService UserService;
        private ISOAPWebService soapWebService;

        public GameController(ISOAPWebService soapWebService)
        {
            this.soapWebService = soapWebService;
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
                IList<Game> adults = await soapWebService.GetGamesAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/UserGames")]
        public async Task<ActionResult<IList<Game>>>
            GetUserGamesAsync([FromBody]User user)
        {
            try
            {
                IList<Game> adults = await soapWebService.GetUserGamesAsync(user);
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