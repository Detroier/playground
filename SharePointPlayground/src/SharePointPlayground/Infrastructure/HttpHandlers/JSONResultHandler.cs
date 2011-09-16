using System.Web;
using System.Web.Script.Serialization;

namespace SharePointPlayground.Infrastructure.HttpHandlers
{
	public abstract class JSONResultHandler : IHttpHandler
	{
		public bool IsReusable
		{
			get { return false; }
		}

		public void ProcessRequest(HttpContext context)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			var resultOfExecution = ExecuteRequest(context.Request);
			var contentToOutput = serializer.Serialize(resultOfExecution);

			//context.Response.ContentType = "application/json";
			context.Response.ContentType = "text/plain";
			context.Response.Write(contentToOutput);
		}

		protected abstract object ExecuteRequest(HttpRequest request);
	}
}
