using Microsoft.SharePoint;

namespace SharePointPlayground.Helpers.SharePoint
{
	public interface ICurrentUserAccesor
	{
		SPUser GetUser();
	}
}
