using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class FeeDetail
{
    public int DetailId { get; set; }

    public int FeeId { get; set; }

    public decimal TotalAmt { get; set; }

    public decimal PaidAmt { get; set; }

    public decimal RemainingAmt { get; set; }

    public string FeeStatus { get; set; } 

    public virtual Fee Fee { get; set; } 
    public virtual ICollection<FeePrint> FeePrints { get; } = new List<FeePrint>();
}
