using System;
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

    public string FiscalYear { get; set; } 

    public int? EntryBy { get; set; }

   

    public DateTime CancelledDate { get; set; }

    public int? CancelledBy { get; set; }

    public string ResonForCancelled { get; set; } 

  
}
