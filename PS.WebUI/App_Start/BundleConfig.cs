using System.Web.Optimization;

namespace PS.WebUI
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/General")
				.Include("~/Scripts/jquery-2.2.0.min.js")
				.Include("~/Scripts/modernizr-2.8.3.js")
				.Include("~/Scripts/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/General-validation")
				.Include("~/Scripts/jquery.validate.min.js"));

			bundles.Add(new StyleBundle("~/bundles/General-css")
				.Include("~/Content/bootstrap.min.css")
				.Include("~/Content/bootstrap-theme.min.css"));

		}
	}
}