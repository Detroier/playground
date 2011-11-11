using System.Reflection;
using Microsoft.Practices.Unity;
using WCFBaseDemo.Infrastructure.Container;

namespace WCFBaseDemo.Host.Infrastructure.Container
{
	public static class ContainerBootstrapper
	{
		public static IUnityContainer BootstrapContainer()
		{
			var container = new UnityContainer();
			var installers = new InstallersProvider(new Assembly[] { typeof(ContainerBootstrapper).Assembly }).GetInstallers();

			var containerConfigurator = new ContainerConfigurator(container, installers);
			containerConfigurator.ConfigureContainer();

			return container;
		}
	}
}