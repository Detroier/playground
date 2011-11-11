using System;
using System.Data.Entity;
using WCFBaseDemo.Infrastructure.Web;

namespace WCFBaseDemo.Infrastructure.Data
{
	public class HttpContextTrackingFactory<T> : InDictionaryTrackingContextFactory<T> where T : DbContext
	{
		public HttpContextTrackingFactory(ICurrentHttpContextProvider currentContextProvider, Func<T> createNewContext, string trackingKey)
			: base(() => currentContextProvider.GetCurrentContext().Items, createNewContext, trackingKey)
		{
		}
	}
}
