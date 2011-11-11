using Microsoft.Practices.Unity;
using SPBaseDemo.CONTROLTEMPLATES.SPBaseDemo.Shared;

namespace SPBaseDemo.Infrastructure.Container.Configurations
{
	public class WebItemsInstallator : IContainerInstallator
	{
		public void InstallDependencies(Microsoft.Practices.Unity.IUnityContainer container)
		{
			//need to register controls to make sure they will have properties injected
			container.RegisterType<SPScriptLinkControl>();
		}
	}
}
