using Microsoft.Practices.Unity;

namespace WCFBaseDemo.Infrastructure.Container
{
	public interface IContainerInstaller
	{
		void InstallDependencies(IUnityContainer container);
	}
}
