using System;
using System.Collections.Generic;

namespace CapestoneProject.Models;

public partial class UserIssuesSuggestion
{
    public int UserId { get; set; }

    public int IssueSuggestionId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual IssuesSuggestion IssueSuggestion { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
