using System.ComponentModel.DataAnnotations;

namespace PS.Domain.Entities.Db
{
	public class Product : BaseEntity
	{
		[Required]
		[Display(Name = "ProductName", ResourceType = typeof(Resources.Resources))]
		public string Name { get; set; }

		[Display(Name = "ProductDescription", ResourceType = typeof(Resources.Resources))]
		public string Description { get; set; }

		[Required]
		[Display(Name = "ProductPrice", ResourceType = typeof(Resources.Resources))]
		public decimal Price { get; set; }

		[Display(Name = "Image", ResourceType = typeof(Resources.Resources))]
		public byte[] Image { get; set; }
		public string ImageMimeType { get; set; }

		[Required]
		[Display(Name = "CategoryName", ResourceType = typeof(Resources.Resources))]
		public int CategoryId { get; set; }

		[Display(Name = "CategoryName", ResourceType = typeof(Resources.Resources))]
		public Category Category { get; set; }

		[Display(Name = "CountryName", ResourceType = typeof(Resources.Resources))]
		public int CountryId { get; set; }

		[Display(Name = "CountryName", ResourceType = typeof(Resources.Resources))]
		public Country Country { get; set; }

	}
}
