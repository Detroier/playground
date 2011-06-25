using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;

using Castle.Windsor;
using Castle.Windsor.Installer;

namespace WebApp.Infrastructure.Container
{
    public class ContainerBootstrapper
    {
        public static IWindsorContainer ConfigureContainer()
        {
            IWindsorContainer container = new WindsorContainer()
                .Install(FromAssembly.This());            

            return container;
        }
    }
}