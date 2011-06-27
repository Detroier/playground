using Castle.MicroKernel.Registration;
using WebApp.Presenters;

namespace WebApp.Infrastructure.Container.Installers
{
    public class PresentersInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                .Where(Component.IsInSameNamespaceAs<IDefaultPagePresenter>())
                .WithService.DefaultInterface()
                .Configure(c => c.LifeStyle.Transient));
        }
    }
}