using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class Chat
{
    public int ChatId { get; set; }

    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public int DriverId { get; set; }

    public string ChatFilePath { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual User Driver { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
