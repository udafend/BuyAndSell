using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuynSell.DataAccess.Model
{
	public class Client : User
	{
		public string Address { get; set; }
		public ICollection<Item> Items { get; set; }
	}
}
