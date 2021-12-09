using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.EventWebServices.EventOrganizers;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.EventControllers
{
    [ApiController]
    [Route("OrganizerEvents")]
    public class EventOrganizerController : Controller
    {
        private readonly IEventOrganizerWebService eventOrganizerWebService;

        public EventOrganizerController(IEventOrganizerWebService eventOrganizerWebService)
        {
            this.eventOrganizerWebService = eventOrganizerWebService;
        }
        
        [HttpGet]
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