using System.Collections.Generic;

using SPWindsor.Infrastructure.Container;

namespace SPWindsor.Infrastructure.BaseClassesWithInjection
{
	public class InjectableWebPart : System.Web.UI.WebControls.WebParts.WebPart
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
