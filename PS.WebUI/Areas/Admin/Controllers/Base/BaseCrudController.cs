using System.Linq;
using System.Web.Mvc;
using Ninject;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;

namespace PS.WebUI.Areas.Admin.Controllers.Base
{
	[Authorize]
	public class BaseCrudController<TEntity> : Controller where TEntity : BaseEntity, new ()
	{
		[Inject]
		public IRepository<TEntity> Repository { get; set; }

		[HttpGet]
		public virtual ActionResult List()
		{
			var list = Repository.Entities.ToList();
			return View(list);
		}

		[HttpPost]
		public virtual ActionResult Create(TEntity entity)
		{
			if (!ModelState.IsValid)
			{
				return View(entity);
			}

			Repository.Create(entity);
			Repository.SaveChanges();
			return RedirectToAction("List");
		}

		[HttpGet]
		public virtual ViewResult Create()
		{
			return View(new TEntity());
		}

		[HttpPost]
		public virtual ActionResult Update(TEntity entity)
		{
			if (!ModelState.IsValid)
			{
				return View(entity);
			}

			Repository.Update(entity);
			Repository.SaveChanges();
			return RedirectToAction("List");
		}

		[HttpGet]
		public virtual ActionResult Update(int id)
		{
			TEntity entity = Repository.FindById(id);

			if (entity == null || entity.Id <= 0)
			{
				return HttpNotFound();
			}
			return View(entity);
		}

		// TODO: Запилить POST
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			TEntity entity = Repository.FindById(id);

			if (entity == null)
			{
				return HttpNotFound();
			}

			Repository.Delete(entity.Id);
			Repository.SaveChanges();
			return RedirectToAction("List");
		}

	}
}