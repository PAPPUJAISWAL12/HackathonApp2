﻿using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class Fee
{
    public int FeeId { get; set; }

    public int StdId { get; set; }

    public decimal MonthlyFeeAmt { get; set; }

    public decimal YearlyAmt { get; set; }

    public decimal YearlyDiscount { get; set; }

    public decimal Examfee { get; set; }

    public string FiscalYear { get; set; } = null!;

    public int? EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public string EntryTime { get; set; } = null!;

    public DateTime CancelledDate { get; set; }

    public int? CancelledBy { get; set; }

    public string ResonForCancelled { get; set; } = null!;

    public virtual User? CancelledByNavigation { get; set; }

    public virtual User? EntryByNavigation { get; set; }

    public virtual ICollection<FeeDetail> FeeDetails { get; } = new List<FeeDetail>();

    public virtual Student Std { get; set; } = null!;
}
