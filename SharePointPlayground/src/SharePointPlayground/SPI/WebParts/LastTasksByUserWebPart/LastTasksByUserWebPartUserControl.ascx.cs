using System;
using System.Web.UI.WebControls;

using SharePointPlayground.Infrastructure.BaseClassesWithInjection;
using SharePointPlayground.Presenters;
using SharePointPlayground.ViewModels;
using SharePointPlayground.Helpers;

namespace SharePointPlayground.SPI.WebParts.LastTasksByUserWebPart
{
	public partial class LastTasksByUserWebPartUserControl : InjectableUserControl
	{
		public ILastTasksByUserPresenter Presenter { get; set; }

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			_repTasks.DataSource = Presenter.GetLastTasks();
			_repTasks.DataBind();
		}
	}
}