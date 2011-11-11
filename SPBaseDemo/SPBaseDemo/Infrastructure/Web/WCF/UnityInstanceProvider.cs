using System;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using SPBaseDemo.Infrastructure.Container;

namespace SPBaseDemo.Infrastructure.Web.WCF
{
	public class UnityInstanceProvider : IInstanceProvider
	{
		private IUnityContainer _container;
		private Type _serviceType;

		public UnityInstanceProvider(Type serviceType)
			: this(serviceType, ContainerLocator.Container)
		{
		}

		public UnityInstanceProvider(Type serviceType, IUnityContainer container)
		{
			_container = container;
			_serviceType = serviceType;
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
			//unity doesn't track services, so leave empty
		}
	}
}
