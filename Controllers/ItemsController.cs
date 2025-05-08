using CapestoneProject.DTOs.Item.Response;
using CapestoneProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _itemServices;

        public ItemsController(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        /// <summary>
        /// Retrieves all items belonging to a specific category
        /// </summary>
        /// <param name="categoryId">The ID of the category to get items for</param>
        /// <returns>A list of items in the specified category</returns>
        /// <response code="200">Returns the list of items in the category</response>
        /// <response code="404">If no items are found in the category</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("category/{categoryId}")]
        
        public async Task<ActionResult<IEnumerable<ItemOutputDTO>>> GetItemsByCategoryId(int categoryId)
        {
            try
            {
                var items = await _itemServices.GetItemsByCategoryId(categoryId);
                if (items == null || !items.Any())
                {
                    return NotFound();
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while retrieving items for the specified category");
            }
        }
    }
}
