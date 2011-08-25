using System.Collections.Generic;

using SPWindsor.Infrastructure.Container;

namespace SPWindsor.Infrastructure.BaseClassesWithInjection
{
	public class InjectableLayoutPageBase : Microsoft.SharePoint.WebControls.LayoutsPageBase
	{
		private List<object> _injectedInstances;

		public InjectableLayoutPageBase()
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
