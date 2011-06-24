using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Infrastructure.Container;

namespace WebApp.Infrastructure.BaseClassesWithInjection
{
    public class InjectablePage : System.Web.UI.Page
    {
        public InjectablePage()
        {
            ContainerHelper.Kernel.InjectDependencies(this);
        }
    }
}