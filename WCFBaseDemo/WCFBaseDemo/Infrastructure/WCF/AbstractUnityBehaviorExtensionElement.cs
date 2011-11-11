using System;
using System.ServiceModel.Configuration;

namespace WCFBaseDemo.Infrastructure.WCF
{
	public abstract class AbstractUnityBehaviorExtensionElement<T> : BehaviorExtensionElement
	{
		public override Type BehaviorType
		{
			get { return typeof(T); }
		}

		protected override object CreateBehavior()
		{
			return GetBehavior();
		}

		protected abstract T GetBehavior();
	}
}
