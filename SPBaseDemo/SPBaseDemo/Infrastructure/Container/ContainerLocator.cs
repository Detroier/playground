using System;
using Microsoft.Practices.Unity;

namespace SPBaseDemo.Infrastructure.Container
{
	/// <summary>
	/// Static accesor for container. In "classic" asp.net apps, container is created and held in global.asax instance (in custom property of derived HttpApplication object), but in SharePoint we cannot do this.
	/// We create static class instead, which will bre responsible for holding the container and serving it in right places.
	/// 
	/// Note: Don't use this class from your code, it is purely infrastructure concern!
	/// Note2: If you really need to use this, make sure you have no other way!
	/// </summary>
	public static class ContainerLocator
	{
		public static IUnityContainer _container;

		/// <summary>
		/// Gets the container.
		/// </summary>
		/// <value>The container.</value>
		public static IUnityContainer Container
		{
			get
			{
				if (_container == null)
				{
					throw new ApplicationException("Container wasn't initialized! Make sure it is instanced by calling ContainerLocator.InitializeContainer() in application start");
				}
				return _container;
			}
		}

		/// <summary>
		/// Initializes the container.
		/// </summary>
		public static void InitializeContainer()
		{
			_container = new ContainerConfigurator()
								.ConfigureContainer();
		}
	}
}
