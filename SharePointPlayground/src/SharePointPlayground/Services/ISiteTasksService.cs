using System;
using System.ServiceModel;
namespace SharePointPlayground.Services
{
	[ServiceContract]
	public interface ISiteTasksService
	{
		[OperationContract]
		SharePointPlayground.ViewModels.TaskListItemViewModel[] GetCurrentUserTasks(int count);
	}
}
