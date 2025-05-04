using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public int? CartStatus { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual LookupItem? CartStatusNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
