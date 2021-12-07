using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("EventOrganizer")]
    public class EventOrganizerController : Controller
    {
        private readonly IEventOrganizerWebService eventOrganizerWebService;

        public EventOrganizerController(IEventOrganizerWebService eventOrganizerWebService)
        {
            this.eventOrganizerWebService = eventOrganizerWebService;
        }
        
        [HttpGet]
        [Route("/OrganizerEvents")]
        public async Task<ActionResult<IList<Event>>> GetOrganizerEventsAsync([FromQuery] string username)
        {
            try
            {
                var organizersEvent = await eventOrganizerWebService.GetOrganizerEventsAsync(username);
                return Ok(organizersEvent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  StatusCode(500, e.Message);
            }
        }
    }
}