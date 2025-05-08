using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public int CategoryId { get; set; }

    public string NameAr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? DescriptionAr { get; set; }

    public string? DescriptionEn { get; set; }

    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<DiscountItem> DiscountItems { get; set; } = new List<DiscountItem>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>(); 

    public virtual ICollection<ItemOption> ItemOptions { get; set; } = new List<ItemOption>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
