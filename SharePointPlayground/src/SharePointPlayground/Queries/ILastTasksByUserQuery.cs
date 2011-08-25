using System.Collections.Generic;
using Microsoft.SharePoint;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Queries
{
	public interface ILastTasksByUserQuery
	{
		IEnumerable<TaskListItemViewModel> GetLastTasksForUser(SPSite rootOfSearch, SPUser user, int count);
	}
}
