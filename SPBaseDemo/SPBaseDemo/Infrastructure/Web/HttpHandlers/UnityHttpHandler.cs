using System.Web;
using Microsoft.Practices.Unity;
using SPBaseDemo.Infrastructure.Container;

namespace SPBaseDemo.Infrastructure.Web.HttpHandlers
{
	/// <summary>
	/// In normal circumstances, httphandler factory would be used. But that would mean adding extra line into web.config. Proposed solution is to use sharepoint isapi folder
	/// to host this handler and serve other handlers with it.
	/// 
	/// This is one of entry points to application, so it can hold reference to the container.
	/// </summary>
	public class UnityHttpHandler : IHttpHandler
	{
		public bool IsReusable
		{
			get { return true; }
		}

		/// <summary>
		/// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
		/// 		
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
		public void ProcessRequest(HttpContext context)
		{
			var handlerTypeName = context.Request.PathInfo.Trim('/') + "Handler";

			var handlerToExecute = GetHandlerToExecute(handlerTypeName);
			
			handlerToExecute.ProcessRequest(context);
		}

		private IHttpHandler GetHandlerToExecute(string handlerTypeName)
		{
			var container = ContainerLocator.Container;
			
			var handlerToExecute = container.Resolve<IHttpHandler>(handlerTypeName);

			return handlerToExecute;
		}
	}
}
