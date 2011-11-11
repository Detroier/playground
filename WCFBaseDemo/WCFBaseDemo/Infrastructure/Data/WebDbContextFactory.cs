using System;
using System.Data.Entity;
using WCFBaseDemo.Infrastructure.Web;

namespace WCFBaseDemo.Infrastructure.Data
{
	public class WebDbContextFactory<T> : IDbContextFactory<T> where T : DbContext
	{
		private ICurrentHttpContextProvider _httpContextProvider;
		private string _trackingKey;

		public WebDbContextFactory(ICurrentHttpContextProvider httpContextProvider, string trackingKey)
		{
			_httpContextProvider = httpContextProvider;
			_trackingKey = trackingKey;
		}

		public T GetContext()
		{
			var context = _httpContextProvider.GetCurrentContext();
			if (context.Items.Contains(_trackingKey) == false)
			{
				throw new ApplicationException("DbContext not initialized");
			}
			var dbContext = context.Items[_trackingKey] as T;
			if (dbContext == null)
			{
				throw new ApplicationException("Incorrect DbContext found in HttpContext.Items");
			}
			return dbContext;
		}	
	}
}
