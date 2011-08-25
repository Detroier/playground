using Castle.MicroKernel.Registration;

using SPWindsor.Presenters;

namespace SPWindsor.Infrastructure.Container.Installers
{
	public class PresentersInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly()
				.Where(Component.IsInSameNamespaceAs<DefaultPageLayoutPresenter>())
				.WithService.DefaultInterface()
				.Configure(c => c.LifeStyle.Transient));
		}
	}
}
