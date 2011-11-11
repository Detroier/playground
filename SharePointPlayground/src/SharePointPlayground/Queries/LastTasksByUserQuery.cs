using System.Collections.Generic;
using System.Data;
using Microsoft.SharePoint;
using SharePointPlayground.Mapping;
using SharePointPlayground.Queries.SP;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Queries
{
	public class LastTasksByUserQuery : ILastTasksByUserQuery
	{
		private IMapper<DataTable, List<TaskListItemViewModel>> _resultMapper;

		public LastTasksByUserQuery(IMapper<DataTable, List<TaskListItemViewModel>> resultMapper)
		{
			_resultMapper = resultMapper;
		}

		public IEnumerable<TaskListItemViewModel> GetLastTasksForUser(SPSite rootOfSearch, SPUser user, int count)
		{
			DataTable dataTable = new SPSiteDataQueryExecutor(
								"<Lists ServerTemplate=\"107\" />",
								@"<FieldRef Name=""ID"" /><FieldRef Name=""Title"" /><FieldRef Name=""Status"" /><FieldRef Name=""GUID"" /><FieldRef Name=""DueDate"" /><FieldRef Name=""StartDate"" /><FieldRef Name=""Priority"" />",
								string.Format(@"<OrderBy><FieldRef Name=""Created"" Ascending=""false"" /></OrderBy><Where><Eq><FieldRef Name='AssignedTo' /><Value Type='Text'>{0}</Value></Eq></Where>", user.Name),
								"<Webs Scope='SiteCollection'>",
								count).ExecuteQuery(rootOfSearch.RootWeb);


			var result = _resultMapper.Map(dataTable);
			return result;
		}
	}
}
