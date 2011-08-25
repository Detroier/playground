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
		private static IWindsorContainer _kernel = null;

		/// <summary>
		/// Gets the kernel.
		/// </summary>
		/// <value>The kernel.</value>
		public static IWindsorContainer Kernel
		{
			get
			{
				return _kernel;
			}
		}

		/// <summary>
		/// Never call this method! It is called by infrastructure.
		/// Initializes the helper.
		/// </summary>
		/// <param name="context">The context.</param>
		public static void InitializeHelper()
		{
			_kernel = ContainerConfigurator.ConfigureContainer();
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