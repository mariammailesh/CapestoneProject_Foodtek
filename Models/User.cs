using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? ProfileImage { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsVerified { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<Chat> ChatClients { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatDrivers { get; set; } = new List<Chat>();

    public virtual ICollection<DeliveryLocation> DeliveryLocations { get; set; } = new List<DeliveryLocation>();

    public virtual ICollection<IssuesSuggestion> IssuesSuggestions { get; set; } = new List<IssuesSuggestion>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Order> OrderClients { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderDrivers { get; set; } = new List<Order>();

    public virtual ICollection<OrdersHistory> OrdersHistories { get; set; } = new List<OrdersHistory>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rating> RatingClients { get; set; } = new List<Rating>();

    public virtual ICollection<Rating> RatingDrivers { get; set; } = new List<Rating>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserIssuesSuggestion> UserIssuesSuggestions { get; set; } = new List<UserIssuesSuggestion>();

    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();

    public virtual ICollection<UserOtp> UserOtps { get; set; } = new List<UserOtp>();
}
