using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Castle.Core.Logging;
using Microsoft.SharePoint.Client.Services;
using SharePointPlayground.Infrastructure.WCF;
using SharePointPlayground.Model;
using SharePointPlayground.Queries;

namespace SharePointPlayground.Services
{
	[BasicHttpBindingServiceMetadataExchangeEndpoint]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[WindsorServiceBehavior]
	public class PostsService : SharePointPlayground.Services.IPostsService
	{
		private IPageOfPostsQuery _queryToUse;
		private ILogger _logger;

		public PostsService(ILogger logger, IPageOfPostsQuery queryToUse)
		{
			_queryToUse = queryToUse;
			_logger = logger;
		}

		[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
		public Post[] GetPosts(int page)
		{
			_logger.Debug("VERY IMPORTANT - CALLED SERVICE !");
			return _queryToUse.GetPosts(page, 2).ToArray();
		}
	}
}
