using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class LookupItem
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string ValueEn { get; set; } = null!;

    public string? ValueAr { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<IssuesSuggestion> IssuesSuggestions { get; set; } = new List<IssuesSuggestion>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual LookupType Type { get; set; } = null!;
}
