using CapestoneProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Retrieves all active categories from the system
        /// </summary>
        /// <returns>A list of all categories</returns>
        /// <response code="200">Returns the list of categories</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("[action]")]
        public IActionResult GetAllActiveCategories()
        {
            try
            {
                var categories = _categoryService.GetAllActiveCategory();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // Log the exception details
                // TODO: Replace with proper logging
                Console.WriteLine($"Error in GetAllCategories: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
