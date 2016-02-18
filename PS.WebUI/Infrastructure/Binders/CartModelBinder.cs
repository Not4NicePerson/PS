using System.Web.Mvc;
using PS.Domain.Entities;

namespace PS.WebUI.Infrastructure.Binders
{
	public class CartModelBinder : IModelBinder
	{
		private readonly string _sessionKey = "_cart";

		// Session тянет объект по ключу из некой коллекции
		// и вероянтно это дело хранится некоторое время для пользователя(см global.asax, плясать надо оттуда)
		// следовательно после первого создания объекта Cart, все последующие вытягивания объекта из session
		// буду возвращать один и тот же объект со всеми изменениями котороые могут внестить из вне
		// TODO: Деасемблировать, посмотреть как там это дело устроено

		// UPDATE: http://stackoverflow.com/questions/17618849/asp-net-mvc-session-based-model-binder-update-value-back-to-session

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			Cart cart = controllerContext.HttpContext.Session[_sessionKey] as Cart;
			if (cart == null)
			{
				cart = new Cart();
				controllerContext.HttpContext.Session[_sessionKey] = cart;
			}
			return cart;
		}
	}
}