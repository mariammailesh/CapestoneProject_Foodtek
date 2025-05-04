using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class DiscountItem
{
    public int Id { get; set; }

    public int? DiscountId { get; set; }

    public int? ItemId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual Item? Item { get; set; }
}
