using Castle.Windsor;

namespace WebApp.Infrastructure.Container
{
    /// <summary>
    /// Helper.
    /// </summary>
    public static class ContainerHelper
    {
        private readonly static IWindsorContainer _kernel = ContainerBootstrapper.ConfigureContainer();

        public static IWindsorContainer Kernel
        {
            get
            {
                return _kernel;
            }
        }
    }
}