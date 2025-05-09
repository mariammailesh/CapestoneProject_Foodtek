using CapestoneProject.DTOs.Item.Response;
using CapestoneProject.Interfaces;
using CapestoneProject.Services;
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

        /// <summary>
        /// Retrieves the top rated items across all categories
        /// </summary>
        /// <returns>A list of top rated items</returns>
        /// <response code="200">Returns the list of top rated items</response>
        /// <response code="404">If no items are found</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ItemOutputDTO>>> GetTopRatedItems()
        {
            try
            {
                var items = await _itemServices.GetTopRatedItems();
                if (items == null || !items.Any())
                {
                    return NotFound();
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while retrieving top-rated items");
            }
        }
        /// <summary>
        /// Retrieves the top recommended items across all categories
        /// </summary>
        /// <returns>A list of top recommended items</returns>
        /// <response code="200">Returns the list of top recommended items</response>
        /// <response code="404">If no items are found</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ItemOutputDTO>>> GetTopRecommendedItems()
        {
            try
            {
                var items = await _itemServices.GetTopRecommendedItems();
                if (items == null || !items.Any())
                {
                    return NotFound();
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while retrieving top recommended items");
            }
        }

        // Hebah-Afaneh-Dev 
        /// <summary>
        /// Retrieves all item details belonging to a specific id
        /// </summary>
        /// <param name="itemId">The ID to get item details for</param>
        /// <returns>An item details in the specified Id</returns>
        /// <response code="200">Returns the item details based on the Id</response>
        /// <response code="404">If no item is found based on the Id</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetItemDetails(int id)
        {
            try
            {
                var itemDetails = await _itemServices.GetItemDetailsByIdAsync(id);
                if (itemDetails == null)
                    return NotFound("Item Not Found.");

                return Ok(itemDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
