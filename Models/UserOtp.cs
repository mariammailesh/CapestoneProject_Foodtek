using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class UserOtp
{
    public int UserOtpId { get; set; }

    public int? UserId { get; set; }

    public string Email { get; set; } = null!;

    public string? Otpcode { get; set; } = null!;

    public DateTime? ExpirationTime { get; set; }

    public bool? IsUsed { get; set; }

    public int? TryCount { get; set; }

    public string? Purpose { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual User? User { get; set; }
}
