using System.Collections.Generic;
using WebApp.Infrastructure.Container;

namespace WebApp.Infrastructure.BaseClassesWithInjection
{
    public class InjectableUserControl : System.Web.UI.UserControl
    {
        private List<object> _injectedInstances;

        public InjectableUserControl()
        {
            _injectedInstances = ContainerHelper.Kernel.InjectDependencies(this);
        }

        public override void Dispose()
        {
            ContainerHelper.Kernel.ReleaseInjectedObjects(_injectedInstances);

            base.Dispose();
        }
    }
}