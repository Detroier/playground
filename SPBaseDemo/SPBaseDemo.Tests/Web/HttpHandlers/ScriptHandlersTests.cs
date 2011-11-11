using System;
using NUnit.Framework;
using SPBaseDemo.Web.HttpHandlers;
using System.Web;
using Moq;

namespace SPBaseDemo.Tests.Web.HttpHandlers
{
	[TestFixture]
	public class ScriptHandlersTests
	{
		private string[] _fileLocationsPaths;

		[SetUp]
		public void Setup()
		{
			_fileLocationsPaths = GetFileLocationsPaths();
		}

		[Test]
		public void CanGetJavaScriptFiles()
		{
			var handler = new JsHandler(_fileLocationsPaths);

			var mockContext = new Mock<HttpContextBase>();
			var mockRequest = new Mock<HttpRequestBase>();
			var mockResponse = new Mock<HttpResponseBase>();
			var mockCache = new Mock<HttpCachePolicyBase>();

			mockRequest.Setup(x => x["files"]).Returns("test_js_file.js,test_js_file2.js");

			mockResponse.Setup(x => x.Headers).Returns(new System.Collections.Specialized.NameValueCollection());
			mockResponse.Setup(x => x.Cache).Returns(mockCache.Object);

			//there is a problem with this terrible property VaryByParams
			//mockCache.Setup(x => x.VaryByParams).Returns(new HttpCacheVaryByParams());

			mockContext.Setup(x => x.Request).Returns(mockRequest.Object);
			mockContext.Setup(x => x.Response).Returns(mockResponse.Object);

			mockResponse.Setup(x => x.Write(It.IsAny<string>()))
				.Callback<string>(x =>
				{
					Assert.IsNotNullOrEmpty(x, "Merged file content is empty");
				});


			handler.ProcessRequest(mockContext.Object);

			mockResponse.VerifySet(x => x.ContentType, "Content type should be set at least once");
			mockResponse.Verify(x => x.Write(It.IsAny<string>()), "Write method should be called at least once");
		}

		private string[] GetFileLocationsPaths()
		{
			var pathToTestResources = Environment.CurrentDirectory + @"\TestResources\";
			//path to files, which are always present
			var fileLocations = new string[]{
				pathToTestResources
			};
			return fileLocations;
		}
	}
}
