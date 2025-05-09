using CapestoneProject.DTOs.Favorite.Request;
using CapestoneProject.DTOs.Favorite.Response;
using CapestoneProject.DTOs.Notification.Request;
using CapestoneProject.DTOs.Notification.Response;

namespace CapestoneProject.Interfaces
{
    public interface INotificationServices
    {
        Task<NotificationOutputDTO> GetNotificationByIdAsync(int id);
        Task<IEnumerable<NotificationOutputDTO>> GetAllNotificationsAsync();

    }
}
