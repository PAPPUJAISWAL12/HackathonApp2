using System;
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

	public bool RememberMe { get; set; }

	public string? ReturnUrl { get; set; }
}
