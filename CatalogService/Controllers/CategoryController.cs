using CatalogService.Application;
using CatalogService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger) 
        {
            _logger = logger;
            _categoryService = new CategoryService();
        }

        [HttpGet("GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [HttpGet("GetCategory/{id}")]
        public Category GetCategory([FromQuery] int id)
        {
            return _categoryService.GetCategory(id);
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpPost("RemoveCategory")]
        public IActionResult RemoveCategory([FromQuery] int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }

        [HttpPost("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            _categoryService.UpdateCategory(category);
            return NoContent();
        }
    }
}
