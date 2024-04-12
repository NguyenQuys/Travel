using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class SearchHistory
{
    public int IdSearch { get; set; }

    public int IdUser { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? SearchDate { get; set; }

    public int Order { get; set; }

    public bool Hide { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
