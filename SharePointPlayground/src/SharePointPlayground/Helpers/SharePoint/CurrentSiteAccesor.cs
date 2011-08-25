using Microsoft.SharePoint;

namespace SharePointPlayground.Helpers.SharePoint
{
	/// <summary>
	/// Provides access to current site, uses SPContext.Current.Site
	/// Makes testing stuff much easier.
	/// </summary>
	public class CurrentSiteAccesor : ICurrentSiteAccesor
	{
		public Microsoft.SharePoint.SPSite GetSite()
		{
			return SPContext.Current.Site;
		}
	}
}
