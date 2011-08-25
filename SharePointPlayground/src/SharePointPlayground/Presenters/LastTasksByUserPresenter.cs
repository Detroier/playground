using Microsoft.SharePoint;
using SharePointPlayground.Helpers.SharePoint;
using SharePointPlayground.Queries;

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

		public System.Collections.Generic.IEnumerable<ViewModels.TaskListItemViewModel> GetLastTasks()
		{
			return _query.GetLastTasksForUser(_siteToSearch, _userToSearch, 5);
		}
	}
}
