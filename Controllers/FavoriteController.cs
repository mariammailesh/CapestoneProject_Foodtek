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
        /// <summary>
        /// Retrieves favorite items belonging to a specific userId
        /// </summary>
        /// <param name="userId">The ID to get all favorite items for userId</param>
        /// <returns>A list of favorites based on the specified userId</returns>
        /// <response code="200">Returns the favorites list based on the Id</response>
        /// <response code="404">If no favorite is found based on the Id</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("user-favorites/{userId}")]
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

        [HttpPost("[action]")]
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

        [HttpDelete("[action]")]
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
