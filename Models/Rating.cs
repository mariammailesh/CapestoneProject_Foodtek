using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int? OrderId { get; set; }

    public int DriverId { get; set; }

    public double? RatingAmount { get; set; }

    public string? Feedback { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int ItemId { get; set; }  // maps to Item_Id in DB

    public virtual Item Item { get; set; }  // navigation property


    public virtual User Client { get; set; } = null!;

    public virtual User Driver { get; set; } = null!;

    public virtual Order? Order { get; set; }
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

}
