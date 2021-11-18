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
    }
}