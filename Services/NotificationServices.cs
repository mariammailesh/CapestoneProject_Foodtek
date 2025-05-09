using CapestoneProject.DTOs.Notification.Request;
using CapestoneProject.DTOs.Notification.Response;
using CapestoneProject.Helpers;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Services
{
    public class NotificationServices : INotificationServices
    {
        private readonly ESingleRestaurantManagementSystemContext _context;

        public NotificationServices(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<List<NotificationOutputDTO>> GetAllNotificationByIdAsync(int userId)
        {
            var notification = await (from un in _context.UserNotifications
                                      join n in _context.Notifications on un.NotificationId equals n.Id
                                      where un.UserId == userId
                                      select new NotificationOutputDTO
                                      {
                                          Id = n.Id,
                                          Title = n.Title,
                                          Content = n.Message,
                                          Date = n.CreatedAt ?? DateTime.MinValue,
                                          IsRead = Convert.ToBoolean(un.IsRead)
                                      }).ToListAsync();
            return notification;
        }
    }
}
