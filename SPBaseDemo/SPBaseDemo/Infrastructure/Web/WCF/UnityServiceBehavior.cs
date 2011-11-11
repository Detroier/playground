using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SPBaseDemo.Infrastructure.Web.WCF
{
	public class UnityServiceBehavior : Attribute, IServiceBehavior
	{
		public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
		{
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
						ed.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(serviceDescription.ServiceType);
					}
				}
			}
		}

		public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
		{
		}
	}
}
