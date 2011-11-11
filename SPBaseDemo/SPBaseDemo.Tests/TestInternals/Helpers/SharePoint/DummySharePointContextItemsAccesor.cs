using Microsoft.SharePoint;
using SPBaseDemo.Helpers.SharePoint;

namespace SPBaseDemo.Tests.TestInternals.Helpers.SharePoint
{
	public class DummySharePointContextItemsAccesor : ISharePointContextItemsAccesor
	{
		private SPSite _siteToUse;

		public DummySharePointContextItemsAccesor(SPSite siteToUse)
		{
			_siteToUse = siteToUse;
		}

		public Microsoft.SharePoint.SPSite GetCurrentSite()
		{
			return _siteToUse;
		}

		public Microsoft.SharePoint.SPWeb GetCurrentWeb()
		{
			return _siteToUse.RootWeb;
		}

		public Microsoft.SharePoint.SPUser CurrentUser()
		{
			return _siteToUse.RootWeb.Users[0];
		}
	}
}
