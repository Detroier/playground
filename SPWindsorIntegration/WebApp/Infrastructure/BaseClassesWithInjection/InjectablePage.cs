﻿using System.Collections.Generic;
using WebApp.Infrastructure.Container;

namespace WebApp.Infrastructure.BaseClassesWithInjection
{
    public class InjectablePage : System.Web.UI.Page
    {
        private List<object> _injectedInstances;

        public InjectablePage()
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