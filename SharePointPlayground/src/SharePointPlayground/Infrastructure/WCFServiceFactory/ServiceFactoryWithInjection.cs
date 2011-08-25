using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client.Services;

namespace SharePointPlayground.Infrastructure.WCFServiceFactory
{
	public class ServiceFactoryWithInjection : MultipleBaseAddressBasicHttpBindingServiceHostFactory
	{
		protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			return base.CreateServiceHost(serviceType, baseAddresses);
		}
	}
}
