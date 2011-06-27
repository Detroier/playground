using System.Collections.Generic;
using WebApp.Infrastructure.Container;

namespace WebApp.Infrastructure.BaseClassesWithInjection
{
    public class InjectableWebControl : System.Web.UI.Control
    {
        private List<object> _injectedInstances;

        public InjectableWebControl()
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