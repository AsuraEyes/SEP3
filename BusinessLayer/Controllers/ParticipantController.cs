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
                    await ParticipantWebService.JoinEventAsync(id, username);
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
                    await ParticipantWebService.WithdrawEventAsync(id, username);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
    }
}