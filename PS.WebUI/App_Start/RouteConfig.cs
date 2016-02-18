using System.Web.Mvc;
using System.Web.Routing;

namespace PS.WebUI
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}",
				defaults: new { controller = "Product", action = "List" },
				namespaces: new[] { "PS.WebUI.Controllers" }
			);
		}
	}
}
