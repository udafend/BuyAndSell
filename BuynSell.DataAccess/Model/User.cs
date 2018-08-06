using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuynSell.DataAccess.Model
{
    public abstract class User
	{
		public Guid ID { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[StringLength(50)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
