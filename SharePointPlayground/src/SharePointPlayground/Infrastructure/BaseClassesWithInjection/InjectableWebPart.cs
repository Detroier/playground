using System.Collections.Generic;

using SharePointPlayground.Infrastructure.Container;

namespace SharePointPlayground.Infrastructure.BaseClassesWithInjection
{
	public class InjectableWebPart : Microsoft.SharePoint.WebPartPages.WebPart
	{
		private List<object> _injectedInstances;

		public InjectableWebPart()
		{
			_injectedInstances = ContainerHelper.Kernel.InjectDependencies(this);
		}

		public override void Dispose()
		{
			ContainerHelper.Kernel.ReleaseInjectedObjects(_injectedInstances);
			base.Dispose();
		}
	}
}
