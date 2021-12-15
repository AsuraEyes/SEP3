using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.EventWebServices.Organizers;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.EventControllers
{
    [ApiController]
    [Route("Organizer")]
    public class OrganizerController : Controller
    {
        private readonly IOrganizerWebService organizerWebService;

        public OrganizerController(IOrganizerWebService organizerWebService)
        {
            this.organizerWebService = organizerWebService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<IList<string>>>
            GetOrganizersAsync(int id)
        {
            try
            {
                var organizers = await organizerWebService.GetOrganizersAsync(id);
                return Ok(organizers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("{id:int}")]
        public async Task JoinEventResultAsync(int id, [FromBody] string username)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                await organizerWebService.CoOrganizeEventAsync(id, username);
                Created($"/{id}", "username");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task WithdrawEventAsync([FromQuery]int id, [FromQuery] string username)
        {
            try
            {
                await organizerWebService.WithdrawEventAsync(id, username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet]
        [Route("/CoOrganizerEvents")]
        public async Task<ActionResult<IList<Event>>> GetCoOrganizerEventsAsync([FromQuery] string username)
        {
            try
            {
                var organizersEvent = await organizerWebService.GetCoOrganizerEventsAsync(username);
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