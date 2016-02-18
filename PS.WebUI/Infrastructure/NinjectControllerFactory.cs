using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using PS.Domain.Abstract;
using PS.Domain.Concrete;
using PS.Domain.Entities.Db;

namespace PS.WebUI.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{

		private readonly IKernel _kernel;

		public NinjectControllerFactory()
		{
			_kernel = new StandardKernel();
			AddBindings();
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			Debug.WriteLine(controllerType);
			return controllerType == null
				? null
				: (IController) _kernel.Get(controllerType);
		}

		private void AddBindings()
		{
			_kernel.Bind(typeof (IRepository<Product>)).ToConstant(new Repository<Product>("Context"));
			_kernel.Bind(typeof(IRepository<Category>)).ToConstant(new Repository<Category>("Context"));
			_kernel.Bind(typeof(IRepository<Country>)).ToConstant(new Repository<Country>("Context"));
		}

	}
}