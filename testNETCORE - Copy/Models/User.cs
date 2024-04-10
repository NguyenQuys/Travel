using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public bool Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte Permission { get; set; }

    public bool Hide { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
