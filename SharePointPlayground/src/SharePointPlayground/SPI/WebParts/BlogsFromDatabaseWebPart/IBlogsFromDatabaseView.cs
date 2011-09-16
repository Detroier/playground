using System;
namespace SharePointPlayground.SPI.WebParts.BlogsFromDatabaseWebPart
{
	public interface IBlogsFromDatabaseView
	{
		int AdditionalPostsCount { set; }
		System.Collections.Generic.IEnumerable<SharePointPlayground.Model.Post> Posts { set; }
	}
}
