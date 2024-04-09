using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }
}
