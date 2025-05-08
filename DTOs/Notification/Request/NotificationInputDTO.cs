namespace CapestoneProject.DTOs.Notification.Request
{
    public class NotificationInputDTO
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int NotificationTypeId { get; set; } // Related to lookup type
        public bool IsActive { get; set; } = true;
        public string CreatedBy { get; set; } // "Admin" or "System"
    }
}
