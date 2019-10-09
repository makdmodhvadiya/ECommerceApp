using ECommerce.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories.ToArray());
        }

        [HttpGet("{categoryId}/attributes")]
        public IActionResult Get(int categoryId)
        {
            var categories = _categoryService.GetAttributeLookups(categoryId);
            return Ok(categories);
        }
    }
}
