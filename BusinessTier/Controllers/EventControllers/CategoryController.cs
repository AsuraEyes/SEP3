using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.EventWebServices.Categories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.EventControllers
{
    [ApiController]
    [Route("Event")]
    public class CategoryController : Controller
    {
        private readonly ICategoryWebService categoryWebService;

        public CategoryController(ICategoryWebService categoryWebService)
        {
            this.categoryWebService = categoryWebService;
        }
        [HttpGet]
        [Route("/Categories")]
        public async Task<ActionResult<IList<Category>>> GetCategoriesAsync()
        {
            try
            {
                var categories = await categoryWebService.GetCategoriesAsync();
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