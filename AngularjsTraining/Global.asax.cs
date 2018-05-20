using AngularjsTraining.App_Start;
using AngularjsTraining.DbHelper;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AngularjsTraining
{
	public class AngularjsTraining : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			// Инициализация базейки.
			Database.SetInitializer(new BankDbContextInitializer());

			// DI.
			AutofacConfig.ConfigureContainer();

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
