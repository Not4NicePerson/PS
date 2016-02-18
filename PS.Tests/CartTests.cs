using System.Linq;
using NUnit.Framework;
using PS.Domain.Entities;
using PS.Domain.Entities.Db;

namespace PS.Tests
{
	[TestFixture]
	public class CartTests
	{
		[Test]
		public void TestAddLine()
		{
			Product first_product = new Product { Id = 1, Name = "Product 1" };

			Cart cart = new Cart();
			cart.Add(first_product, 1);
			var result = cart.Lines.ToList();
			Assert.AreEqual("Product 1", result[0].Product.Name);
		}

		[Test]
		public void TestRemoveLine()
		{
			Product firstProduct = new Product { Id = 1, Name = "Product 1" };
			Product secondProduct = new Product { Id = 2, Name = "Product 2" };
			Cart cart = new Cart();
			cart.Add(firstProduct, 1);
			cart.Add(secondProduct, 1);

			Assert.AreEqual(2, cart.Lines.Count());
			cart.RemoveLine(firstProduct);
			Assert.AreEqual(1, cart.Lines.Count());
			Assert.AreEqual("Product 2", cart.Lines.ToList()[0].Product.Name);
		}

		[Test]
		public void TestCalculateTotalValue()
		{
			Product firstProduct = new Product { Id = 1, Name = "Product 1", Price = 2 };
			Product secondProduct = new Product { Id = 2, Name = "Product 2", Price = 5 };

			Cart cart = new Cart();
			cart.Add(firstProduct, 3);
			cart.Add(secondProduct, 3);

			var total = cart.ComputeTotalValue();

			Assert.AreEqual(21, total);
		}

		[Test]
		public void TestClearCart()
		{
			Product firstProduct = new Product { Id = 1, Name = "Product 1", Price = 2 };
			Product secondProduct = new Product { Id = 2, Name = "Product 2", Price = 5 };

			Cart cart = new Cart();
			cart.Add(firstProduct, 3);
			cart.Add(secondProduct, 3);
			

			Assert.AreEqual(2, cart.Lines.Count());
			cart.Clear();
			Assert.AreEqual(0, cart.Lines.Count());
		}

	}
}
