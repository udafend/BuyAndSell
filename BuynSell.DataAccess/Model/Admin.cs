using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuynSell.DataAccess.Model
{
	public class Admin : User
	{
		[Required]
		public string EmployeeNumber { get; set; }
	}
}
