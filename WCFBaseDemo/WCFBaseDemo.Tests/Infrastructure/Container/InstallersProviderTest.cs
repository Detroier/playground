using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFBaseDemo.Infrastructure.Container;


namespace WCFBaseDemo.Tests.Infrastructure.Container
{
	[TestClass]
	public class InstallersProviderTest
	{
		[TestMethod]
		public void CanLocateInstallersInAssembly()
		{
			var installersProvider = new InstallersProvider(new Assembly[] { GetType().Assembly });
			var results = installersProvider.GetInstallers();

			Assert.IsNotNull(results, "At least one installer should be present");
			Assert.IsNotNull(results.FirstOrDefault(x => x.GetType() == typeof(DummyContainerInstaller)), "DummyContainerInstaller should be present");
		}
	}

	public class DummyContainerInstaller : IContainerInstaller
	{
		public void InstallDependencies(Microsoft.Practices.Unity.IUnityContainer container)
		{

		}
	}
}
