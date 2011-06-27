using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Releasers;

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

            // This might not be smartest move ever! Maybe only allow injection on interfaces
            // Use this, if overriding Dispose for each base class looks ugly for you
            //container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();

            return container;
        }
    }
}