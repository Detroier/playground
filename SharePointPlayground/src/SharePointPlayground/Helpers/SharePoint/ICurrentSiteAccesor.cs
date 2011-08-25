using Microsoft.SharePoint;

namespace SharePointPlayground.Helpers.SharePoint
{
	public interface ICurrentSiteAccesor
	{
		SPSite GetSite();
	}
}
