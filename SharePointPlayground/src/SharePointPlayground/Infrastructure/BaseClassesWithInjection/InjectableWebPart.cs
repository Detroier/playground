using System.Collections.Generic;

using SharePointPlayground.Infrastructure.Container;
using Castle.Windsor;

namespace SharePointPlayground.Infrastructure.BaseClassesWithInjection
{
	public class InjectableWebPart : Microsoft.SharePoint.WebPartPages.WebPart
	{
		private List<object> _injectedInstances;

		public InjectableWebPart()
			: this(ContainerHelper.Kernel)
		{
		}

		public InjectableWebPart(IWindsorContainer kernel)
		{
			_injectedInstances = kernel.InjectDependencies(this);
		}

		public override void Dispose()
		{
			ContainerHelper.Kernel.ReleaseInjectedObjects(_injectedInstances);
			base.Dispose();
		}
	}
}
