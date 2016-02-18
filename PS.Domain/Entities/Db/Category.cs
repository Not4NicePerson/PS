using System.ComponentModel.DataAnnotations;

namespace PS.Domain.Entities.Db
{
	public class Category : BaseEntity
	{
		[Required]
		[Display(Name = "CategoryName", ResourceType = typeof(Resources.Resources))]
		public string Name { get; set; }
	}
}
