using System.Linq;
using PS.Domain.Entities.Db;

namespace PS.Domain.Abstract
{
	// TODO: реализовать UNIT OF WORK
	public interface IRepository<TEntity> where TEntity : BaseEntity
	{
		IQueryable<TEntity> Entities { get; }
		TEntity FindById(int id);
		void Create(TEntity entity);
		void Update(TEntity entity);
		void Delete(int id);
		void Delete(TEntity entity);
		void SaveChanges();
	}
}
