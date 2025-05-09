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

        public Task<IEnumerable<NotificationOutputDTO>> GetAllNotificationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<NotificationOutputDTO> GetNotificationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
