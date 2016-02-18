using System.Web.Mvc;
using PS.Domain.Entities.Db;

namespace PS.WebUI.Areas.Admin.Models
{
	public class ProductModel
	{
		public Product Product { get; set; }
		public SelectList CategoryList { get; set; }
		public SelectList CountryList { get; set; }
	}
}