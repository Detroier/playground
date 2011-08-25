using System.Collections.Generic;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Presenters
{
	public interface ILastTasksByUserPresenter
	{
		/// <summary>
		/// Gets the last tasks.
		/// </summary>
		/// <returns></returns>
		IEnumerable<TaskListItemViewModel> GetLastTasks();
	}
}
