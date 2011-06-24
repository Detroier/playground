using Castle.MicroKernel.Registration;

using WebApp.Services;

namespace WebApp.Infrastructure.Container.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                .Where(Component.IsInSameNamespaceAs<TextFetchService>())
                .WithService.DefaultInterface()
                .Configure(c => c.LifeStyle.Transient));
        }
    }
}