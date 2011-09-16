using SharePointPlayground.Infrastructure.HttpHandlers;
using SharePointPlayground.Queries;
using Castle.Core.Logging;

namespace SharePointPlayground.Web.HttpHandlers
{
	public class PostsHandler : JSONResultHandler
	{
		private IPageOfPostsQuery _queryToUse;
		private ILogger _logger;

		public PostsHandler(ILogger logger, IPageOfPostsQuery queryToUse)
		{
			_queryToUse = queryToUse;
			_logger = logger;
		}

		protected override object ExecuteRequest(System.Web.HttpRequest request)
		{
			_logger.Fatal("Posts handler called");
			return _queryToUse.GetPosts(1, 10);
		}
	}
}
