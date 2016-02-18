using System.Linq;
using System.Web.Mvc;
using Ninject;
using PS.Domain.Abstract;
using PS.Domain.Entities;
using PS.Domain.Entities.Db;
using PS.WebUI.Infrastructure.Filters;

namespace PS.WebUI.Controllers
{
	public class CartController : Controller
	{
		[Inject]
		public IRepository<Product> Repository { get; set; }

		public ViewResult List(Cart cart)
		{
			return View(cart);
		}

		public ViewResult Checkout(Cart cart)
		{
			return View(cart);
		}

		public ActionResult RemoveFromCart(Cart cart, int id)
		{
			Product product = Repository.Entities.FirstOrDefault(x => x.Id == id);
			if (product != null)
			{
				cart.RemoveLine(product);
				return RedirectToAction("List");
			}
			else
			{
				return HttpNotFound();
			}
		}

		public ActionResult AddToCart(Cart cart, int id)
		{
			Product product = Repository.Entities.FirstOrDefault(x => x.Id == id);
			if (product != null)
			{
				cart.Add(product, 1);
				return RedirectToAction("List");
			}

			return HttpNotFound();
		}

		public PartialViewResult Summary(Cart cart)
		{
			return PartialView(cart);
		}

	}
}