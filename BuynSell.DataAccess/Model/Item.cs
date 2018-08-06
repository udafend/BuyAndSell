using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuynSell.DataAccess.Model
{
	public class Item
	{
		public Guid ItemID { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
		[Display(Name = "Description")]
		public string Description { get; set; }
		public byte[] Image { get; set; }
		public DateTime PostedDate { get; set; }
		public DateTime ExpiryDate { get; set; }

		[ForeignKey("Client")]
		[Required]
		public Guid ClientID { get; set; }

		public Client Client { get; set; }

		public int IsSold { get; set; }
	}
}
