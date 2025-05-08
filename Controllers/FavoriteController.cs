using CapestoneProject.DTOs.Favorite.Request;
using CapestoneProject.Interfaces;
using CapestoneProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteServices _favoriteServices;
        public FavoriteController(IFavoriteServices favoriteServices)
        {
            _favoriteServices = favoriteServices;
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFavoritesByUserId(int userId)
        {
            try
            {
                var items = await _favoriteServices.GetFavoriteItemByUserIdAsync(userId);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToFavorite([FromBody] FavoriteItemInputDTO dto)
        {
            try
            {
                var result = await _favoriteServices.AddItemToFavoriteAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromFavorite(FavoriteItemInputDTO dto)
        {
            try
            {
                var result = await _favoriteServices.DeleteItemFromFavoriteAsync(dto);
                return Ok(result);
            }
            catch (Exception es)
            {
                return BadRequest(es.Message);
            }
        }
    }
}
