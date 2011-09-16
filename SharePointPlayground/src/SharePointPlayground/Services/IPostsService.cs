using System.ServiceModel;
using SharePointPlayground.Model;

namespace SharePointPlayground.Services
{
	[ServiceContract]
	public interface IPostsService
	{
		[OperationContract]
		Post[] GetPosts(int page);
	}
}
