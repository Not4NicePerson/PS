using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Moq;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;
using PS.WebUI.Models;

namespace PS.Tests
{
	[TestFixture]
	public class PageInfoModelTests
	{
		[Test]
		public void TestEvenPagesWithOddRecords()
		{
			Mock<IRepository<Product>> stubRep = new Mock<IRepository<Product>>();
			stubRep.Setup(x => x.Entities).Returns(new List<Product>
			{
				new Product{ Id = 1 },
				new Product{ Id = 2 },
				new Product{ Id = 3 },
				new Product{ Id = 4 },
				new Product{ Id = 5 },
			}.AsQueryable());

			PageInfoModel pageInfo = new PageInfoModel
			{
				PageSize = 4,
				CurrentPage = 2,
				TotalItems = stubRep.Object.Entities.Count()
			};

			Assert.AreEqual(pageInfo.TotalPages, 2);
		}

		[Test]
		public void TestChangePageSize()
		{
			Mock<IRepository<Product>> stubRep = new Mock<IRepository<Product>>();
			stubRep.Setup(x => x.Entities).Returns(new List<Product>
			{
				new Product{ Id = 1 },
				new Product{ Id = 2 },
				new Product{ Id = 3 },
				new Product{ Id = 4 },
				new Product{ Id = 5 },
			}.AsQueryable());

			PageInfoModel pageInfo = new PageInfoModel
			{
				PageSize = 2,
				CurrentPage = 1,
				TotalItems = stubRep.Object.Entities.Count()
			};

			Assert.AreEqual(pageInfo.TotalPages, 3);
		}

		}

}