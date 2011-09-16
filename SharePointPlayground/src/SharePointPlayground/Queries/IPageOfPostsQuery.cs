using System;
namespace SharePointPlayground.Queries
{
	public interface IPageOfPostsQuery
	{
		SharePointPlayground.ViewModels.PageOfItems<SharePointPlayground.Model.Post> GetPosts(int page, int pageSize);
	}
}
