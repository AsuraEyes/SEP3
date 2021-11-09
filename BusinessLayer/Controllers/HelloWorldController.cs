using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Data;
using MessageServerReference;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route ("Message")]
    public class HelloWorldController : Controller
    {
        //private readonly IUserService UserService;
        private ISOAPWebService soapWebService;

        public HelloWorldController(ISOAPWebService soapWebService)
        {
            this.soapWebService = soapWebService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<message>> getMessage(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var response = await soapWebService.GetMessageAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/messages")]
        public async Task<ActionResult<IList<message>>>
            GetMessagesAsync()
        {
            try
            {
                IList<message> adults = await soapWebService.GetMessagesAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> RemoveMessageAsync([FromRoute] int id)
        {
            try
            {
                await soapWebService.RemoveMessageAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<message>> AddMessageAsync([FromBody] message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await soapWebService.AddMessageAsync(message);
                return Created($"/{message.id}", message); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<message>> UpdateMessageAsync([FromBody] message message)
        {
            try
            {
                await soapWebService.EditMessageAsync(message);
                return Ok(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}