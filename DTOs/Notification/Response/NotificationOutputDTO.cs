namespace CapestoneProject.DTOs.Notification.Response
{
    public class NotificationOutputDTO
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }

    }
}
