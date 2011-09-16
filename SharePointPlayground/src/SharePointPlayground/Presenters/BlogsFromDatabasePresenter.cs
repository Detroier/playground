using SharePointPlayground.Commands;
using SharePointPlayground.Queries;
using SharePointPlayground.SPI.WebParts.BlogsFromDatabaseWebPart;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Presenters
{
	public class BlogsFromDatabasePresenter : SharePointPlayground.Presenters.IBlogsFromDatabasePresenter
	{
		private IPageOfPostsQuery _query;
		private IAddPostCommand _addPostCommand;
		private IDeletePostCommand _deletePostCommand;

		public BlogsFromDatabasePresenter(IPageOfPostsQuery query, IAddPostCommand addPostCommand, IDeletePostCommand deletePostCommand)
		{
			_query = query;
			_addPostCommand = addPostCommand;
			_deletePostCommand = deletePostCommand;
		}

		public void InitializeView(IBlogsFromDatabaseView view)
		{
			var results = _query.GetPosts(1, 10);

			view.Posts = results;
			view.AdditionalPostsCount = results.TotalCountOfItems - results.Count;
		}

		public void AddPost(PostInsertViewModel viewModel)
		{
			_addPostCommand.Execute(viewModel);
		}

		public void DeletePost(int postId)
		{
			_deletePostCommand.Execute(postId);
		}
	}
}
