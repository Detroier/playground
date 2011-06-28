using System.Web.UI.WebControls;

namespace WebApp.Presenters
{
    public interface IDefaultPagePresenter
    {
        void BindDataToControls(Repeater tasksList, Repeater performersList);
    }
}
