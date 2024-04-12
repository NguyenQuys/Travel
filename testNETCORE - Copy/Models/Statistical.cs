using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class Statistical
{
    public DateTime CreatedDate { get; set; }

    public int IdUser { get; set; }

    public int DomesticTours { get; set; }

    public int OverseasTour { get; set; }

    public int CustomersNumber { get; set; }

    public string TotalPrice { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
