using System.Collections.Generic;
using System.Data;
using Microsoft.SharePoint;
using SharePointPlayground.Helpers;
using SharePointPlayground.Queries.SP;
using SharePointPlayground.ViewModels;
using System;

namespace SharePointPlayground.Queries
{
	public class LastTasksByUserQuery : ILastTasksByUserQuery
	{
		public IEnumerable<TaskListItemViewModel> GetLastTasksForUser(SPSite rootOfSearch, SPUser user, int count)
		{
			DataTable dataTable = new SPSiteDataQueryExecutor(
								"<Lists ServerTemplate=\"107\" />",
								@"<FieldRef Name=""ID"" /><FieldRef Name=""Title"" /><FieldRef Name=""Status"" /><FieldRef Name=""GUID"" /><FieldRef Name=""DueDate"" /><FieldRef Name=""StartDate"" /><FieldRef Name=""Priority"" />",
								string.Format(@"<OrderBy><FieldRef Name=""Created"" Ascending=""false"" /></OrderBy><Where><Eq><FieldRef Name='AssignedTo' /><Value Type='Text'>{0}</Value></Eq></Where>", user.Name),
								"<Webs Scope='SiteCollection'>",
								count).ExecuteQuery(rootOfSearch.RootWeb);


			var result = dataTable.MapTo<TaskListItemViewModel>();
			return result;
		}
	}
}
