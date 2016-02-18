using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;
using PS.WebUI.Models;

namespace PS.WebUI.Controllers
{
	public class ProductController : Controller
	{
		[Inject]
		public IRepository<Product> Repository { get; set; }

		// Получаем количество элементов с учетом фильтрации
		private int GetCount(FilterModel filters)
		{
			return Repository
				.Entities
				.Where(x => filters.CategoryId == null || x.CategoryId == filters.CategoryId.Value)
				.Count(x => filters.CountryId == null || x.CountryId == filters.CountryId.Value);
		}

		public FileContentResult GetImage(int id)
		{
			Product prod = Repository.FindById(id);
			if (prod != null)
			{
				return File(prod.Image, prod.ImageMimeType);
			}
			return null;
		}

		public ActionResult Details(int? id)
		{
			var product = Repository.Entities
				.Include(x => x.Category)
				.Include(x => x.Country)
				.FirstOrDefault(x => x.Id == id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		public ViewResult List(FilterModel filters, int page = 1)
		{
			PageInfoModel pageInfo = new PageInfoModel
			{
				TotalItems = GetCount(filters),
				PageSize = filters.PageSize,
				CurrentPage = page
			};

			var result =
				(from item in Repository.Entities
				 where
					 (filters.CategoryId == null || item.CategoryId == filters.CategoryId.Value) &&
					 (filters.CountryId == null || item.CountryId == filters.CountryId.Value)
				 orderby item.Id
				 select item)
					.Skip((pageInfo.CurrentPage - 1) * pageInfo.PageSize)
					.Take(pageInfo.PageSize)
					.Include(x => x.Category)
					.Include(x => x.Country)
					.ToList();

			return View(new ProductModel
			{
				Products = result,
				PageInfoModel = pageInfo
			});
		}

	}
}