using Microsoft.Practices.Unity;
using SPBaseDemo.Infrastructure.Container;

namespace SPBaseDemo.Infrastructure.Web.Controls
{
	public class BaseLayoutPageBase : Microsoft.SharePoint.WebControls.LayoutsPageBase
	{
		private IUnityContainer _container;

		public BaseLayoutPageBase()
			: this(Container.ContainerLocator.Container)
		{
		}

		public BaseLayoutPageBase(IUnityContainer container)
		{
			_container = container;
			_container.InjectDependencies(this);
		}
	}
}
