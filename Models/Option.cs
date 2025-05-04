using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Option
{
    public int OptionId { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? OptionType { get; set; }

    public bool? IsRequired { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<ItemOption> ItemOptions { get; set; } = new List<ItemOption>();
}
