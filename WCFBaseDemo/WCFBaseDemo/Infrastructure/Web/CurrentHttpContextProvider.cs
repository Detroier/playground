using System.Web;

namespace WCFBaseDemo.Infrastructure.Web
{
	public class CurrentHttpContextProvider : ICurrentHttpContextProvider
	{
		public HttpContextBase GetCurrentContext()
		{
			return new HttpContextWrapper(HttpContext.Current);
		}
	}
}
