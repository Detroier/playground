using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;

using Castle.MicroKernel.Registration;

namespace WebApp.Infrastructure.Container.Installers
{
    public class FacilitiesInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());
            container.AddFacility<TypedFactoryFacility>();
        }
    }
}