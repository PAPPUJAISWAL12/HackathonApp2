﻿using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class ReceptionView
{
    public int Rid { get; set; }

    public string PersonName { get; set; } = null!;

    public DateTime EntryDate { get; set; }

    public string EntryTime { get; set; } = null!;

    public string Purpose { get; set; } = null!;

    public string PersonAddress { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int UserId { get; set; }

    public string? EntryBy { get; set; }

    public DateTime CancelledDate { get; set; }

    public int CancelledById { get; set; }

    public string? CancelledBy { get; set; }

    public string FiscalYear { get; set; } = null!;

    public string? ReceptionStatus { get; set; }
}
