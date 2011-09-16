using System;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Presenters
{
	public interface IBlogsFromDatabasePresenter
	{
		void InitializeView(SharePointPlayground.SPI.WebParts.BlogsFromDatabaseWebPart.IBlogsFromDatabaseView view);

		void AddPost(PostInsertViewModel viewModel);

		void DeletePost(int postId);
	}
}
