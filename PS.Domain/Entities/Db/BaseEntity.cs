using System;

namespace PS.Domain.Entities.Db
{
	// TODO: Расскоментить при реализации логгирования в репозитории
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? ChangedOn { get; set; }
		//public int CreatedById { get; set; }
		//public User CreatedBy { get; set; }
		//public int ChangedById { get; set; }
		//public User ChangedBy { get; set; }
	}
}
