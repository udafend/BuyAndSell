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
	[RoutePrefix("api/Client")]
	public class ClientController : BaseController
    {
		private readonly ClientManager _clientManager = new ClientManager();

		/// <summary>
		/// add new client
		/// </summary>
		/// <param name="client">The item to be added to the database</param>
		/// <returns> return if Success OK, if not Bad or Exception message</returns>
		[HttpPost]
		[Route("New")]
		public string New(Client client)
		{
			string result;
			try
			{
				if (ModelState.IsValid)
				{
					result = _clientManager.New(client);
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
		/// retrive all clients
		/// </summary>
		/// <returns> return client list</returns>
		[HttpGet]
		[Route("List")]
		public IQueryable<Client> List()
		{
			return _clientManager.GetClients();
		}
	}
}
