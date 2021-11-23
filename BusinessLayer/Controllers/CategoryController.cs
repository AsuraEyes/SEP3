using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("Event")]
    public class CategoryController : Controller
    {
        private ICategoryWebService categoryWebService;

        public CategoryController(ICategoryWebService categoryWebService)
        {
            this.categoryWebService = categoryWebService;
        }
        [HttpGet]
        [Route("/Categories")]
        public async Task<ActionResult<IList<Category>>>
            GetCategoriesAsync()
        {
            try
            {
                IList<Category> categories = await categoryWebService.getCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}