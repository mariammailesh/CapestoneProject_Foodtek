using CapestoneProject.Interfaces;
using CapestoneProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        /// <summary>
        /// Retrieves all cart items list belonging to a specific userId
        /// </summary>
        /// <param name="userId">The ID to get cart item details for userId</param>
        /// <returns>A cart item list based on the specified userId</returns>
        /// <response code="200">Returns the cart items list based on the Id</response>
        /// <response code="404">If no item in cart is found based on the Id</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("user-cart/{userId}")]
        public async Task<IActionResult> GetCartByUserId(int userId)
        {
            try
            {
                var cart = await _cartServices.GetCartByUserIdAsync(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
