using Microsoft.Practices.Unity;
using WCFBaseDemo.Host.Infrastructure.Container;
using WCFBaseDemo.Infrastructure.WCF;

namespace WCFBaseDemo.Host.Infrastructure.WCF
{
	public class UnityServiceBehavior : AbstractUnityServiceBehavior
	{
		public UnityServiceBehavior()
			: base(ContainerBootstrapper.BootstrapContainer())
		{
		}

		public UnityServiceBehavior(IUnityContainer container)
			: base(container)
		{
		}
	}
}