using Microsoft.Practices.Unity;
using SPBaseDemo.Infrastructure.Container.Configurations;

namespace SPBaseDemo.Infrastructure.Container
{
	/// <summary>
	/// 
	/// </summary>
	public class ContainerConfigurator
	{
		private IContainerInstallator[] _containerInstallators;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContainerConfigurator"/> class.			
		/// </summary>
		public ContainerConfigurator()
			: this(new InstallatorsFactory().GetInstallators())
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ContainerConfigurator"/> class.
		/// This constructor is mainly for possible unit tests.
		/// </summary>
		/// <param name="containerInstallators">The container installators.</param>
		public ContainerConfigurator(IContainerInstallator[] containerInstallators)
		{
			_containerInstallators = containerInstallators;
		}

		public IUnityContainer ConfigureContainer()
		{
			var container = new UnityContainer();

			foreach (var installator in _containerInstallators)
			{
				installator.InstallDependencies(container);
			}

			return container;
		}
	}
}
