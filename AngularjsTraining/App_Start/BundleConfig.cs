using System.Web.Optimization;

namespace AngularjsTraining
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/lib/jquery/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/lib/jquery/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/lib/modernizr/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/lib/bootstrap/bootstrap.js",
					  "~/Scripts/lib/bootstrap/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
						"~/Scripts/lib/angularjs/angular.min.js",
						"~/Scripts/lib/angularjs/angular-ui-router.min.js",
						"~/Scripts/lib/angularjs/angular-animate.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/lodash").Include(
						"~/Scripts/lib/lodash/lodash.core.min.js",
						"~/Scripts/lib/lodash/lodash.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/workjs").Include(
						"~/Scripts/app.js",
						"~/Scripts/app.config.js",
						"~/Scripts/services/dataservice.js",
						"~/Scripts/controllers/clients.table.js",
						"~/Scripts/controllers/client.form.js",
						"~/Scripts/controllers/incidents.table.js",
						"~/Scripts/controllers/incident.form.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/css/bootstrap.css",
					  "~/Content/css/site.css"));
		}
	}
}
