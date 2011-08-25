using Microsoft.SharePoint;

namespace SharePointPlayground.Helpers.SharePoint
{
	public class CurrentUserAccesor : ICurrentUserAccesor
	{
		public Microsoft.SharePoint.SPUser GetUser()
		{
			return SPContext.Current.Web.CurrentUser;
		}
	}
}
