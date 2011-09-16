using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SharePointPlayground.Infrastructure.BaseClassesWithInjection;
using SharePointPlayground.Model;
using System.Collections.Generic;
using SharePointPlayground.Presenters;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.SPI.WebParts.BlogsFromDatabaseWebPart
{
	public partial class BlogsFromDatabaseWebPartUserControl : InjectableUserControl, SharePointPlayground.SPI.WebParts.BlogsFromDatabaseWebPart.IBlogsFromDatabaseView
	{

		public IBlogsFromDatabasePresenter Presenter { get; set; }

		public IEnumerable<Post> Posts
		{
			set
			{
				_repPosts.DataSource = value;
				_repPosts.DataBind();
			}
		}

		public int AdditionalPostsCount
		{
			set
			{
				_litAdditionalCount.Text = value.ToString();
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			_btnAddRandomPost.Click += new EventHandler(_btnAddRandomPost_Click);
			_repPosts.ItemCommand += new RepeaterCommandEventHandler(_repPosts_ItemCommand);
		}

		void _repPosts_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "Delete")
			{
				int itemToDeleteId = int.Parse(e.CommandArgument.ToString());
				Presenter.DeletePost(itemToDeleteId);
				Presenter.InitializeView(this);
			}
		}

		void _btnAddRandomPost_Click(object sender, EventArgs e)
		{
			var postInsertModel = new PostInsertViewModel
			{
				Title = DateTime.Now.ToShortDateString(),
				Body = DateTime.Now.ToString()
			};

			Presenter.AddPost(postInsertModel);
			Presenter.InitializeView(this);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!IsPostBack)
			{
				Presenter.InitializeView(this);
			}
		}

	}
}
