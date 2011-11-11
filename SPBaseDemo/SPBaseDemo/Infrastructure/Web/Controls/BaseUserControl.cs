using System.Web.UI;
using Microsoft.Practices.Unity;
using SPBaseDemo.Infrastructure.Container;

namespace SPBaseDemo.Infrastructure.Web.Controls
{
	public class BaseUserControl : UserControl
	{
		private IUnityContainer _container;

		public BaseUserControl()
			: this(Container.ContainerLocator.Container)
		{
		}

		public BaseUserControl(IUnityContainer container)
		{
			_container = container;
			_container.InjectDependencies(this);
		}
	}
}
