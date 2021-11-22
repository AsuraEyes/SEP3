using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("Event")]
    public class EventController : Controller
    {
        private IEventWebService EventWebService;

        public EventController(IEventWebService EventWebService)
        {
            this.EventWebService = EventWebService;
        }

        [HttpGet]
        [Route("/Events")]
        public async Task<ActionResult<IList<Event>>> GetEventsAsync()
        {
            try
            {
                IList<Event> events = await EventWebService.GetEventsAsync();
                return Ok(events);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/FilteredEvents{filter}/{category}")]
        public async Task<ActionResult<IList<Event>>> GetFilteredEventsAsync(int category, string filter)
        {
            int currentPage = 1;
            int resultsPerPage = 9;
            try
            {
                IList<Event> filteredEventsAsync = await EventWebService.GetFilteredEventsAsync(filter, category, currentPage, resultsPerPage);
                return Ok(filteredEventsAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEventAsync([FromBody] Event Event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await EventWebService.CreateEventAsync(Event);
                return Ok(Event);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}