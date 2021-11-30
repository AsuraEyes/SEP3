using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("EventOrganizer")]
    public class EventOrganizerController : Controller
    {
        private IEventOrganizerWebService EventOrganizerWebService;

        public EventOrganizerController(IEventOrganizerWebService eventOrganizerWebService)
        {
            EventOrganizerWebService = eventOrganizerWebService;
        }
        
        [HttpGet]
        [Route("/OrganizerEvents")]
        public async Task<ActionResult<IList<Event>>> GetOrganizerEventsAsync([FromQuery] string username)
        {
            try
            {
                var organizersEvent = await EventOrganizerWebService.GetOrganizerEventsAsync(username);
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