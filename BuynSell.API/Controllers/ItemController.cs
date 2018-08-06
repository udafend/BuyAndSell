using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuynSell.DataAccess.Manager;
using BuynSell.DataAccess.Model;

namespace BuynSell.API.Controllers
{
	[RoutePrefix("api/Item")]
	public class ItemController : BaseController
	{
		private readonly ItemManager _itemManager = new ItemManager();

		/// <summary>
		/// add new item
		/// </summary>
		/// <param name="item">The item to be added to the database</param>
		/// <returns> return if Success OK, if not Bad or Exception message</returns>
		[HttpPost]
		[Route("New")]
		public string New(Item item)
		{
			string result;
			try
			{
				if (ModelState.IsValid)
				{
					result = _itemManager.New(item);
				}
				else
				{
					return HttpStatusCode.BadRequest.ToString(ModelState.ToString());
				}

			}
			catch (Exception ex)
			{
				return (ex.Message);

			}

			return result;
		}


		/// <summary>
		/// <summary>
		/// retrive items of particular client
		/// </summary>
		/// <param name="clientID">this is the client's ID</param>
		/// <returns> return item list</returns>
		[HttpGet]
		[Route("List")]
		public IQueryable<Item> List(string clientID)
		{
			if (string.IsNullOrEmpty(clientID))
			{
				return null;
			}
			else
			{
				return _itemManager.GetItemByClient(Guid.Parse(clientID));
			}


		}

		/// <summary>
		/// Mark a item as unpublish or sold 
		/// </summary>
		/// <param name="itemID">this is the ID of item</param>
		/// <returns>return if Success OK, if not Exception message</returns>
		[HttpGet]
		[Route("Unpublished")]
		public string Unpublished(string itemID)
		{
			if (string.IsNullOrEmpty(itemID))
			{
				return "Item ID can not be null or empty";
			}
			else
			{
				return _itemManager.UnpublishedItem(Guid.Parse(itemID));
			}

		}

		/// <summary>
		/// Extend the expiry date for a week 
		/// </summary>
		/// <param name="itemID">this is the ID of Item</param>
		/// <returns>return if Success OK, if not Exception message</returns>
		[HttpGet]
		[Route("Extend")]
		public string ExtendExpiryDate(string itemID)
		{
			if (string.IsNullOrEmpty(itemID))
			{
				return "Item ID can not be null or empty";
			}
			else
			{
				return _itemManager.ExtendExpiryDate(Guid.Parse(itemID));
			}

		}

	}
}
