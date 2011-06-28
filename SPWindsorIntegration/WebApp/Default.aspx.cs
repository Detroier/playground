using System;

using WebApp.Infrastructure.BaseClassesWithInjection;
using WebApp.Presenters;

namespace WebApp
{
    public partial class Default : InjectablePage
    {
        public IDefaultPagePresenter Presenter { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Presenter.BindDataToControls(_repTasks, _repPerformers);
        }
    }
}