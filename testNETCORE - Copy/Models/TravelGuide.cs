using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class TravelGuide
{
    public string IdTravelGuide { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string CoverImage { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int Order { get; set; }

    public string Link { get; set; } = null!;

    public bool Hide { get; set; }
}
