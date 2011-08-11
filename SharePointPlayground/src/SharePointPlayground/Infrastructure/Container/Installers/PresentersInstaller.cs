using Castle.MicroKernel.Registration;

using SharePointPlayground.Presenters;

namespace SharePointPlayground.Infrastructure.Container.Installers
{
	public class PresentersInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly()
				.Where(Component.IsInSameNamespaceAs<IDummyPresenter>())
				.WithService.DefaultInterface()
				.Configure(c => c.LifeStyle.Transient));
		}
	}
}
