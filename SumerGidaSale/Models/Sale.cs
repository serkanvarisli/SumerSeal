using System;
using System.Collections.Generic;

namespace SumerGidaSale.Models;

public partial class Sale
{
    public int Id { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string CustomerTitle { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string District { get; set; } = null!;

    public int SaleQuentity { get; set; }
}
