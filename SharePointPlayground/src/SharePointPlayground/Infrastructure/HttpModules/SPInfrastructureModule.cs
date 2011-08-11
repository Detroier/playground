using System;
using System.Web;

namespace SharePointPlayground.Infrastructure.HttpModules
{
	/// <summary>
	/// HttpModule which provides all infrastructure stuff.
	/// 
	/// In real life, I'd recommend using 1 module and use some /static?/ helpers to do the configurations
	/// </summary>
	public class SPInfrastructureModule : IHttpModule
	{
		private static bool _hasApplicationStated = false;

		private readonly static object _syncObject = new object();

		#region IHttpModule members

		public void Init(HttpApplication context)
		{
			if (!_hasApplicationStated)
			{
				lock (_syncObject)
				{
					if (!_hasApplicationStated)
					{
						DoApplicationInitialization(context);

						_hasApplicationStated = true;
					}
				}
			}
		}

		public void Dispose()
		{
			Container.ContainerHelper.DoContainerDisposal();
		}

		#endregion

		private void DoApplicationInitialization(HttpApplication context)
		{
			//real initialization goes here!
			Container.ContainerHelper.InitializeHelper(context);

			context.Error += new EventHandler(HandleError);
		}

		void HandleError(object sender, EventArgs e)
		{
			//do something about errors, possible place, where container will be called!
		}
	}
}
