using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class OrdersHistory
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
