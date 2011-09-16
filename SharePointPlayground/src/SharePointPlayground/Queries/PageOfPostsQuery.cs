using System.Linq;
using NHibernate;
using SharePointPlayground.Model;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Queries
{
	public class PageOfPostsQuery : SharePointPlayground.Queries.IPageOfPostsQuery
	{
		private ISession _session;

		public PageOfPostsQuery(ISessionFactory sessionFactory)
		{
			_session = sessionFactory.GetCurrentSession();
		}

		public PageOfItems<Post> GetPosts(int page, int pageSize)
		{
			var postsQuery = _session.QueryOver<Post>();
			var futurePostsQuery = postsQuery
									.OrderBy(x => x.CreatedAt).Desc
									.Skip((page - 1) * pageSize)
									.Take(pageSize)
									.Future();
			var futurePostCountQuery = postsQuery.ToRowCountQuery().FutureValue<int>();

			var result = new PageOfItems<Post>(futurePostsQuery.ToList(), page, futurePostCountQuery.Value, pageSize);
			return result;
		}
	}
}
