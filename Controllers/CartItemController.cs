using CapestoneProject.DTOs.Request;
using CapestoneProject.Interfaces;
using CapestoneProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemServices _cartItemServices;
        public CartItemController(ICartItemServices cartItemServices)
        {
            _cartItemServices = cartItemServices;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrUpdateItem([FromBody] CartItemInputDTO itemDTO)
        {
            try
            {
                var result = await _cartItemServices.AddOrUpdateItemAsync(itemDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("remove-item/{cartItemId}")]
        public async Task<IActionResult> RemoveItem(int cartItemId)
        {
            try
            {
                var result = await _cartItemServices.RemoveItemAsync(cartItemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> RemoveOnePiece(int userId, int itemId)
        {
            try
            {
                var result = await _cartItemServices.RemoveOnePieceAsync(userId, itemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
