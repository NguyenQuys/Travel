using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class Like
{
    public int IdUser { get; set; }

    public string TourId { get; set; } = null!;

    public string? Time { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual Tour Tour { get; set; } = null!;
}
