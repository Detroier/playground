using Microsoft.SharePoint;

namespace SPBaseDemo.Helpers.SharePoint
{
	public class SharePointContextItemsAccesor : ISharePointContextItemsAccesor
	{
		public Microsoft.SharePoint.SPSite GetCurrentSite()
		{
			return SPContext.Current.Site;
		}

		public Microsoft.SharePoint.SPWeb GetCurrentWeb()
		{
			return SPContext.Current.Web;
		}

		public Microsoft.SharePoint.SPUser CurrentUser()
		{
			return SPContext.Current.Web.CurrentUser;
		}
	}
}
