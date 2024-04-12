using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class Tour
{
    public string IdTour { get; set; } = null!;

    public int IdCategory { get; set; }

    public string TourName { get; set; } = null!;

    public string Destination1 { get; set; } = null!;

    public string Destination2 { get; set; } = null!;

    public string Destination3 { get; set; } = null!;

    public string Image1 { get; set; } = null!;

    public string Image2 { get; set; } = null!;

    public string Image3 { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public double PriceOfAdult { get; set; }

    public double PriceOfChildren { get; set; }

    public string NdaysNnights { get; set; } = null!;

    public string JourneyHightlight { get; set; } = null!;

    public string TravelingSchedule { get; set; } = null!;

    public string Descripsion { get; set; } = null!;

    public string Link { get; set; } = null!;

    public bool Hide { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
