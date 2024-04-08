using System;
using System.Collections.Generic;

namespace Ckeditor.Models;

public partial class PostCkeditor
{
    public int Id { get; set; }

    public string PostTitle { get; set; } = null!;

    public string PostContent { get; set; } = null!;
}
