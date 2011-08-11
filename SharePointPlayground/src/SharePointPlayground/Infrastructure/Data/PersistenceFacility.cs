using System;

using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

using SharePointPlayground.Model;

namespace SharePointPlayground.Infrastructure.Data
{
	public class PersistenceFacility : AbstractFacility
	{
		protected override void Init()
		{
			var configuration = BuildDatabaseConfiguration();

			Kernel.Register(
				Component.For<ISessionFactory>()
					.UsingFactoryMethod(configuration.BuildSessionFactory),
				Component.For<ISession>()
					.UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
					.LifeStyle.PerWebRequest);
		}

		private Configuration BuildDatabaseConfiguration()
		{
			return Fluently
				.Configure()
				.Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromAppSetting("NHibernateConnection")))
				.Mappings(Configure())
				.ExposeConfiguration(c =>
				{
					c.SetProperty("current_session_context_class", "web");
					BuildSchema(c);
				})
				.BuildConfiguration();
		}

		private Action<MappingConfiguration> Configure()
		{
			//just dummy mapping, but usable for now
			return m => m.AutoMappings.Add(AutoMap
											.AssemblyOf<SimpleNewsItem>()
											.Where(x => x.Namespace == typeof(SimpleNewsItem).Namespace));
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
