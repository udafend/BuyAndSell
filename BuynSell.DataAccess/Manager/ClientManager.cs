using BuynSell.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuynSell.DataAccess.Manager
{
	public class ClientManager : BaseManager 
	{
		/// <summary>
		/// add new client 
		/// </summary>
		/// <param name="client">The client to be added to the database</param>
		/// <returns> return if Success OK, if not Bad or Exception message </returns>
		public string New(Client client)
		{
			try
			{
				client.ID = Guid.NewGuid();

				_context.Users.Add(client);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
			
			return "OK";
		}

		/// <summary>
		/// retrive all clients 
		/// </summary>
		/// <returns>return client list</returns>
		public IQueryable<Client> GetClients()
		{
			return _context.Clients;
		}
	}
}
