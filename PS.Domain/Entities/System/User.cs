using System.ComponentModel.DataAnnotations.Schema;
using PS.Domain.Entities.Db;

namespace PS.Domain.Entities.System
{
	[Table("User")]
	public class User : BaseEntity
	{
		public string Name { get; set; }
	}
}
