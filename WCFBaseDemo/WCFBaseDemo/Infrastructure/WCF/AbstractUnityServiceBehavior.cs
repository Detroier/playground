using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace WCFBaseDemo.Infrastructure.WCF
{
	public abstract class AbstractUnityServiceBehavior : IServiceBehavior
	{
		private IUnityContainer _container;

		public AbstractUnityServiceBehavior(IUnityContainer container)
		{
			_container = container;
		}

		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
		{

			foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
			{
				ChannelDispatcher cd = cdb as ChannelDispatcher;
				if (cd != null)
				{
					foreach (EndpointDispatcher ed in cd.Endpoints)
					{
						ed.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(_container, serviceDescription.ServiceType);
					}
				}
			}
		}

		public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
		{
		}

		public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
		{
		}
	}
}
