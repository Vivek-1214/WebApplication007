using System;
using System.Collections.Generic;

namespace WebApplication007.DAL;

public partial class AppUser
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? MobileNo { get; set; }

    public int? GenderId { get; set; }

    public string? Password { get; set; }

    public int? AdharNo { get; set; }

    public virtual Gender? Gender { get; set; }
}
