using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;

using Castle.MicroKernel.Registration;

namespace SPWindsor.Infrastructure.Container.Installers
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
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());
            container.AddFacility<TypedFactoryFacility>();
        }
    }
}