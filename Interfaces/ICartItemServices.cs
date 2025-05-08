using CapestoneProject.DTOs.Request;

namespace CapestoneProject.Interfaces
{
    public interface ICartItemServices
    {
        Task<string> AddOrUpdateItemAsync(CartItemInputDTO itemDTO);
        Task<string> RemoveItemAsync(int cartItemId);
        Task<string> RemoveOnePieceAsync(int userId, int itemId);
    }
}
