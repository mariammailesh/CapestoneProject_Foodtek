using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string? TitleEn { get; set; }

    public string? TitleAr { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? LimitAmount { get; set; }

    public int? Code { get; set; }

    public int? DiscountStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<DiscountCategory> DiscountCategories { get; set; } = new List<DiscountCategory>();

    public virtual ICollection<DiscountItem> DiscountItems { get; set; } = new List<DiscountItem>();

    public virtual LookupItem? DiscountStatusNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
