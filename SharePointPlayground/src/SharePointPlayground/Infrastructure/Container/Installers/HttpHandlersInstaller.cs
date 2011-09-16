using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using SharePointPlayground.Web.HttpHandlers;

namespace SharePointPlayground.Infrastructure.Container.Installers
{
	public class HttpHandlersInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(AllTypes
								.FromThisAssembly()
								.Where(Component.IsInSameNamespaceAs<OrdersHandler>())
								.WithService.Self()
								.Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name)));
		}
	}
}
