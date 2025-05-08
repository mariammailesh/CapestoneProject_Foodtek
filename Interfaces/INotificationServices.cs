using CapestoneProject.DTOs.Favorite.Request;
using CapestoneProject.DTOs.Favorite.Response;
using CapestoneProject.DTOs.Notification.Request;
using CapestoneProject.DTOs.Notification.Response;

namespace CapestoneProject.Interfaces
{
    public interface INotificationServices
    {
        Task<int> CreateNotificationAsync(NotificationInputDTO input);
        Task UpdateNotificationAsync(int id, NotificationInputDTO input);
        Task DeleteNotificationAsync(int id);
        Task<NotificationOutputDTO> GetNotificationByIdAsync(int id);
        Task<IEnumerable<NotificationOutputDTO>> GetAllNotificationsAsync();

    }
}
