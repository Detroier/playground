using Microsoft.Practices.Unity;

namespace WCFBaseDemo.Infrastructure.Container
{
	public class ContainerConfigurator
	{
		private IUnityContainer _container;
		private IContainerInstaller[] _installers;

		public ContainerConfigurator(IUnityContainer container, IContainerInstaller[] installers)
		{
			_container = container;
			_installers = installers;
		}

		public void ConfigureContainer()
		{
			foreach (var installer in _installers)
			{
				installer.InstallDependencies(_container);
			}
		}
	}
}
