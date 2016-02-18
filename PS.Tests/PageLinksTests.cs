using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;
using PS.WebUI.HtmlHelpers;
using PS.WebUI.Models;

namespace PS.Tests
{
	[TestFixture]
	class PageLinksTests
	{
		[Test]
		public void TestGeneratePaging()
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

			var result = PagingHelper.PageLinks(
				null, (x) => string.Format("Page/{0}", x), pageInfo);

			var expected = string.Format("<ul class=\"pagination\">{0}{1}</ul>",
				"<li><a href=\"Page/1\">1</a></li>",
				"<li class=\"active\"><a href=\"Page/2\">2</a></li>");

			Assert.AreEqual(expected, result.ToString());
		}

	}
}
