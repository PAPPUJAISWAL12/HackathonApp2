using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class Document
{
    public int DocId { get; set; }

    public int UploadId { get; set; }

    public int UserId { get; set; }

    public virtual Upload Upload { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
