using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using WCFBaseDemo.Host.DeploymentTests.ServiceReferences;

namespace WCFBaseDemo.Host.DeploymentTests
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class ServicesOnLocalIISTest
	{
		[TestMethod]
		public void CanInvokeDummyService()
		{
			var client = new DummyServiceClient();

			var hello = client.SayHello("Marian");

			Assert.IsTrue(string.IsNullOrEmpty(hello) == false, "Return message cannot be null or empty");
		}
	}
}
