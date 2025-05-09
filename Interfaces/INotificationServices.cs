using CapestoneProject.DTOs.Favorite.Request;
using CapestoneProject.DTOs.Favorite.Response;
using CapestoneProject.DTOs.Notification.Response;

namespace CapestoneProject.Interfaces
{
    public interface INotificationServices
    {
        Task<List<NotificationOutputDTO>> GetAllNotificationByIdAsync(int userId);
    }
}
