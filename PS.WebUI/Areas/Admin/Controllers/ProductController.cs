using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;
using PS.WebUI.Areas.Admin.Models;

namespace PS.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	public class ProductController : Controller
	{
		[Inject]
		public IRepository<Product> Repository { get; set; }

		[Inject]
		public IRepository<Category> CategoryRepository { get; set; }

		[Inject]
		public IRepository<Country> CountryRepository { get; set; }

		public FileContentResult GetImage(int id)
		{
			Product prod = Repository.FindById(id);
			if (prod != null)
			{
				return File(prod.Image, prod.ImageMimeType);
			}
			return null;
		}

		private void SetImageContent(Product entity, HttpPostedFileBase file)
		{
			if (file != null)
			{
				entity.ImageMimeType = file.ContentType;
				entity.Image = new byte[file.ContentLength];
				file.InputStream.Read(entity.Image, 0, file.ContentLength);
			}
		}

		private ProductModel GetProductModel(Product product)
		{
			return new ProductModel
			{
				Product = product,
				CategoryList = new SelectList(CategoryRepository.Entities.ToList(), "Id", "Name", product.CategoryId),
				CountryList = new SelectList(CountryRepository.Entities.ToList(), "Id", "Name", product.CountryId)
			};
		}

		public ActionResult List()
		{
			var list = Repository.Entities.Include(x => x.Category).Include(x => x.Country).ToList();
			return View(list);
		}

		[HttpPost]
		public ActionResult Create(ProductModel model, HttpPostedFileBase file)
		{
			if (!ModelState.IsValid)
			{
				return View(GetProductModel(model.Product));
			}

			SetImageContent(model.Product, file);
			Repository.Create(model.Product);
			Repository.SaveChanges();
			return RedirectToAction("List");
		}

		public ViewResult Create()
		{
			return View(GetProductModel(new Product()));
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			var entity = Repository.FindById(id);

			if (entity == null)
			{
				return HttpNotFound();
			}

			return View(GetProductModel(entity));
		}

		[HttpPost]
		public ActionResult Update(ProductModel model, HttpPostedFileBase file)
		{
			if (!ModelState.IsValid)
			{
				return View(GetProductModel(model.Product));
			}

			SetImageContent(model.Product, file);
			Repository.Update(model.Product);
			Repository.SaveChanges();
			return RedirectToAction("List");
		}

		// не ок
		public ActionResult Delete(int id)
		{
			var entity = Repository.FindById(id);

			if (entity == null)
			{
				return HttpNotFound();
			}

			Repository.Delete(entity);
			Repository.SaveChanges();
			return RedirectToAction("List");
		}
	}
}