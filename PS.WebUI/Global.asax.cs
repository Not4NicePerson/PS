using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using PS.Domain.Concrete;
using PS.Domain.Entities;
using PS.Domain.Support;
using PS.WebUI.Infrastructure;
using PS.WebUI.Infrastructure.Binders;
using PS.WebUI.Models;
using WebMatrix.WebData;

namespace PS.WebUI
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
			
			ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
			ModelBinders.Binders.Add(typeof(FilterModel), new FilterModelBinder());
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

			// TODO: запилить configuration manager

			Database.SetInitializer(new DropCreateDbIfModelChangedAndFillData<EFDbContext>());
			using (var context = new EFDbContext("Context"))
			{
				context.Database.Initialize(true);
			}

			WebSecurity.InitializeDatabaseConnection("Context", "User", "Id", "Name", true);
			if (!WebSecurity.UserExists("Admin"))
			{
				WebSecurity.CreateUserAndAccount("Admin", "Admin", false);
			}
		}
	}
}
