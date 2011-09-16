using System;
using System.Web.UI.WebControls;

using SharePointPlayground.Infrastructure.BaseClassesWithInjection;
using SharePointPlayground.Presenters;
using SharePointPlayground.ViewModels;
using SharePointPlayground.Helpers;
using System.Collections.Generic;

namespace SharePointPlayground.SPI.WebParts.LastTasksByUserWebPart
{
	public partial class LastTasksByUserWebPartUserControl : InjectableUserControl, ILastTasksByUserView
	{
		/// <summary>
		/// Every view should have presenter (1 or more if required)
		/// </summary>
		public ILastTasksByUserPresenter Presenter { get; set; }

		/// <summary>
		/// Define seters for properties, that will be used to set values to controls. we will need a bit more complicated example!
		/// </summary>
		public IEnumerable<TaskListItemViewModel> Tasks
		{
			set
			{
				_repTasks.DataSource = value;
				_repTasks.DataBind();
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			_repTasks.ItemCommand += new RepeaterCommandEventHandler(_repTasks_ItemCommand);

			Presenter.InitView(this);
		}

		void _repTasks_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			//handle some delete
			if (e.CommandName == "Delete")
			{
				int itemId = (int)e.CommandArgument;
				Presenter.DeleteTaskByItemId(itemId);
			}

		}
	}
}