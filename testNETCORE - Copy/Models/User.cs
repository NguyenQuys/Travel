using System;
using System.Collections.Generic;

namespace testNETCORE.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public bool Gender { get; set; }

    public decimal PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public bool Permission { get; set; }

    public bool Hide { get; set; }
}
