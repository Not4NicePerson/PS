using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PS.Domain.Abstract;
using PS.Domain.Entities.Db;
using PS.WebUI.Areas.Admin.Controllers.Base;

namespace PS.Tests
{
	[TestFixture]
	public class BaseCrudControllerTests
	{
		[Test]
		public void TestCreateEntity()
		{
			Mock<IRepository<Category>> moq = new Mock<IRepository<Category>>();
			Category stubEntity = new Category();

			moq.Setup(x => x.Create(stubEntity)).Callback(() =>
			{
				Assert.Pass("Create was called");
			});

			BaseCrudController<Category> stubController = new BaseCrudController<Category>();
			stubController.Repository = moq.Object;
			stubController.Create(stubEntity);

			Assert.Fail("No callback");
		}

		[Test]
		public void TestUpdateEntity()
		{
			Mock<IRepository<Category>> moq = new Mock<IRepository<Category>>();
			Category stubEntity = new Category { Id = 10 };

			moq.Setup(x => x.Entities).Returns(new List<Category>
			{
				new Category{ Id = 50},
				stubEntity
			}.AsQueryable());

			moq.Setup(x => x.Update(stubEntity)).Callback(() =>
			{
				Assert.Pass("Update was called (passed entity)");
			});

			BaseCrudController<Category> stubController = new BaseCrudController<Category>();
			stubController.Repository = moq.Object;
			stubController.Update(stubEntity);

			//Assert.Ignore("fix");
			Assert.Fail("No callback");
		}

		[Test]
		public void TestReadEntity()
		{
			Mock<IRepository<Category>> moq = new Mock<IRepository<Category>>();

			moq.Setup(x => x.Entities).Returns(new List<Category>
			{
				new Category{ Id = 10},
				new Category{ Id = 20},
				new Category{ Id = 30}
			}.AsQueryable());



			BaseCrudController<Category> stubController = new BaseCrudController<Category>();
			stubController.Repository = moq.Object;
			var viewResult = stubController.List() as ViewResult;
			var result = viewResult.Model as List<Category>;

			Assert.AreEqual(3, result.Count);
			Assert.AreEqual(10, result[0].Id);
			Assert.AreEqual(20, result[1].Id);
			Assert.AreEqual(30, result[2].Id);

		}

		[Test]
		public void TestDeleteEntity()
		{
			Mock<IRepository<Category>> moq = new Mock<IRepository<Category>>();
			Category stubEntity = new Category { Id = 10 };

			moq.Setup(x => x.Entities).Returns(new List<Category>
			{
				new Category{ Id = 50},
				stubEntity
			}.AsQueryable());

			moq.Setup(x => x.Delete(stubEntity.Id)).Callback(() =>
			{
				Assert.Pass("Delete was called (passed Id)");
			});

			moq.Setup(x => x.Delete(stubEntity)).Callback(() =>
			{
				Assert.Pass("Delete was called (passed entity)");
			});

			BaseCrudController<Category> stubController = new BaseCrudController<Category>();
			stubController.Repository = moq.Object;
			stubController.Delete(stubEntity.Id);

			Assert.Ignore("fix");
			Assert.Fail("No callback");
		}

	}
}
