using System;
using System.Collections.Generic;

namespace nhom8_TourDuLich.Models;

public partial class InformationCustomer
{
    public string IdCustomer { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public bool Gender { get; set; }

    public decimal PhoneNumber { get; set; }

    public string Email { get; set; } = null!;
}
