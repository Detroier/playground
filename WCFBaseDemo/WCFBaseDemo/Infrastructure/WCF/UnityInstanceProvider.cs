using System;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace WCFBaseDemo.Infrastructure.WCF
{
	public class UnityInstanceProvider : IInstanceProvider
	{
		private Type _serviceType;
		private IUnityContainer _container;

		public UnityInstanceProvider(IUnityContainer container, Type type)
		{
			_container = container;
			_serviceType = type;
		}

		public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
		{
			//todo: what about message?
			return GetInstance(instanceContext);
		}

		public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
		{
			return _container.Resolve(_serviceType);
		}

		public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
		{
		}
	}
}
