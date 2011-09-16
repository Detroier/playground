using System;
using System.Collections.Generic;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using SharePointPlayground.Model;
using System.Web;
using SharePointPlayground.Infrastructure.HttpModules;

namespace SharePointPlayground.Infrastructure.Data
{
	public class PersistenceFacility : AbstractFacility
	{
		protected override void Init()
		{
			var configuration = BuildDatabaseConfiguration();

			Kernel.Register(Component.For<ISessionFactory>().UsingFactoryMethod(configuration.BuildSessionFactory));
			Kernel.Register(Component.For<NHibernateSessionModule>());
			Kernel.Register(Component.For<ISessionFactoryProvider>().AsFactory());
			Kernel.Register(Component.For<IEnumerable<ISessionFactory>>().UsingFactoryMethod(k => k.ResolveAll<ISessionFactory>()));

			HttpContext.Current.Application[SessionFactoryProvider.Key] = Kernel.Resolve<ISessionFactoryProvider>();
		}

		private Configuration BuildDatabaseConfiguration()
		{
			var configuration = Fluently
							.Configure()
							.Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromAppSetting("NHibernateConnection")))
							.Mappings(Configure())
							.ExposeConfiguration(c =>
							{
								BuildSchema(c);
							})
							.BuildConfiguration();
			configuration.Properties[NHibernate.Cfg.Environment.CurrentSessionContextClass] = typeof(LazySessionContext).AssemblyQualifiedName;

			return configuration;
		}

		private Action<MappingConfiguration> Configure()
		{
			//just dummy mapping, but usable for now
			return m => m.AutoMappings.Add(AutoMap
											.AssemblyOf<Post>()
											.Where(x =>
											{
												return x.Name == "Post" || x.Name == "Comment" || x.Name == "PostTag";
											}));
			//optionally export mappings
			//.ExportTo("c:\\Development\\mappings");
		}

		private static void BuildSchema(Configuration configuration)
		{
			//optionally recreate the database
			//   new SchemaExport(configuration).Create(true, true);
		}
	}
}