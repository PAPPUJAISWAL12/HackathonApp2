using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class Subject
{
    public int SubId { get; set; }

    public string SubName { get; set; } = null!;

    public int Cid { get; set; }

    public virtual Class CidNavigation { get; set; } = null!;
}
