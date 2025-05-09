using CapestoneProject.DTOs.Cart.Response;
using CapestoneProject.DTOs.OrderHistory.Rseponse;

namespace CapestoneProject.Interfaces
{
    public interface IOrderHistoryServices
    {
        Task<List<OrderHistoryOutputDTO>> GetOrderHistoryByUserIdAsync(int userId);
    }
}
