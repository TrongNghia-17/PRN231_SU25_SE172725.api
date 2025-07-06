﻿using System;
using System.Collections.Generic;

namespace SE172725.Repositories.Models;

public partial class SystemAccount
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Role { get; set; }

    public bool? IsActive { get; set; }
}
