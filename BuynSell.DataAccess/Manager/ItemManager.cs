using BuynSell.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuynSell.DataAccess.Manager
{
	public class ItemManager : BaseManager
	{
		/// <summary>
		/// add new item
		/// </summary>
		/// <param name="item">The item to be added to the database</param>
		/// <returns> return if Success OK, if not Bad or Exception message</returns>
		public string New(Item item)
		{
			try
			{
				item.ItemID = Guid.NewGuid();
				item.PostedDate = DateTime.Now;
				item.ExpiryDate = MakeExpiryDate(item.PostedDate);

				_context.Items.Add(item);
				_context.SaveChanges();
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
						
			return "OK";
		}


		/// <summary>
		/// define expiry date according to the posted date
		/// </summary>
		/// <param name="postedDate">this is the date of item posted</param>
		/// <returns>return expiry date</returns>
		public DateTime MakeExpiryDate(DateTime postedDate)
		{
		return postedDate.AddDays(7);
		}

		/// <summary>
		/// retrive items of particular client
		/// </summary>
		/// <param name="clientID">this is the client's ID</param>
		/// <returns>return item list</returns>
		public IQueryable<Item> GetItemByClient(Guid clientID)
		{
			return _context.Items.Where(x => x.ExpiryDate > DateTime.Now && x.ClientID.Equals(clientID));
		}

		/// <summary>
		/// Mark a item as unpublish or sold 
		/// </summary>
		/// <param name="itemID">this is the ID of item</param>
		/// <returns>return if Success OK, if not Exception message</returns>
		public string UnpublishedItem(Guid itemID)
		{
			try
			{
				var item = _context.Items.Where(x => x.ItemID.Equals(itemID)).First();
				item.IsSold = 1;

				_context.Items.Attach(item);
				_context.Entry(item).Property(x => x.IsSold).IsModified = true;
				_context.SaveChanges();
			
			}
			catch (Exception ex)
			{
				return ex.Message;
			}	

			return "OK";
		}


		/// <summary>
		/// Extend the expiry date for a week 
		/// </summary>
		/// <param name="itemID">this is the ID of Item</param>
		/// <returns>return if Success OK, if not Exception message</returns>
		public string ExtendExpiryDate(Guid itemID)
		{
			try
			{
				var item = _context.Items.Where(x => x.ItemID.Equals(itemID)).First();
			    item.ExpiryDate =item.ExpiryDate.AddDays(7);

				_context.Items.Attach(item);
				_context.Entry(item).Property(x => x.ExpiryDate).IsModified = true;
				_context.SaveChanges();
				
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return "OK";
		}


	}
}
