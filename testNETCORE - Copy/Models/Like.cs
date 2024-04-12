using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class Like
{
    public int IdCart { get; set; }

    public int IdUser { get; set; }

    public string IdTour { get; set; } = null!;

    public virtual Tour IdTourNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
