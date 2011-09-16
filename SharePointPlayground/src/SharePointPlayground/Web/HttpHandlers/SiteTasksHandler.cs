using System.Web;
using SharePointPlayground.Helpers.SharePoint;
using SharePointPlayground.Infrastructure.HttpHandlers;
using SharePointPlayground.Queries;

namespace SharePointPlayground.Web.HttpHandlers
{
	public class SiteTasksHandler : JSONResultHandler
	{
		private ICurrentSiteAccesor _currentSiteAccesor;
		private ICurrentUserAccesor _currentUserAccesor;
		private ILastTasksByUserQuery _queryToUse;


		public SiteTasksHandler(ICurrentSiteAccesor currentSiteAccesor, ICurrentUserAccesor currentUserAccesor, ILastTasksByUserQuery query)
			: base()
		{
			_currentSiteAccesor = currentSiteAccesor;
			_currentUserAccesor = currentUserAccesor;
			_queryToUse = query;
		}

		protected override object ExecuteRequest(HttpRequest request)
		{
			var result = _queryToUse.GetLastTasksForUser(_currentSiteAccesor.GetSite(), _currentUserAccesor.GetUser(), 5);
			return result;
		}
	}
}
