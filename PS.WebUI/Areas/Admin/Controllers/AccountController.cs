using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PS.WebUI.Areas.Admin.Models;
using PS.WebUI.Infrastructure.Filters;
using WebMatrix.WebData;

namespace PS.WebUI.Areas.Admin.Controllers
{
	public class AccountController : Controller
	{
		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(UserModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (WebSecurity.Login(model.Name, model.Password))
			{
				return RedirectToRoute(new { controller = "Manage", action = "Index" });
			}

			ModelState.AddModelError("wrong_name_or_pass", Resources.Resources.AuthError);
			return View();
		}

		[Authorize]
		public ActionResult Logout()
		{
			WebSecurity.Logout();
			return RedirectToRoute(new { controller = "Product", action = "List", area = "" });
		}

	}
}