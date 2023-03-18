﻿using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public string Upassword { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public bool? LoginStatus { get; set; }

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual ICollection<Fee> FeeCancelledByNavigations { get; } = new List<Fee>();

    public virtual ICollection<Fee> FeeEntryByNavigations { get; } = new List<Fee>();

    public virtual ICollection<FeePrint> FeePrints { get; } = new List<FeePrint>();

    public virtual ICollection<ProgramInfo> ProgramInfoCancelleds { get; } = new List<ProgramInfo>();

    public virtual ICollection<ProgramInfo> ProgramInfoUsers { get; } = new List<ProgramInfo>();

    public virtual ICollection<Reception> ReceptionCancelledBies { get; } = new List<Reception>();

    public virtual ICollection<Reception> ReceptionUsers { get; } = new List<Reception>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
