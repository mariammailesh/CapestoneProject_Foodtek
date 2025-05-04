using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Report
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ItemId { get; set; }

    public int? OrderId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
