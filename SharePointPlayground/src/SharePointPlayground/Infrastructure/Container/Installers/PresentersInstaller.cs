using Castle.MicroKernel.Registration;

using SharePointPlayground.Presenters;
using SharePointPlayground.Queries;
using SharePointPlayground.Commands;

namespace SharePointPlayground.Infrastructure.Container.Installers
{
	public class PresentersInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(Component.For<LastTasksByUserPresenter>()
										.Named("InnerLastTasksByUserPresenter")
										.LifeStyle.Transient);

			container.Register(Component.For<ILastTasksByUserPresenter>()
										.ImplementedBy<LastTasksByUserPresenterWithScope>()
										.ServiceOverrides(ServiceOverride.ForKey<ILastTasksByUserPresenter>().Eq("InnerLastTasksByUserPresenter"))
										.LifeStyle.Transient);

			container.Register(AllTypes.FromThisAssembly()
				.Where(Component.IsInSameNamespaceAs<IBlogsFromDatabasePresenter>())
				.WithService.DefaultInterface()
				.Configure(c => c.LifeStyle.Transient));

			//container.Register(AllTypes.FromThisAssembly()
			//    .Where(Component.IsInSameNamespaceAs<ILastTasksByUserPresenter>())
			//    .WithService.DefaultInterface()
			//    .Configure(c => c.LifeStyle.Transient));

			container.Register(AllTypes.FromThisAssembly()
				.Where(Component.IsInSameNamespaceAs<ILastTasksByUserQuery>())
				.WithService.DefaultInterface()
				.Configure(c => c.LifeStyle.Transient));

			container.Register(AllTypes.FromThisAssembly()
				.Where(Component.IsInSameNamespaceAs<IAddPostCommand>())
				.WithService.DefaultInterface()
				.Configure(c => c.LifeStyle.Transient));
		}
	}
}
