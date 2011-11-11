using Microsoft.Practices.Unity;
using WCFBaseDemo.Infrastructure.Container;
using WCFBaseDemo.Infrastructure.Web;

namespace WCFBaseDemo.Host.Infrastructure.Container.Installers
{
	public class InfrastructureInstaller : IContainerInstaller
	{
		public void InstallDependencies(IUnityContainer container)
		{
			container.RegisterType<ICurrentHttpContextProvider, CurrentHttpContextProvider>();
		}
	}
}