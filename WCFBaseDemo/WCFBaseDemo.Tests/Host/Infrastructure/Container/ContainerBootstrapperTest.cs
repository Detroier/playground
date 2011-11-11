using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFBaseDemo.Host.Infrastructure.Container;
using WCFBaseDemo.Infrastructure.Web;

namespace WCFBaseDemo.Tests.Host.Infrastructure.Container
{
	[TestClass]
	public class ContainerBootstrapperTest
	{
		private IUnityContainer _container;

		[TestInitialize]
		public void Initialize()
		{
			_container = ContainerBootstrapper.BootstrapContainer();
		}

		[TestMethod]
		public void CanConfigureContainer()
		{
			var registrationsCount = _container.Registrations.Count();
			Assert.IsTrue(registrationsCount > 0, "Has to contain at least some registrations");
		}

		[TestMethod]
		public void CanProvideCorrectHttpContextProvider()
		{
			var instanceOfProvider = _container.Resolve<ICurrentHttpContextProvider>();
			Assert.IsTrue(instanceOfProvider.GetType() == typeof(CurrentHttpContextProvider), "Has to be web provider");
		}

		[TestCleanup]
		public void Cleanup()
		{
			_container.Dispose();
		}
	}
}
