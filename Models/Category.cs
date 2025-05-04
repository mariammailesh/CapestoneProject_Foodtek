using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryNameAr { get; set; } = null!;

    public string CategoryNameEn { get; set; } = null!;

    public string? Image { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<DiscountCategory> DiscountCategories { get; set; } = new List<DiscountCategory>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
