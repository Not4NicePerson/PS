using System.Collections.Generic;
using System.Data.Entity;
using PS.Domain.Concrete;
using PS.Domain.Entities.Db;

namespace PS.Domain.Support
{
	public class DropCreateDbIfModelChangedAndFillData<TContext> : DropCreateDatabaseIfModelChanges<TContext> where TContext : EFDbContext
	{
		protected override void Seed(TContext context)
		{
			Category waterSport = new Category { Id = 1, Name = "Водный спорт" };
			Category gym = new Category { Id = 2, Name = "Тренажерный зал" };
			Category boardGame = new Category { Id = 3, Name = "Настольные игры" };
			Category crazy = new Category { Id = 4, Name = "Для поехваших" };

			Country sweeden = new Country { Id = 1, Name = "Швеция" };
			Country russia = new Country { Id = 2, Name = "Россия" };
			Country german = new Country { Id = 3, Name = "Германия" };
			Country usa = new Country { Id = 4, Name = "США" };

			IEnumerable<Product> products = new Product[]
			{
				new Product
				{
					Id = 1, Name = "Лодка", Price = 1000,
					Category = waterSport, CategoryId = waterSport.Id,
					Country = russia, CountryId = russia.Id
				},

				new Product
				{
					Id = 2, Name = "Шахматы", Price = 25,
					Category = boardGame, CategoryId = boardGame.Id,
					Country = russia, CountryId = russia.Id
				},

				new Product
				{
					Id = 3, Name = "Пюропротеин", Description = "Спонсор тесак", Price = 100,
					Category = gym, CategoryId = gym.Id,
					Country = german, CountryId = german.Id
				},

				new Product
				{
					Id = 4, Name = "Шашки", Price = 25,
					Category = boardGame, CategoryId = boardGame.Id,
					Country = sweeden, CountryId = sweeden.Id
				},

				new Product
				{
					Id = 5, Name = "Водные лыжи", Price = 500,
					Category = waterSport, CategoryId = waterSport.Id,
					Country = sweeden, CountryId = sweeden.Id
				},

				new Product
				{
					Id = 6, Name = "Али бурда", Price = 75,
					Category = boardGame, CategoryId = boardGame.Id,
					Country = german, CountryId = german.Id
				},

				new Product
				{
					Id = 7, Name = "Еметр", Description = "Для саентологов.", Price = 10000,
					Category = crazy, CategoryId = crazy.Id,
					Country = usa, CountryId = usa.Id
				},

				new Product
				{
					Id = 8, Name = "Сладкий хлеб", Description = "Братишка", Price = 8814,
					Category = crazy, CategoryId = crazy.Id,
					Country = russia, CountryId = russia.Id
				},

				new Product
				{
					Id = 9, Name = "Крутите барабн", Description = "Для любетелей поля чудес", Price = 40,
					Category = boardGame, CategoryId = boardGame.Id,
					Country = russia, CountryId = russia.Id
				},

				new Product
				{
					Id = 10, Name = "Пластиковые очки", Description = "Для любетелей поля чудес", Price = 140,
					Category = waterSport, CategoryId = waterSport.Id,
					Country = sweeden, CountryId = sweeden.Id
				},

				new Product
				{
					Id = 11, Name = "Гантеля", Description = "20 кг", Price = 250,
					Category = gym, CategoryId = gym.Id,
					Country = russia, CountryId = russia.Id
				},

				new Product
				{
					Id = 12, Name = "Кросовки", Description = "Удобны для занятий в зале", Price = 200,
					Category = gym, CategoryId = gym.Id,
					Country = russia, CountryId = russia.Id
				},

				new Product
				{
					Id = 13, Name = "Ласты", Description = "С маской хороши", Price = 320,
					Category = waterSport, CategoryId = waterSport.Id,
					Country = sweeden, CountryId = sweeden.Id
				}
			};

			context.Products.AddRange(products);
			context.SaveChanges();

			base.Seed(context);
		}
	}
}