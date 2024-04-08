using System;
using System.Collections.Generic;

namespace Ckeditor.Models;

public partial class NavigationBar
{
    public int? IdMenu { get; set; }

    public string Title { get; set; } = null!;

    public int Order { get; set; }

    public string Link { get; set; } = null!;

    public bool? Active { get; set; }

    public bool Hide { get; set; }
}
