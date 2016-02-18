using System.ComponentModel.DataAnnotations;

namespace PS.Domain.Entities.Db
{
	public class Country : BaseEntity
	{
		[Required]
		[Display(Name = "CountryName", ResourceType = typeof(Resources.Resources))]
		public string Name { get; set; }
	}
}
