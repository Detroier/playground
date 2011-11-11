using System.Web;
using WCFBaseDemo.Infrastructure.Web;

namespace WCFBaseDemo.Tests.TestInternals
{
	public class MockContextProvider : ICurrentHttpContextProvider
	{
		private HttpContextBase _context;

		public MockContextProvider(HttpContextBase context)
		{
			_context = context;
		}

		public HttpContextBase GetCurrentContext()
		{
			return _context;
		}
	}
}
