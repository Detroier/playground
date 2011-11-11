using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Reflection;

namespace SPBaseDemo.Infrastructure.Container
{
	public static class ContainerExtensions
	{
		private static Dictionary<Type, PropertyInfo[]> _propertyCache = new Dictionary<Type, PropertyInfo[]>();

		/// <summary>
		/// Injects the dependencies. Use this instead on BuildUp, because of bug in Unity, which prevents injection in container. Bummer.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="instance">The instance.</param>
		public static void InjectDependencies(this IUnityContainer container, object instance)
		{
			var injectableProperties = GetInjectableProperties(instance);

			foreach (var property in injectableProperties)
			{
				var resolved = container.Resolve(property.PropertyType);
				property.SetValue(instance, resolved, null);
			}
		}

		/// <summary>
		/// Gets the injectable properties.
		/// </summary>
		/// <param name="instance">The instance.</param>
		private static PropertyInfo[] GetInjectableProperties(object instance)
		{
			PropertyInfo[] injectableProperties = null;
			if (!_propertyCache.TryGetValue(instance.GetType(), out injectableProperties))
			{
				injectableProperties = instance
											.GetType()
											.GetProperties()
											.Where(x => x.GetCustomAttributes(true).FirstOrDefault(a => a.GetType() == typeof(DependencyAttribute)) != null)
											.ToArray();

				_propertyCache = new Dictionary<Type, PropertyInfo[]>(_propertyCache) 
				{
				 { instance.GetType(), injectableProperties }
				};
			}

			return injectableProperties;
		}
	}
}
