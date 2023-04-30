using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class ProgramInfo
{
    public virtual User? Cancelled { get; set; }

    public virtual User User { get; set; } = null!;
}
public partial class ProgramInfoEdit
{
    public int Pid { get; set; }

    public string Pname { get; set; } = null!;

    public string Pdescription { get; set; } = null!;

    public string Venue { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public string StartTime { get; set; } = null!;

    public DateTime EndDate { get; set; }

    public string EndTime { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime EntryDate { get; set; }

    public int? CancelledId { get; set; }

    public DateTime? CancelledDate { get; set; }

    public string? ReasonForCancell { get; set; }
}
