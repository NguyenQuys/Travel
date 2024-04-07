using System;
using System.Collections.Generic;

namespace nhom8_TourDuLich.Models;

public partial class Tour
{
    public string TourId { get; set; } = null!;

    public string TourName { get; set; } = null!;

    public string Departure { get; set; } = null!;

    public byte Idcategory { get; set; }

    public string Destination1 { get; set; } = null!;

    public string Destination2 { get; set; } = null!;

    public string Destination3 { get; set; } = null!;

    public string Image1 { get; set; } = null!;

    public string Image2 { get; set; } = null!;

    public string Image3 { get; set; } = null!;

    public decimal PriceForAdult { get; set; }

    public decimal PriceForChildren { get; set; }

    public int MaxQuantity { get; set; }

    public int Length { get; set; }

    public string NdaysNnights { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string JourneyHightlight { get; set; } = null!;

    public string TravelingSchedule { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Link { get; set; } = null!;

    public bool Hide { get; set; }

    public bool Like { get; set; }
}
