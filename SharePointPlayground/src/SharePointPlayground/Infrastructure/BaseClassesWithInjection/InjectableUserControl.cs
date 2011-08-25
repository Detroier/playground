using System.Collections.Generic;
using System.Web.UI;
using Castle.Windsor;

using SharePointPlayground.Infrastructure.Container;

namespace SharePointPlayground.Infrastructure.BaseClassesWithInjection
{
	public class InjectableUserControl : UserControl
	{
		private List<object> _injectedInstances;


		public InjectableUserControl()
			: this(ContainerHelper.Kernel)
		{
		}

		public InjectableUserControl(IWindsorContainer kernel)
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
