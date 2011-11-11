using Microsoft.Practices.Unity;

namespace SPBaseDemo.Infrastructure.Container.Configurations
{
	/// <summary>
	/// Unity doesn't have anything similar to windsor installers, so this interface is here to make configuration more visible.
	/// </summary>
	public interface IContainerInstallator
	{
		void InstallDependencies(IUnityContainer container);
	}
}
