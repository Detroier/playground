using Castle.Windsor;
using Castle.Windsor.Installer;
using SharePointPlayground.Infrastructure.Container.Installers;

namespace SharePointPlayground.Infrastructure.Container
{
	public static class ContainerConfigurator
	{
		/// <summary>
		/// Configures the container.
		/// </summary>
		/// <returns></returns>
		public static IWindsorContainer ConfigureContainer()
		{
			IWindsorContainer container = new WindsorContainer()
				 .Install(FromAssembly.Containing<FacilitiesInstaller>());

			// This might not be smartest move ever! Maybe only allow injection on interfaces
			// Use this, if overriding Dispose for each base class looks ugly for you
			//container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();

			return container;
		}

	}
}
