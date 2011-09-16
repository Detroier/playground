using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharePointPlayground.ViewModels;
using SharePointPlayground.Queries;
using SharePointPlayground.Helpers.SharePoint;
using System.Collections;
using Microsoft.SharePoint.Client.Services;
using System.ServiceModel.Activation;
using SharePointPlayground.Infrastructure.WCF;
using System.ServiceModel.Web;

namespace SharePointPlayground.Services
{

	[BasicHttpBindingServiceMetadataExchangeEndpoint]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[WindsorServiceBehavior]
	public class SiteTasksService : SharePointPlayground.Services.ISiteTasksService
	{
		private ILastTasksByUserQuery _query;
		private ICurrentUserAccesor _userAccesor;
		private ICurrentSiteAccesor _siteAccesor;

		public SiteTasksService(ILastTasksByUserQuery query, ICurrentSiteAccesor siteAccesor, ICurrentUserAccesor userAccesor)
		{
			_query = query;
			_siteAccesor = siteAccesor;
			_userAccesor = userAccesor;
		}

		[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
		public TaskListItemViewModel[] GetCurrentUserTasks(int count)
		{
			return _query.GetLastTasksForUser(_siteAccesor.GetSite(), _userAccesor.GetUser(), count).ToArray();
		}

	}
}
