using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using SPBaseDemo.Infrastructure.Container;
using SPBaseDemo.Infrastructure.Container.Configurations;

namespace SPBaseDemo.Tests.Infrastructure.Container
{
	[TestFixture]
	public class ContainerConfiguratorTests
	{
		[Test]
		public void CanConfigureContainerWithDefaultSettings()
		{
			Assert.DoesNotThrow(() =>
			{
				IUnityContainer container = new ContainerConfigurator().ConfigureContainer();
			});
		}

		/// <summary>
		/// Determines whether [contains HTTP handlers].
		/// </summary>
		[Test]
		public void ContainsHttpHandlers()
		{
			var container = new ContainerConfigurator().ConfigureContainer();
			var handlers = container.ResolveAll<IHttpHandler>();

			Assert.IsNotNull(handlers, "At least some handlers need to be registered");
			Assert.GreaterOrEqual(handlers.Count(), 1, "One or more handlers should be registered");

			var jsHandler = container.Resolve<IHttpHandler>("JsHandler");
			Assert.IsNotNull(jsHandler, "JsHandler should be registered");
		}
		

		[Test]
		public void DoesInstallatorFactoryReturnInstallators()
		{
			var factory = new InstallatorsFactory();
			var installators = factory.GetInstallators();

			Assert.GreaterOrEqual(installators.Length, 1, "At least some installators should be returned");
		}

	}
}
