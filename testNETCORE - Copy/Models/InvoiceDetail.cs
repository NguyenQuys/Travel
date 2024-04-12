using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class InvoiceDetail
{
    public string IdInvoice { get; set; } = null!;

    public string IdTour { get; set; } = null!;

    public int IdUser { get; set; }

    public DateTime? StaticsticDate { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public int? QuantityAdult { get; set; }

    public int? QuantityChildren { get; set; }

    public DateOnly? StarDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual Tour IdTourNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual Statistical? StaticsticDateNavigation { get; set; }
}
