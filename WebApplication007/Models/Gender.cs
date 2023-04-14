using System;
using System.Collections.Generic;

namespace WebApplication007.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; } = new List<AppUser>();
}
