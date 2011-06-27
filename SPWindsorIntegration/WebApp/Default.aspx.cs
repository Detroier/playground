using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Infrastructure.BaseClassesWithInjection;
using WebApp.Presenters;

namespace WebApp
{
    public partial class Default : InjectablePage
    {
        IDefaultPagePresenter _presenter;

    }
}