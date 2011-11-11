using System.Web;
using Microsoft.Practices.Unity;
using SPBaseDemo.Web.HttpHandlers;

namespace SPBaseDemo.Infrastructure.Container.Configurations
{
	public class HttpHandlersInstallator : IContainerInstallator
	{
		public void InstallDependencies(IUnityContainer container)
		{
			//configure with path to files property set to where we expect files, in our case it is in layouts folder, but it can be different;
			container
					.RegisterType<IHttpHandler, JsHandler>(
						"JsHandler",
						new InjectionConstructor(new object[]
						{
							new string[] { 
									@"c:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\TEMPLATE\LAYOUTS\SPBaseDemo\styles\Js\" 
							}
						}));

			//configure Css handler in same way as js handler
			container
					.RegisterType<IHttpHandler, CssHandler>(
						"CssHandler",
						new InjectionConstructor(new object[]
						{
								new string[] { 
									@"c:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\TEMPLATE\LAYOUTS\SPBaseDemo\styles\Css\" }}));

		}
	}
}
