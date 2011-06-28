using Castle.MicroKernel.Registration;
using WebApp.Presenters;
using WebApp.Services;

namespace WebApp.Infrastructure.Container.Installers
{
    public class PresentersInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            //Special registration for second employe service! we ant something different than default service.
            container.Register(Component.For<IDefaultPagePresenter>()
                .ImplementedBy<DefaultPagePresenter>()
                .ServiceOverrides(ServiceOverride
                    .ForKey("employeService")
                    .Eq("SpecialEmployeServiceWhichDoesVerySpecialThings"))
                .LifeStyle.Transient);
        }
    }
}