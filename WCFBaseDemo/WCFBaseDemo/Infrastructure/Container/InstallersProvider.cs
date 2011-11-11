using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WCFBaseDemo.Infrastructure.Container
{
	public class InstallersProvider
	{
		private Assembly[] _assembliesToScan;

		public InstallersProvider(Assembly[] assembliesToScan)
		{
			if (assembliesToScan == null || assembliesToScan.Length <= 0)
			{
				throw new ArgumentException("assembliesToScan");
			}
			_assembliesToScan = assembliesToScan;
		}

		public IContainerInstaller[] GetInstallers()
		{
			List<IContainerInstaller> installers = new List<IContainerInstaller>();

			foreach (var assembly in _assembliesToScan)
			{
				var installerTypes = FindInstallersInAssembly(assembly);

				foreach (var installerType in installerTypes)
				{
					var installerInstance = Activator.CreateInstance(installerType) as IContainerInstaller;
					installers.Add(installerInstance);
				}
			}

			return installers.ToArray();
		}

		private Type[] FindInstallersInAssembly(Assembly assembly)
		{
			var installerTypes = assembly
											.GetTypes()
											.Where(x => IsInstallerClass(x))
											.ToArray();
			return installerTypes;
		}

		private bool IsInstallerClass(Type x)
		{
			return x.IsAbstract == false &&
				x.IsInterface == false &&
				x.GetInterfaces().FirstOrDefault(i => i == typeof(IContainerInstaller)) != null;
		}
	}
}
