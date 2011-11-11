using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SPBaseDemo.Infrastructure.Container;

namespace SPBaseDemo.Infrastructure.HttpModules
{
	/// <summary>
	/// In pure ASP.Net applications, configuration is done in Global.asax. Since we cannot rewrite this file (we can, but it might be problematic to do deployments),
	/// it is better to do initialization of container and infrastructure in HttpModule.
	/// 
	/// Put bootstrapping code in module similar to this.
	/// </summary>
	public class BootstrapperModule : IHttpModule
	{
		private static bool _hasApplicationStated = false;
		private readonly static object _syncObject = new object();

		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			InitializeStaticApplicationMembers();
		}

		/// <summary>
		/// Initializes the static application members. Http module can be called multiple times during web application lifetime. So we need to make sure static variables are initialized only once.		
		/// Put bootstrapping code, which kicks in for statics here.
		/// </summary>
		private static void InitializeStaticApplicationMembers()
		{
			if (!_hasApplicationStated)
			{
				lock (_syncObject)
				{
					if (!_hasApplicationStated)
					{
						//init container here
						ContainerLocator.InitializeContainer();

						_hasApplicationStated = true;
					}
				}
			}
		}
	}
}
