using CapestoneProject.DTOs.Favorite.Request;
using CapestoneProject.DTOs.Favorite.Response;
using CapestoneProject.DTOs.Request;

namespace CapestoneProject.Interfaces
{
    public interface ICartServices
    {
        Task<string> ClearCart(int cartId);
        Task<string> CreateCart(int personId);
        Task<string> AddUpdateCart(CartItemInputDTO itemDTO);
        Task<string> RemoveFromCart(int CartitemId);
    }
}
