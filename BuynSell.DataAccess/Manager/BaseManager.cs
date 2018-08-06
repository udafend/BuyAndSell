using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BuynSell.DataAccess.Model;

namespace BuynSell.DataAccess.Manager
{
	public class BaseManager
	{
		public readonly BuyNSellContext _context = new BuyNSellContext();
	}
}
