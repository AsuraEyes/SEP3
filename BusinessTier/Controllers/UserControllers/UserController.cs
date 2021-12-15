using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.UserWebServices;
using BusinessTier.MiddlePoint.UserMiddlePoints;
using BusinessTier.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.UserControllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserWebService userWebService;
        private readonly IUserMiddlePoint userMiddlePoint;

        public UserController(IUserWebService userWebService, IUserMiddlePoint userMiddlePoint)
        {
            this.userWebService = userWebService;
            this.userMiddlePoint = userMiddlePoint;
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> ValidateUserAsync([FromBody] User user)
        {
            try
            {
                var validateUser = await userMiddlePoint.ValidateUserAsync(user);
                return Ok(validateUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateAccountAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userMiddlePoint.CreateAccountAsync(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserByUsernameAsync([FromQuery] string username)
        {
            try
            {
                var user = await userMiddlePoint.GetUserByUsernameAsync(username);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Promotion")]
        public async Task<ActionResult> RequestPromotionToOrganizerAsync([FromBody] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userMiddlePoint.RequestPromotionToOrganizer(username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAccountAsync([FromQuery] string username)
        {
            try
            {
                await userWebService.DeleteAccountAsync(username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("Promotion")]
        public async Task<ActionResult> AcceptPromotionAsync([FromBody] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userMiddlePoint.AcceptPromotion(username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("Promotion")]
        public async Task<ActionResult> DeclinePromotionAsync([FromBody]string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userMiddlePoint.DeclinePromotion(username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IList<User>>> GetUsersAsync([FromQuery] FilterRest filterRest)
        {
            try
            {
                var users = await userMiddlePoint.GetUsersAsync(filterRest);
                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);  
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult> EditAccountAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userWebService.UpdateUser(user);
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