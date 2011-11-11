using WCFBaseDemo.Infrastructure.Data;
using WCFBaseDemo.Infrastructure.Web;

namespace WCFBaseDemo.Data
{
	public class WCFBaseDemoDbContextHttpTrackingFactory : HttpContextTrackingFactory<WCFBaseDemoDbContext>
	{
		public WCFBaseDemoDbContextHttpTrackingFactory(ICurrentHttpContextProvider currentHttpContextProvider)
			: base(currentHttpContextProvider, () => new WCFBaseDemoDbContext(), "WCFBaseDemoDbContext")
		{
		}
	}
}
