using WCFBaseDemo.Infrastructure.WCF;

namespace WCFBaseDemo.Host.Infrastructure.WCF
{
	public class UnityBehaviorExtensionElement : AbstractUnityBehaviorExtensionElement<UnityServiceBehavior>
	{
		protected override UnityServiceBehavior GetBehavior()
		{
			return new UnityServiceBehavior();
		}
	}
}