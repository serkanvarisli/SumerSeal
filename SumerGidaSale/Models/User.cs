﻿using System;
using System.Collections.Generic;

namespace SumerGidaSale.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
