using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class Discount
{
    public int IdDiscount { get; set; }

    public string Code { get; set; } = null!;

    public double Percentage { get; set; }
}
