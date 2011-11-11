using Microsoft.Practices.Unity;
using SPBaseDemo.Infrastructure.Container;

namespace SPBaseDemo.Infrastructure.Web.Controls
{
	public class BaseWebPart : Microsoft.SharePoint.WebPartPages.WebPart
	{
		private IUnityContainer _container;

		public BaseWebPart()
			: this(Container.ContainerLocator.Container)
		{
		}

		public BaseWebPart(IUnityContainer container)
		{
			_container = container;
			_container.InjectDependencies(this);
		}
	}
}
