using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication007.DAL;

namespace WebApplication007.Models
{
	public class AppUsersCreateVM
    {
		public int Id { get; set; }

		[Required]
		[Remote(action: "IsEmailValid", controller:"AppUsers")]
		public string? Email { get; set; }

		[Required]
		[StringLength(10, MinimumLength = 5)]
		public String? Password { get; set; }

		[Compare ("Password",ErrorMessage ="Password Cannot Match")]
        public String? ConfirmPassword { get; set; }


        [Required]
		[Display(Name = "First Name")]
		public string? FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string? LastName { get; set; }



		public int? MobileNo { get; set; }

		public int? GenderId { get; set; }

		public virtual Gender? Gender { get; set; }


	}
}
