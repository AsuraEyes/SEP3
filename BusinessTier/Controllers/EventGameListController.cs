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
    [Route ("EventGameList")]
    public class EventGameListController : Controller
    {
        private readonly IEventGameListWebService eventGameListWebService;
        private readonly IEventGameListMiddlePoint eventGameListMiddlePoint;

        public EventGameListController(IEventGameListWebService eventGameListWebService, IEventGameListMiddlePoint eventGameListMiddlePoint)
        {
            this.eventGameListWebService = eventGameListWebService;
            this.eventGameListMiddlePoint = eventGameListMiddlePoint;
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IList<Game>>> GetAllEventGameListAsync(int id)
        {
            try
            {
                IList<Game> allEventGameList = await eventGameListWebService.GetAllEventGameListAsync(id);
                return Ok(allEventGameList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("/UpdateEventGame")]
        public async Task UpdateUserGamesAsync([FromBody] EventGameListUpdate eventGameListUpdate)
        {
            await eventGameListMiddlePoint.EventGameListUpdateAsync(eventGameListUpdate);
        }
    }
}