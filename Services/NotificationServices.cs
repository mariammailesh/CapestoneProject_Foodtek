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
        public async Task<int> CreateNotificationAsync(NotificationInputDTO input)
        {
            var isValidType = await _context.LookupItems
                    .AnyAsync(li => li.TypeId == (int)LookupTypes.NotificationType && li.Id == input.NotificationTypeId);

            if (!isValidType)
                throw new ArgumentException("Invalid Notification Type.");

            var notification = new Notification
            {
                Title = input.Title,
                Message = input.Message,
                NotificationType = input.NotificationTypeId,
                IsActive = input.IsActive,
                CreatedBy = input.CreatedBy,
                CreatedAt = DateTime.Now
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return notification.Id;
        }

        public Task DeleteNotificationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotificationOutputDTO>> GetAllNotificationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<NotificationOutputDTO> GetNotificationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNotificationAsync(int id, NotificationInputDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
