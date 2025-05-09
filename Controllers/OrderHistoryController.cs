using CapestoneProject.Interfaces;
using CapestoneProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryServices _orderHistoryServices;
        public OrderHistoryController(IOrderHistoryServices orderHistoryServices)
        {
            _orderHistoryServices = orderHistoryServices;
        }
        /// <summary>
        /// Retrieves all orders belonging to a user id
        /// </summary>
        /// <param name="userId">The ID to get order history for one user</param>
        /// <returns>A history list contains all previous orders related to one user Id</returns>
        /// <response code="200">Returns the order history list based on the userId</response>
        /// <response code="404">If no order history are found based on the userId</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("user-order-history/{userId}")]
        public async Task<IActionResult> GetOrderHistoryByUserIdAsync(int userId)
        {
            try
            {
                var history = await _orderHistoryServices.GetOrderHistoryByUserIdAsync(userId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
