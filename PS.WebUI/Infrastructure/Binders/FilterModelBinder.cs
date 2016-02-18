using System.Web.Mvc;
using PS.WebUI.Models;

namespace PS.WebUI.Infrastructure.Binders
{
	public class FilterModelBinder : IModelBinder
	{
		private readonly string _sessionKey = "filters";

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			FilterModel model = controllerContext.HttpContext.Session[_sessionKey] as FilterModel;

			if (model == null)
			{
				model = new FilterModel { PageSize = 12 };
				controllerContext.HttpContext.Session[_sessionKey] = model;
			}

			return model;
		}
	}
}