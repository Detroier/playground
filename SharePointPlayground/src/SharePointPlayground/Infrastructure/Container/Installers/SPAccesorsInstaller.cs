using Castle.MicroKernel.Registration;
using SharePointPlayground.Helpers.SharePoint;

namespace SharePointPlayground.Infrastructure.Container.Installers
{
	public class SPAccesorsInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly()
									   .Where(Component.IsInSameNamespaceAs<ICurrentSiteAccesor>())
									   .WithService.DefaultInterface()
									   .Configure(c => c.LifeStyle.Transient));

		}
	}
}
