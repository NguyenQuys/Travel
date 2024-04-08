using System;
using System.Collections.Generic;

namespace Ckeditor.Models;

public partial class CamNangDuLich
{
    public string TravelGuideId { get; set; } = null!;

    public string TravelGuideTitleTitle { get; set; } = null!;

    public string CoverImage { get; set; } = null!;

    public string Link { get; set; } = null!;

    public bool Hide { get; set; }
}
