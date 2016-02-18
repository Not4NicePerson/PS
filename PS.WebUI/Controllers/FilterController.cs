using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;
using PS.WebUI.Models;

namespace PS.WebUI.Controllers
{
	public class FilterController : Controller
	{
		[Inject]
		public IRepository<Category> CategoryRepository { get; set; }

		[Inject]
		public IRepository<Country> CountryRepository { get; set; }

		public ActionResult Category(FilterModel filters, int? id = null)
		{
			filters.CategoryId = id;
			return RedirectToAction("List", "Product", new { page = 1 });
		}

		public ActionResult Country(FilterModel filters, int? id = null)
		{
			filters.CountryId = id;
			return RedirectToAction("List", "Product", new { page = 1 });
		}

		public PartialViewResult CategoryList(FilterModel filters)
		{
			var result = CategoryRepository.Entities.ToList();
			ViewBag.SelectedCategoryId = filters.CategoryId;
			return PartialView(result);
		}

		public PartialViewResult CountryList(FilterModel filters)
		{
			var result = CountryRepository.Entities.ToList();
			ViewBag.SelectedCountryId = filters.CountryId;
			return PartialView(result);
		}

		// TODO: подумать куда это вынести
		public ActionResult ChangeCulture(string lang)
		{
			string returnUrl = Request.UrlReferrer.AbsolutePath;
			List<string> cultures = new List<string> { "ru", "en" };
			if (!cultures.Contains(lang))
			{
				lang = "en";
			}

			HttpCookie cookie = Request.Cookies["lang"];
			if (cookie != null)
			{
				cookie.Value = lang;
			}
			else
			{
				cookie = new HttpCookie("lang")
				{
					HttpOnly = false,
					Value = lang,
					Expires = DateTime.Now.AddYears(1)
				};
			}

			Response.Cookies.Add(cookie);
			return Redirect(returnUrl);
		}

	}
}