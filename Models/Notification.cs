using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public int? NotificationType { get; set; }

    public bool? IsRead { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual LookupItem? NotificationTypeNavigation { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}
