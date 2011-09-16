using System;
using System.ServiceModel.Dispatcher;
using Castle.Windsor;
using SharePointPlayground.Infrastructure.Container;

namespace SharePointPlayground.Infrastructure.WCF
{
	public class WindsorInstanceProvider : IInstanceProvider
	{
		private IWindsorContainer _kernel;
		private Type _serviceType;

		public WindsorInstanceProvider(Type serviceType)
			: this(serviceType, ContainerHelper.Kernel)
		{
		}

		public WindsorInstanceProvider(Type serviceType, IWindsorContainer kernel)
		{
			_kernel = kernel;
			_serviceType = serviceType;
		}

		public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
		{
			//todo: what about message?
			return GetInstance(instanceContext);
		}

		public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
		{
			return _kernel.Resolve(_serviceType);
		}

		public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
		{
			_kernel.Release(instance);
		}
	}
}
