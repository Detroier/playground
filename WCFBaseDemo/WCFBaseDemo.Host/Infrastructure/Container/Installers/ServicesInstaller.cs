using Microsoft.Practices.Unity;
using WCFBaseDemo.Helpers;
using WCFBaseDemo.Infrastructure.Container;
using WCFBaseDemo.Services;

namespace WCFBaseDemo.Host.Infrastructure.Container.Installers
{
	public class ServicesInstaller : IContainerInstaller
	{
		void IContainerInstaller.InstallDependencies(IUnityContainer container)
		{
			container.RegisterType<DummyService>();

			container.RegisterType<IHelloWriter, AnotherHelloWriter>();
		}
	}
}