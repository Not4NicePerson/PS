using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PS.Domain.Abstract;
using PS.Domain.Entities;
using PS.Domain.Entities.Db;
using PS.WebUI.Controllers;

namespace PS.Tests
{
	[TestFixture]
	public class CartControllerTests
	{
		[Test]
		public void TestCanThrowHttpNotFound()
		{
			Mock<IRepository<Product>> stubRep = new Mock<IRepository<Product>>();
			stubRep.Setup(x => x.Entities).Returns(new Product[]
			{
				new Product{ Id = 1, Name = "prod 1"},
				new Product{ Id = 2, Name = "prod 2"},
				new Product{ Id = 3, Name = "prod 3"}
			}.AsQueryable());

			CartController ctrl = new CartController();
			ctrl.Repository = stubRep.Object;
			var redirectResult = ctrl.AddToCart(new Cart(), -5) as HttpNotFoundResult;
			Assert.AreEqual(redirectResult.StatusCode, 404);
		}

		[Test]
		public void TestAddProduct()
		{
			Mock<IRepository<Product>> stubRep = new Mock<IRepository<Product>>();
			stubRep.Setup(x => x.Entities).Returns(new Product[]
			{
				new Product{ Id = 1, Name = "prod 1"},
				new Product{ Id = 2, Name = "prod 2"},
				new Product{ Id = 3, Name = "prod 3"}
			}.AsQueryable());

			CartController ctrl = new CartController();
			ctrl.Repository = stubRep.Object;
			var redirectResult = ctrl.AddToCart(new Cart(), 2) as HttpNotFoundResult;
			Assert.IsNull(redirectResult);

		}

	}
}
