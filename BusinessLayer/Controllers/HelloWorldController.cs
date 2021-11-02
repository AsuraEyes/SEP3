using System;
using System.Threading.Tasks;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IUserService UserService;

        public HelloWorldController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> HelloWorld()
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var response = await UserService.HelloWorld();
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}