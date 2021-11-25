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
    [Route("Event")]
    public class EventController : Controller
    {
        private IEventWebService EventWebService;
        private IEventMiddlePoint eventMiddlePoint;

        public EventController(IEventWebService EventWebService, IEventMiddlePoint eventMiddlePoint)
        {
            this.EventWebService = EventWebService;
            this.eventMiddlePoint = eventMiddlePoint;
        }

        [HttpGet]
        [Route("/Events")]
        public async Task<ActionResult<IList<Event>>> GetEventsAsync()
        {
            try
            {
                IList<Event> events = await EventWebService.GetEventsAsync();
                return Ok(events);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/FilteredEvents/{byDate}/{byAvailability}/{currentPage}/{categoryId}")]
        public async Task<ActionResult<IList<Event>>> GetFilteredEventsAsync(bool byDate, bool byAvailability, int currentPage, int categoryId)
        {
            try
            {
                EventList filteredEventsAsync = await eventMiddlePoint.eventFilter(byDate, byAvailability, currentPage, categoryId);
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
                var response = await EventWebService.GetEventAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEventAsync([FromBody] Event Event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await EventWebService.CreateEventAsync(Event);
                return Ok(Event);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("/Events/{id}")]
        public async Task<ActionResult<Event>> CancelEventAsync(int id)
        {
            Console.WriteLine(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await EventWebService.CancelEventAsync(id);
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