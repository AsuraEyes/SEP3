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
    [Route("Organizer")]
    public class OrganizerController : Controller
    {
        private IOrganizerWebService organizerWebService;

        public OrganizerController(IOrganizerWebService organizerWebService)
        {
            this.organizerWebService = organizerWebService;
        }

        [HttpGet]
        [Route("/Organizers/{id}")]
        public async Task<ActionResult<IList<string>>>
            GetOrganizersAsync(int id)
        {
            try
            {
                IList<string> organizers = await organizerWebService.GetOrganizersAsync(id);
                return Ok(organizers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("/{id}")]
        public async Task JoinEventResult(int id, [FromBody] string username)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                await organizerWebService.CoOrganizeEvent(id, username);
                Created($"/{id}", "username");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("/{id}")]
        public async Task WithdrawEventAsync(int id, [FromBody] string username)
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
    }
}