using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("Event")]
    public class UserController : Controller
    {
        private IUserWebService UserWebService;

        public UserController(IUserWebService userWebService)
        {
            this.UserWebService = userWebService;
        }
        
        [HttpPost]
        [Route("/User")]
        public async Task<ActionResult> ValidateUserAsync([FromBody] User user)
        {
            try
            {
                //call validation class
                await UserWebService.ValidateUserAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/User/Validate")]
        public async Task<ActionResult<string>> GetValidatedUser()
        {
            try
            {
                string user = await UserWebService.GetValidatedUser();
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}