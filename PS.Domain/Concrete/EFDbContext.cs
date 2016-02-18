using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PS.Domain.Entities.Configuration;
using PS.Domain.Entities.Db;
using PS.Domain.Entities.System;
using PS.Domain.Support;

namespace PS.Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		public EFDbContext(string connName) : base(connName)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

			// TODO: расскоментить если найду решение по валидации посредством fluent api
			//modelBuilder.Configurations.Add(new ProductConfig());
			//modelBuilder.Configurations.Add(new CategoryConfig());
			//modelBuilder.Configurations.Add(new CountryConfig());

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Country> Countries { get; set; }
	}
}
