using Castle.MicroKernel.Registration;
using SharePointPlayground.Services;

namespace SharePointPlayground.Infrastructure.Container.Installers
{
	public class ServicesInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(AllTypes
								.FromThisAssembly()
								.Where(Component.IsInSameNamespaceAs<PostsService>())
								.WithService.Self()
								.Configure(c => c.LifeStyle.Transient));
		}
	}
}
