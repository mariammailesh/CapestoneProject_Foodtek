using CapestoneProject.DTOs.Cart.Response;
using CapestoneProject.DTOs.OrderHistory.Rseponse;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Services
{
    public class OrderHistoryServices : IOrderHistoryServices
    {
        private readonly ESingleRestaurantManagementSystemContext _context;
        public OrderHistoryServices(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<List<OrderHistoryOutputDTO>> GetOrderHistoryByUserIdAsync(int userId)
        {
            var orderHistory = await _context.OrdersHistories.Where(h => h.ClientId == userId)
                .Include(h => h.Order).ThenInclude(o => o.DeliveryLocations)
                .Select(h => new OrderHistoryOutputDTO
            {
                Id = h.OrderId,
                Date = Convert.ToDateTime(h.Order.CreatedAt),
                TotalPrice = Convert.ToDecimal(h.Order.TotalPrice),
                Region = h.Order.DeliveryLocations.Region,
                Longitude = Convert.ToDouble(h.Order.DeliveryLocations.Longitude),
                Latitude = Convert.ToDouble(h.Order.DeliveryLocations.Latitude)
            }).ToListAsync();   
            return orderHistory;    
        }
    }
}
