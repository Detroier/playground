using Microsoft.SharePoint;
using SharePointPlayground.Helpers.SharePoint;
using SharePointPlayground.Queries;
using SharePointPlayground.SPI.WebParts.LastTasksByUserWebPart;

namespace SharePointPlayground.Presenters
{
	public class LastTasksByUserPresenter : SharePointPlayground.Presenters.ILastTasksByUserPresenter
	{
		private ILastTasksByUserQuery _query;
		private SPUser _userToSearch;
		private SPSite _siteToSearch;

		public LastTasksByUserPresenter(ILastTasksByUserQuery query, ICurrentSiteAccesor currentSiteAccesor, ICurrentUserAccesor currentUserAccesor)
		{
			_query = query;
			_siteToSearch = currentSiteAccesor.GetSite();
			_userToSearch = currentUserAccesor.GetUser();
		}

		public void InitView(ILastTasksByUserView view)
		{
			var taskList = _query.GetLastTasksForUser(_siteToSearch, _userToSearch, 5);

			view.Tasks = taskList;
		}

		public void DeleteTaskByItemId(int itemId)
		{
			//now..delete will need something more than Item ID! => we will also need list etc => s..lets select it and be done, then find site.List.Item => and delete it
		}
	}
}
