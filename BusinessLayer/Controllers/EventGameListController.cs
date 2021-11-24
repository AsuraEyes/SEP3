using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route ("EventGameList")]
    public class EventGameListController : Controller
    {
        private IEventGameListWebService eventGameListWebService;

        public EventGameListController(IEventGameListWebService eventGameListWebService)
        {
            this.eventGameListWebService = eventGameListWebService;
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IList<Game>>>
            GetAllEventGameListAsync(int id)
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
    }
}