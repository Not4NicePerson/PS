using System.Linq;
using Moq;
using NUnit.Framework;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;
using PS.WebUI.Controllers;
using PS.WebUI.Models;

namespace PS.Tests
{
	[TestFixture]
	public class ProductControllerTests
	{
		[Test]
		public void TestFilterByCategory()
		{
			Mock<IRepository<Product>> mockRep = new Mock<IRepository<Product>>();
			mockRep.Setup(x => x.Entities).Returns(new Product[]
			{
				new Product{ Id = 1, Name = "Record 1", CategoryId = 1},
				new Product{ Id = 2, Name = "Record 2", CategoryId = 2},
				new Product{ Id = 3, Name = "Record 3", CategoryId = 3},
				new Product{ Id = 4, Name = "Record 4", CategoryId = 2},
				new Product{ Id = 5, Name = "Record 5", CategoryId = 1}
			}.AsQueryable());

			ProductController targetCtrl = new ProductController { Repository = mockRep.Object };

			var prodModel = targetCtrl.List(
				page: 1,
				filters: new FilterModel
				{
					PageSize = 2,
					CategoryId = 1
				}).Model as ProductModel;

			var result = prodModel.Products.ToList();

			Assert.AreEqual(result.Count(), 2);
			Assert.AreEqual(result[0].Name, "Record 1");
			Assert.AreEqual(result[1].Name, "Record 5");
		}

		[Test]
		public void TestFilterByCountry()
		{
			Mock<IRepository<Product>> mockRep = new Mock<IRepository<Product>>();
			mockRep.Setup(x => x.Entities).Returns(new Product[]
			{
				new Product{ Id = 1, Name = "Record 1", CountryId = 1},
				new Product{ Id = 2, Name = "Record 2", CountryId = 2},
				new Product{ Id = 3, Name = "Record 3", CountryId = 1},
				new Product{ Id = 4, Name = "Record 4", CountryId = 2},
				new Product{ Id = 5, Name = "Record 5", CountryId = 1},
				new Product{ Id = 6, Name = "Record 6", CountryId = 3},
				new Product{ Id = 7, Name = "Record 7", CountryId = 4}
			}.AsQueryable());

			ProductController targetCtrl = new ProductController { Repository = mockRep.Object };

			var prodModel = targetCtrl.List(
				page: 2,
				filters: new FilterModel
				{
					PageSize = 2,
					CountryId = 1
				}).Model as ProductModel;

			var result = prodModel.Products.ToList();

			Assert.AreEqual(prodModel.PageInfoModel.TotalItems, 3);
			Assert.AreEqual(result[0].Name, "Record 5");
		}


		[Test]
		public void TestFilterByCategoryAndCountry()
		{
			Mock<IRepository<Product>> mockRep = new Mock<IRepository<Product>>();
			mockRep.Setup(x => x.Entities).Returns(new Product[]
			{
				new Product{ Id = 1, Name = "Record 1", CategoryId = 1, CountryId = 1},
				new Product{ Id = 2, Name = "Record 2", CategoryId = 1, CountryId = 2},
				new Product{ Id = 3, Name = "Record 3", CategoryId = 3, CountryId = 1},
				new Product{ Id = 4, Name = "Record 4", CategoryId = 2, CountryId = 1},
				new Product{ Id = 5, Name = "Record 5", CategoryId = 3, CountryId = 4},
				new Product{ Id = 5, Name = "Record 6", CategoryId = 1, CountryId = 1}
			}.AsQueryable());

			ProductController targetCtrl = new ProductController { Repository = mockRep.Object };

			var prodModel = targetCtrl.List(
				page: 1,
				filters: new FilterModel
				{
					PageSize = 2,
					CategoryId = 3,
					CountryId = 1
				}).Model as ProductModel;

			var result = prodModel.Products.ToList();

			Assert.AreEqual(result.Count(), 1);
			Assert.AreEqual(result[0].Name, "Record 3");
		}

	}
}
