using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public bool Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Permission { get; set; }

    public string Password { get; set; } = null!;

    public bool Hide { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();

    public virtual ICollection<Statistical> Statisticals { get; set; } = new List<Statistical>();
}
