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

    }
}