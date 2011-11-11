using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WCFBaseDemo.Infrastructure.Data;
using WCFBaseDemo.Infrastructure.Web;
using WCFBaseDemo.Tests.TestInternals;

namespace WCFBaseDemo.Tests.Infrastructure.Data
{
	[TestClass]
	public class HttpContextTrackingFactoryTest
	{
		[TestMethod]
		public void CanProvideContext()
		{
			IDictionary dictionary = new Dictionary<string, object>();

			var httpContextMock = new Mock<HttpContextBase>();
			httpContextMock.Setup(x => x.Items).Returns(dictionary);

			ICurrentHttpContextProvider contextProvider = new MockContextProvider(httpContextMock.Object);

			var factory = new HttpContextTrackingFactory<DbContext>(contextProvider, () => new DbContext("Test"), "contextKey");

			var context1 = factory.GetContext();
			var context2 = factory.GetContext();

			Assert.IsNotNull(context1, "Context shouldn't be null");
			Assert.AreSame(context1, context2, "Both instances returned fomr factory should be same");

			context1.Dispose();			
		}
	}
}
