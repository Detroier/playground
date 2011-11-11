using System.Web;

namespace SPBaseDemo.Web.HttpHandlers.AbstractHandlers
{
	/// <summary>
	/// Unit testable base class for HttpModules.
	/// </summary>
	public abstract class HttpHandlerBase : IHttpHandler
	{
		/// <summary>
		/// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
		public void ProcessRequest(HttpContext context)
		{
			ProcessRequest(new HttpContextWrapper(context));
		}

		/// <summary>
		/// Processes the request, takse HttpContextBase as a parameter, so it can be provided with mock implementation.
		/// </summary>
		/// <param name="context">The context.</param>
		public abstract void ProcessRequest(HttpContextBase context);

		public abstract bool IsReusable { get; }
	}
}
