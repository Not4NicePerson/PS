using System.Collections.Generic;
using PS.Domain.Entities.Db;

namespace PS.WebUI.Models
{
	public class ProductModel
	{
		public PageInfoModel PageInfoModel { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}