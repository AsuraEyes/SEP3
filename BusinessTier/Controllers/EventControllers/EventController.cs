using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.EventWebServices.Events;
using BusinessTier.MiddlePoint.EventMiddlePoints;
using BusinessTier.MiddlePoint.EventMiddlePoints.Events;
using BusinessTier.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.EventControllers
{
    [ApiController]
    [Route("Event")]
    public class EventController : Controller
    {
        private readonly IEventWebService eventWebService;
        private readonly IEventMiddlePoint eventMiddlePoint;

        public EventController(IEventWebService eventWebService, IEventMiddlePoint eventMiddlePoint)
        {
            this.eventWebService = eventWebService;
            this.eventMiddlePoint = eventMiddlePoint;
        }

        [HttpGet]
        [Route("/FilteredEvents")]
        public async Task<ActionResult<EventList>> GetFilteredEventsAsync([FromQuery] FilterRest filterRest)
        {
            try
            {
                EventList filteredEventsAsync = await eventMiddlePoint.EventFilterAsync(filterRest);
                return Ok(filteredEventsAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Event>> GetEventAsync(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var response = await eventWebService.GetEventAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEventAsync([FromBody] Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await eventWebService.CreateEventAsync(newEvent);
                return Ok(newEvent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<Event>> UpdateEventAsync([FromBody] Event eventToBeUpdated)
        {
            try
            {
                await eventWebService.EditEventAsync(eventToBeUpdated);
                return Ok(eventToBeUpdated);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Event>> CancelEventAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await eventWebService.CancelEventAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}