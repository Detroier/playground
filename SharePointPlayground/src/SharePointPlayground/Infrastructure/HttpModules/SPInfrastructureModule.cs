using System.Web;
using SharePointPlayground.Infrastructure.Mapping;

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
			EnsureGlobalInstancesInitialized(context);
		}

		public void Dispose()
		{
			Container.ContainerHelper.DoContainerDisposal();
		}

		#endregion

		/// <summary>
		/// Ensures the global instances initialized.
		/// </summary>
		/// <param name="context">The context.</param>
		private void EnsureGlobalInstancesInitialized(HttpApplication context)
		{
			if (!_hasApplicationStated)
			{
				lock (_syncObject)
				{
					if (!_hasApplicationStated)
					{

						InitializeStatics();
						_hasApplicationStated = true;
					}
				}
			}
		}

		/// <summary>
		/// Initializes the static instances.
		/// </summary>
		private static void InitializeStatics()
		{
			Container.ContainerHelper.InitializeHelper();
			AutoMapperConfiguration.Configure();
		}
	}
}
