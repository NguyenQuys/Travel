using System;
using System.Collections.Generic;

namespace nhom8_TourDuLich.Models;

public partial class LichSuTimKiem
{
    public string Destination { get; set; } = null!;

    public DateOnly CheckInDay { get; set; }

    public DateOnly CheckOutDau { get; set; }
}
