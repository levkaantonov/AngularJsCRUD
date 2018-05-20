using Autofac;
using Autofac.Integration.Mvc;
using AngularjsTraining.DbHelper;
using AngularjsTraining.Models;
using AngularjsTraining.Repositories;
using System.Web.Mvc;

namespace AngularjsTraining.App_Start
{
	public class AutofacConfig
	{
		public static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(AngularjsTraining).Assembly);

			builder.RegisterType<IncidentsRepository>().As<RepositoryBase<Incident>>().WithParameter("db", new BankDbContext());
			builder.RegisterType<ClientsRepository>().As<RepositoryBase<Client>>().WithParameter("db", new BankDbContext());

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}