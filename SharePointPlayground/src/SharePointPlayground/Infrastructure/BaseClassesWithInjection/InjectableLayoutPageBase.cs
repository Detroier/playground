using System.Collections.Generic;

using SharePointPlayground.Infrastructure.Container;
using Castle.Windsor;

namespace SharePointPlayground.Infrastructure.BaseClassesWithInjection
{
	public class InjectableLayoutPageBase : Microsoft.SharePoint.WebControls.LayoutsPageBase
	{
		private List<object> _injectedInstances;

		public InjectableLayoutPageBase()
			: this(ContainerHelper.Kernel)
		{
		}

		public InjectableLayoutPageBase(IWindsorContainer kernel)
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
