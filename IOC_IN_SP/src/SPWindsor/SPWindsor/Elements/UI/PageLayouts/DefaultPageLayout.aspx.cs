using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPWindsor.Presenters;

namespace SPWindsor.Elements.UI.PageLayouts
{
	public partial class DefaultPageLayout : SPWindsor.Infrastructure.BaseClassesWithInjection.InjectableLayoutPageBase
	{

		public IDefaultPageLayoutPresenter Presenter { get; set; }
		protected Label lblHelloWorld;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Presenter.FillControls(lblHelloWorld);
		}

	}
}
