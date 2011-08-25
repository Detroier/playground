using System.Collections.Generic;
using Microsoft.SharePoint.Utilities;

namespace SharePointPlayground.Presenters
{
	public class LastTasksByUserPresenterWithScope : ILastTasksByUserPresenter
	{
		private ILastTasksByUserPresenter _innerPresenter;

		public LastTasksByUserPresenterWithScope(ILastTasksByUserPresenter innerPresenter)
		{
			_innerPresenter = innerPresenter;
		}

		public IEnumerable<ViewModels.TaskListItemViewModel> GetLastTasks()
		{
			using (SPMonitoredScope monitoredScope = new SPMonitoredScope("LastTasksByUserPresenter -> GetTasksMethod"))
			{
				return _innerPresenter.GetLastTasks();
			}
		}
	}
}
