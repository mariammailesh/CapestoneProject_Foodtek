using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class DeliveryLocation
{
    public int LocationId { get; set; }

    public int? OrderId { get; set; }

    public int ClientId { get; set; }

    public string DeliveryStatus { get; set; } = null!;

    public DateTime DeliveryTime { get; set; }

    public string? Title { get; set; }

    public string? Region { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual Order? Order { get; set; }
}
