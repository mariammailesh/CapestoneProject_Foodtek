using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ItemId { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? ItemPrice { get; set; }

    public int? Quantity { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Order? Order { get; set; }
}
