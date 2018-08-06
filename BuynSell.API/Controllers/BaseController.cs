using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuynSell.DataAccess.Manager;

namespace BuynSell.API.Controllers
{
    public class BaseController : ApiController
    {
		// initializing 
		public readonly BaseManager _baseManager = new BaseManager();
    }
}
