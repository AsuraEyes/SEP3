using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("Event")]
    public class UserController : Controller
    {
        private IUserWebService UserWebService;
        private IUserMiddlepoint UserMiddlepoint;

        public UserController(IUserWebService userWebService, IUserMiddlepoint userMiddlepoint)
        {
            UserWebService = userWebService;
            UserMiddlepoint = userMiddlepoint;
        }
        
        [HttpPost]
        [Route("/User")]
        public async Task<ActionResult> ValidateUserAsync([FromBody] User user)
        {
            try
            {
                //call validation class
                await UserMiddlepoint.ValidateUserAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("/User/CreateAccount")]
        public async Task<ActionResult> CreateAccountAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await UserMiddlepoint.CreateAccountAsync(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/User/Validate")]
        public async Task<ActionResult<User>> GetValidatedUser()
        {
            try
            {
                User user = await UserMiddlepoint.GetValidatedUser();
                Console.WriteLine("controller: "+user.role);
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