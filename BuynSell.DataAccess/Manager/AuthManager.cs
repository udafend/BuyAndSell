using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuynSell.DataAccess.Manager;
using BuynSell.DataAccess.Model;

namespace BuynSell.DataAccess.Manager
{
	public class AuthManager : BaseManager
	{
		/// <summary>
		/// authenticate user login
		/// </summary>
		/// <param name="username">this is the username</param>
		/// <param name="password">this is the password</param>
		/// <returns>return if Success OK, if not Bad or Exception message</returns>
		public string LogIn(string username,string password)
		{
			try
			{
				var user = _context.Users.Where(x => x.UserName.Equals(username) && x.Password.Equals(password));

				if (user.Count() > 0)
				{
					return "OK";
				}
				else
				{
					return "Bad";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
			
		}
	}
}
