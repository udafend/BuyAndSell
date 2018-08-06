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
	[RoutePrefix("api/Auth")]
	public class AuthController : BaseController
    {
		private readonly AuthManager _authManager = new AuthManager();


		/// <summary>
		/// authenticate user login
		/// </summary>
		/// <param name="username">this is the username</param>
		/// <param name="password">this is the password</param>
		/// <returns>return if Success OK, if not Bad or Exception message</returns>
		[HttpGet]
		[Route("Login")]
		public string LogIn(string username, string password)
		{
			try
			{
				if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				{
					return "Required Username and Password";
				}
				else
				{
					return _authManager.LogIn(username,password);
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

		}
	}
}
