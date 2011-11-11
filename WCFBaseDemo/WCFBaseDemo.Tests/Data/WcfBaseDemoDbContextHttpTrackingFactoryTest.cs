using System.Collections;
using System.Collections.Generic;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WCFBaseDemo.Data;
using WCFBaseDemo.Infrastructure.Web;
using WCFBaseDemo.Tests.TestInternals;

namespace WCFBaseDemo.Tests.Data
{
	[TestClass]
	public class WcfBaseDemoDbContextHttpTrackingFactoryTest
	{
		[TestMethod]
		public void CanCreateContext()
		{
			IDictionary dictionary = new Dictionary<string, object>();

			var httpContextMock = new Mock<HttpContextBase>();
			httpContextMock.Setup(x => x.Items).Returns(dictionary);

			ICurrentHttpContextProvider contextProvider = new MockContextProvider(httpContextMock.Object);

			var factory = new WCFBaseDemoDbContextHttpTrackingFactory(contextProvider);

			var context = factory.GetContext();
			var context2 = factory.GetContext();

			Assert.IsNotNull(context, "Context cannot be null");
			Assert.AreSame(context, context2, "Both contexts should be same");
		}
	}
}
