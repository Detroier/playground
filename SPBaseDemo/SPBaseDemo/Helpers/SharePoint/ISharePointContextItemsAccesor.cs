using Microsoft.SharePoint;

namespace SPBaseDemo.Helpers.SharePoint
{
	/// <summary>
	/// Wrapper around SPContext, for easier testing. 
	/// MAybe split this into smaller objects?
	/// </summary>
	public interface ISharePointContextItemsAccesor
	{
		SPSite GetCurrentSite();

		SPWeb GetCurrentWeb();

		SPUser CurrentUser();
	}
}
