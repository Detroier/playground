using System.Web;
using Castle.Windsor;
using SharePointPlayground.Infrastructure.Container;

namespace SharePointPlayground.Infrastructure.HttpHandlers
{
	public class WindsorHttpHandlerFactory : IHttpHandlerFactory
	{
		private IWindsorContainer _kernel;

		public WindsorHttpHandlerFactory()
			: this(ContainerHelper.Kernel)
		{
		}

		public WindsorHttpHandlerFactory(IWindsorContainer kernel)
		{
			_kernel = kernel;
		}

		public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
		{
			var handlerTypeName = context.Request.PathInfo.Trim('/') + "Handler";
			return _kernel.Resolve<IHttpHandler>(handlerTypeName);
		}

		public void ReleaseHandler(IHttpHandler handler)
		{
			_kernel.Release(handler);
		}
	}
}
