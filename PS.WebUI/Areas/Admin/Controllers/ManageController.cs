using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using PS.WebUI.Infrastructure.Filters;

namespace PS.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	public class ManageController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}