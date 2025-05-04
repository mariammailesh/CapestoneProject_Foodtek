using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public int? DriverId { get; set; }

    public int? DiscountId { get; set; }

    public int? OrderStatus { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual User Client { get; set; } = null!;

    public virtual ICollection<DeliveryLocation> DeliveryLocations { get; set; } = new List<DeliveryLocation>();

    public virtual Discount? Discount { get; set; }

    public virtual User? Driver { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual LookupItem? OrderStatusNavigation { get; set; }

    public virtual ICollection<OrdersHistory> OrdersHistories { get; set; } = new List<OrdersHistory>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
