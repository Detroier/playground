using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Releasers;
using System.Web;

namespace SharePointPlayground.Infrastructure.Container
{
	/// <summary>
	/// Helper.
	/// </summary>
	public static class ContainerHelper
	{
		//private static IWindsorContainer _kernel = null;

		private const string IOC_APP_ITEM_ID = "SP_WINDSOR_INSTANCE";

		/// <summary>
		/// Gets the kernel.
		/// </summary>
		/// <value>The kernel.</value>
		public static IWindsorContainer Kernel
		{
			get
			{
				return HttpContext.Current.Application[IOC_APP_ITEM_ID] as IWindsorContainer;
			}
		}

		/// <summary>
		/// Configures the container.
		/// </summary>
		/// <returns></returns>
		private static IWindsorContainer ConfigureContainer()
		{
			IWindsorContainer container = new WindsorContainer()
				 .Install(FromAssembly.This());

			// This might not be smartest move ever! Maybe only allow injection on interfaces
			// Use this, if overriding Dispose for each base class looks ugly for you
			//container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();

			return container;
		}

		/// <summary>
		/// Never call this method! It is called by infrastructure.
		/// Initializes the helper.
		/// </summary>
		/// <param name="context">The context.</param>
		public static void InitializeHelper(HttpApplication context)
		{
			context.Application[IOC_APP_ITEM_ID] = ConfigureContainer();
		}

		/// <summary>
		/// Never call this method!
		/// 
		/// Does the container disposal.
		/// </summary>
		public static void DoContainerDisposal()
		{
			//is it possible to get reference to application here????
			//if yes, we could do the cleanup, if no (more probable) this might lead to leaks...but! since application will be disposed, container will be collected by GC anyway
		}
	}
}