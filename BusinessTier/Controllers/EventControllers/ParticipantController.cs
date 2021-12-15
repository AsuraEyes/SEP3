using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.EventWebServices.Participants;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.EventControllers
{
    [ApiController]
        [Route("Participant")]
        public class ParticipantController : Controller
        {
            private readonly IParticipantWebService participantWebService;

            public ParticipantController(IParticipantWebService participantWebService)
            {
                this.participantWebService = participantWebService;
            }

            [HttpGet]
            [Route("All/{id:int}")]
            public async Task<ActionResult<IList<string>>>
                GetParticipantsAsync(int id)
            {
                try
                {
                    var participants = await participantWebService.GetParticipantsAsync(id);
                    return Ok(participants);
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
                    await participantWebService.JoinEventAsync(id, username);
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
                    await participantWebService.WithdrawEventAsync(id, username);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            
            [HttpGet]
            [Route("Events")]
            public async Task<ActionResult<IList<Event>>> GetParticipantEventsAsync([FromQuery] string username)
            {
                try
                {
                    var organizersEvent = await participantWebService.GetParticipantEventsAsync(username);
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