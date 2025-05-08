using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapestoneProject.Interfaces;
using CapestoneProject.DTOs.Discount.Response;

namespace CapestoneProject.Controllers
{
    /// <summary>
    /// Controller for managing discount-related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountServices _discountService;

        /// <summary>
        /// Initializes a new instance of the DiscountController
        /// </summary>
        /// <param name="discountService">The discount service implementation</param>
        public DiscountController(IDiscountServices discountService)
        {
            _discountService = discountService;
        }

        /// <summary>
        /// Retrieves all available discounts
        /// </summary>
        /// <returns>A list of all discounts</returns>
        /// <response code="200">Returns the list of discounts</response>
        /// <response code="404">If no discounts are found</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("[action]")]
       
        public async Task<IActionResult> GetAllDiscounts()
        {
            try
            {
                var discounts = await _discountService.GetAllDiscountsAsync();
                if (discounts == null)
                {
                    return NotFound("No discounts found");
                }
                return Ok(discounts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
