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
        [Route("/User")]
        public async Task<ActionResult> ValidateUserAsync([FromBody] User user)
        {
            try
            {
                User validateUser = await userMiddlePoint.ValidateUserAsync(user);
                return Ok(validateUser);
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
        [Route("/User/{username}")]
        public async Task<ActionResult<User>> GetUserByUsernameAsync([FromRoute] string username)
        {
            try
            {
                User user = await userMiddlePoint.GetUserByUsernameAsync(username);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("/User/RequestPromotion")]
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
        
        [HttpPost]
        [Route("/User/AcceptPromotion")]
        public async Task<ActionResult> AcceptPromotion([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userMiddlePoint.AcceptPromotion(user);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("/User/DeclinePromotion")]
        public async Task<ActionResult> DeclinePromotion([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userMiddlePoint.DeclinePromotion(user);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Users")]
        public async Task<ActionResult<IList<User>>> GetUsersAsync()
        {
            try
            {
                IList<User> users = await userWebService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);  
            }
        }
        
        [HttpPatch]
        [Route("/User/EditAccount")]
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