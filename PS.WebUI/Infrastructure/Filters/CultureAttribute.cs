using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PS.WebUI.Infrastructure.Filters
{
	public class CultureAttribute : FilterAttribute, IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{

		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			string cultureName = null;
			HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
			if (cultureCookie != null)
			{
				cultureName = cultureCookie.Value;
			}
			else
			{
				cultureName = "en";
			}

			List<string> cultures = new List<string> { "ru", "end" };
			if (!cultures.Contains(cultureName))
			{
				cultureName = "en";
			}

			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
			Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);


		}
	}
}