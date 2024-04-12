using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class Category
{
    public int Idcategory { get; set; }

    public string CategoryName { get; set; } = null!;

    public int Order { get; set; }

    public string Link { get; set; } = null!;

    public bool Hide { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
