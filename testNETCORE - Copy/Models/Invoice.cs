using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class Invoice
{
    public string IdOrder { get; set; } = null!;

    public int IdUser { get; set; }

    public string IdTour { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime Time { get; set; }

    public virtual Tour IdTourNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
