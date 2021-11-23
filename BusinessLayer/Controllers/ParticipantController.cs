using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
        [Route("Participant")]
        public class ParticipantController : Controller
        {
            private IParticipantWebService ParticipantWebService;

            public ParticipantController(IParticipantWebService ParticipantWebService)
            {
                this.ParticipantWebService = ParticipantWebService;
            }

            [HttpGet]
            [Route("/Participants/{id}")]
            public async Task<ActionResult<IList<string>>>
                GetParticipantsAsync(int id)
            {
                try
                {
                    IList<string> Participants = await ParticipantWebService.GetParticipantsAsync(id);
                    return Ok(Participants);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }
    }
}