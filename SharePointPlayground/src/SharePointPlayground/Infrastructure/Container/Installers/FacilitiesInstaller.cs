using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;

using SharePointPlayground.Infrastructure.Data;

namespace SharePointPlayground.Infrastructure.Container.Installers
{
	/// <summary>
	/// Installs facilities used in application
	/// </summary>
	public class FacilitiesInstaller : IWindsorInstaller
	{
		/// <summary>
		/// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="store">The configuration store.</param>
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.AddFacility<LoggingFacility>(f =>
					f.LogUsing(LoggerImplementation.Log4net)
					.WithConfig("D:\\Home\\PersonalDevel\\log4net-Playground.config"));
			//change this to something better or even use App config

			container.AddFacility<TypedFactoryFacility>();
			container.AddFacility<PersistenceFacility>();
		}
	}
}