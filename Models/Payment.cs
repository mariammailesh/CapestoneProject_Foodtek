using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public int ClientId { get; set; }

    public int? PaymentMethod { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaidAt { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual Order? Order { get; set; }

    public virtual LookupItem? PaymentMethodNavigation { get; set; }
}
