using Microsoft.Practices.Unity;
using WCFBaseDemo.Data;
using WCFBaseDemo.Infrastructure.Container;
using WCFBaseDemo.Infrastructure.Data;

namespace WCFBaseDemo.Host.Infrastructure.Container.Installers
{
	public class DataInstaller : IContainerInstaller
	{
		public void InstallDependencies(IUnityContainer container)
		{
			container.RegisterType<IDbContextFactory<WCFBaseDemoDbContext>, WCFBaseDemoDbContextHttpTrackingFactory>();
		}
	}
}