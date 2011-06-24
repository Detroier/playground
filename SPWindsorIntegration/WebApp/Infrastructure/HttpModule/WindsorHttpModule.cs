using System.Web;

using Castle.Windsor;

using WebApp.Infrastructure.Container;

namespace WebApp.Infrastructure.HttpModule
{
    /// <summary>
    /// Windsormodule, handles disposing of container.
    /// </summary>
    public class WindsorHttpModule : IHttpModule
    {
        /// <summary>
        /// Empty implementation.
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
        }

        /// <summary>
        /// Handles disposing of Kernel.
        /// </summary>
        public void Dispose()
        {
            ContainerHelper.Kernel.Dispose();
        }
    }
}