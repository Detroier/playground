using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SPBaseDemo.Infrastructure.Container.Configurations
{
	/// <summary>
	/// Only helper class. Locates all installators and creates instances from them.
	/// </summary>
	public class InstallatorsFactory
	{
		public IContainerInstallator[] GetInstallators()
		{
			var containerInstallatorTypes = FindInstallatorTypes();

			var installatorInstances = CreateInstallatorInstances(containerInstallatorTypes);

			return installatorInstances.ToArray();
		}

		private List<IContainerInstallator> CreateInstallatorInstances(Type[] containerInstallatorTypes)
		{
			List<IContainerInstallator> installatorInstances = new List<IContainerInstallator>();
			foreach (var installatorType in containerInstallatorTypes)
			{
				var instance = Activator.CreateInstance(installatorType) as IContainerInstallator;
				installatorInstances.Add(instance);
			}
			return installatorInstances;
		}

		private Type[] FindInstallatorTypes()
		{
			var containerInstallatorTypes = Assembly.GetAssembly(this.GetType())
															 .GetTypes()
															 .Where(x =>
																	 x.Namespace == this.GetType().Namespace &&
																	 x.IsAbstract == false &&
																	 x != this.GetType())
															 .ToArray();
			return containerInstallatorTypes;
		}
	}
}
