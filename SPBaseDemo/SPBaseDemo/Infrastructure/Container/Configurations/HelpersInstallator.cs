using Microsoft.Practices.Unity;
using SPBaseDemo.Helpers.SharePoint;

namespace SPBaseDemo.Infrastructure.Container.Configurations
{
	public class HelpersInstallator : IContainerInstallator
	{
		public void InstallDependencies(IUnityContainer container)
		{
			container.RegisterType<ISharePointContextItemsAccesor, SharePointContextItemsAccesor>(new TransientLifetimeManager());
		}
	}
}
