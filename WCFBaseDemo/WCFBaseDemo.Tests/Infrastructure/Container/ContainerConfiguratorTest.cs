using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFBaseDemo.Infrastructure.Container;

namespace WCFBaseDemo.Tests.Infrastructure.Container
{
	[TestClass]
	public class ContainerConfiguratorTest
	{

		[TestMethod]
		public void CanConfigureContainer()
		{
			using (var container = new UnityContainer())
			{
				var containerConfigurator = new ContainerConfigurator(container, new IContainerInstaller[] { new TestContainerInstaller() });
				containerConfigurator.ConfigureContainer();

				var resolvedMock = container.Resolve<IMock>();
				Assert.IsTrue(container.Registrations.FirstOrDefault(x => x.MappedToType == typeof(ConcreteMock)) != null, "Concreate mock should be registered");
				Assert.IsNotNull(resolvedMock, "Mock shouldn't be null");
			}
		}
	}

	public class TestContainerInstaller : IContainerInstaller
	{
		public void InstallDependencies(IUnityContainer container)
		{
			container.RegisterType<IMock, ConcreteMock>();
		}
	}

	public interface IMock
	{

	}

	public class ConcreteMock : IMock
	{
	}
}
