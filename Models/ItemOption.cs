using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class ItemOption
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int OptionId { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Option Option { get; set; } = null!;
}
