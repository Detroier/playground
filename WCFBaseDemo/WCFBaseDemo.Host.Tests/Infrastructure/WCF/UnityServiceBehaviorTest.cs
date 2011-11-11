using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using System.ServiceModel;
using WCFBaseDemo.Host.Infrastructure.WCF;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Moq;


namespace WCFBaseDemo.Host.Tests.Infrastructure.WCF
{
	[TestClass]
	public class UnityServiceBehaviorTest
	{
		[TestMethod]
		public void CanProvideInstanceForHost()
		{
			using (var container = new UnityContainer())
			{
				//var serviceMock = new Mock<ITestService>();
				//container.RegisterInstance<ITestService>(serviceMock.Object);
				container.RegisterInstance<TestService>(new TestService("Test"));

				var serviceHost = new ServiceHost(typeof(TestService), new Uri("http://localhost:55551/TestService"));
				serviceHost.Description.Behaviors.Add(new UnityServiceBehavior(container));

				Binding binding = new WSHttpBinding();
				var address = new EndpointAddress("http://localhost:55551/TestService/MyService");
				var endpoint = serviceHost
					.AddServiceEndpoint(typeof(ITestService), binding, address.Uri);

				var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
				serviceHost.Description.Behaviors.Add(smb);

				var proxy = ChannelFactory<ITestService>.CreateChannel(binding, endpoint.Address);

				serviceHost.Open();

				var result = proxy.TestOperation();

				serviceHost.Close();

				Assert.AreEqual("Test", result);
			}
		}
	}

	[ServiceContract]
	public interface ITestService
	{
		[OperationContract]
		string TestOperation();
	}

	public class TestService : ITestService
	{
		private string _output;

		public TestService(string output)
		{
			_output = output;
		}

		public string TestOperation()
		{
			return _output;
		}
	}
}
