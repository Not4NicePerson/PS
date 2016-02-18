using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using PS.Domain.Abstract;
using PS.Domain.Entities;
using PS.Domain.Entities.Db;

namespace PS.Domain.Concrete
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
	{
		internal EFDbContext Context;
		internal DbSet<TEntity> DbSet; 

		public Repository(string connName)
		{
			Context = new EFDbContext(connName);
			DbSet = Context.Set<TEntity>();
		} 

		public IQueryable<TEntity> Entities 
		{
			get { return DbSet; }
		}

		public TEntity FindById(int id)
		{
			return Entities.FirstOrDefault(x => x.Id == id);
		}

		public void Create(TEntity entity)
		{
			entity.CreatedOn = DateTime.Now;
			DbSet.Add(entity);
			Context.Entry(entity).State = EntityState.Added;
		}

		public void Update(TEntity entity)
		{
			entity.ChangedOn = DateTime.Now;
			DbSet.AddOrUpdate(entity);
		}

		public void Delete(int id)
		{
			TEntity entity = DbSet.Find(id);
			Delete(entity);
		}

		public void Delete(TEntity entity)
		{
			DbSet.Attach(entity);
			Context.Entry(entity).State = EntityState.Deleted;
			DbSet.Remove(entity);
		}

		public void SaveChanges()
		{
			Context.SaveChanges();
		}
	}
}