using System.Web.UI.WebControls;
using WebApp.Services;

namespace WebApp.Presenters
{
    public class DefaultPagePresenter : IDefaultPagePresenter
    {
        private ITasksService _tasksService;
        private IEmployeService _employeService;

        public DefaultPagePresenter(ITasksService tasksService, IEmployeService employeService)
        {
            _tasksService = tasksService;
            _employeService = employeService;
        }

        public void BindDataToControls(Repeater tasksList, Repeater performersList)
        {
            tasksList.DataSource = _tasksService.GetRecentTasks(5);
            performersList.DataSource = _employeService.GetTopPerformers(5);

            tasksList.DataBind();
            performersList.DataBind();
        }
    }
}