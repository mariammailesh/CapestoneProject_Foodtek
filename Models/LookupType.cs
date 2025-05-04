using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class LookupType
{
    public int TypeId { get; set; }

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<LookupItem> LookupItems { get; set; } = new List<LookupItem>();
}
