using System;
using System.Collections.Generic;

namespace SumerGidaSale.Models;

public partial class Sale
{
    public int? Id { get; set; }

    public string CustomerCode { get; set; }

    public string CustomerTitle { get; set; }

    public string Province { get; set; } 

    public string District { get; set; }

    public string SaleQuentity { get; set; } 
}
