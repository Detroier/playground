using Castle.Windsor;
using Castle.Windsor.Installer;

namespace WebApp.Infrastructure.Container
{
    /// <summary>
    /// Helper.
    /// </summary>
    public static class ContainerHelper
    {
        private readonly static IWindsorContainer _kernel = ConfigureContainer();

        public static IWindsorContainer Kernel
        {
            get
            {
                return _kernel;
            }
        }

        private static IWindsorContainer ConfigureContainer()
        {
            IWindsorContainer container = new WindsorContainer()
                .Install(FromAssembly.This());

            return container;
        }
    }
}