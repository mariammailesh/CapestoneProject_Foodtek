using CapestoneProject.DTOs.Favorite.Request;
using CapestoneProject.DTOs.Favorite.Response;
using CapestoneProject.DTOs.Item.Request;
using CapestoneProject.DTOs.Item.Response;

namespace CapestoneProject.Interfaces
{
    public interface IFavoriteServices
    {
        Task<IEnumerable<FavoriteItemOutputDTO>> GetFavoriteItemByUserIdAsync(int UserId);
        Task<FavoriteItemOutputDTO> GetFavoriteItemByIdAsync(int itemId);
        Task<string> AddItemToFavoriteAsync(FavoriteItemInputDTO FavoriteItem);
        Task<string> DeleteItemFromFavoriteAsync(FavoriteItemInputDTO input);
        Task<string> DeleteFavoriteAsync(int UserId);
    }
}
