using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SharePointPlayground.Web.HttpHandlers
{
	public class InvoicesHandler : IHttpHandler
	{
		public bool IsReusable
		{
			get { return false; }
		}

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			context.Response.Write("Hello from Invoice");
		}
	}
}
