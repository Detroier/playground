using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castle.Windsor;
using SharePointPlayground.Infrastructure.Container;

namespace SharePointPlayground.Infrastructure.HttpHandlers
{
	public class InfrastructureHandler : IHttpHandler
	{
		private IWindsorContainer _kernel;

		public InfrastructureHandler()
			: this(ContainerHelper.Kernel)
		{
		}

		public InfrastructureHandler(IWindsorContainer kernel)
		{
			_kernel = kernel;
		}

		public bool IsReusable
		{
			get { return false; ; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		public void ProcessRequest(HttpContext context)
		{
			IHttpHandler handler = GetHandlerToInvoke(context);

			handler.ProcessRequest(context);

			ReleaseHandler(handler);
		}

		private void ReleaseHandler(IHttpHandler handler)
		{
			_kernel.Release(handler);
		}

		private IHttpHandler GetHandlerToInvoke(HttpContext context)
		{
			var handlerTypeName = context.Request.PathInfo.Trim('/') + "Handler";
			return _kernel.Resolve<IHttpHandler>(handlerTypeName);
		}
	}
}