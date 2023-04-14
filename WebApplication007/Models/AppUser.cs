using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication007.Models;

public partial class AppUser
{
    public int Id { get; set; }

    [Required]
    public string? Email { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }

    [Required]
    
    public int? MobileNo { get; set; }
    [Required]
    public int? GenderId { get; set; }

    public virtual Gender? Gender { get; set; }
}
