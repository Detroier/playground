using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Castle.Windsor;

namespace SharePointPlayground.Infrastructure.Container
{
	/// <summary>
	/// Windsor doesn't allow injection of properties toalready created object.
	/// To handle this extension is used.
	/// </summary>
	public static class ContainerExtension
	{
		/// <summary>
		/// Cache of property info objects.
		/// </summary>
		private static Dictionary<Type, List<PropertyInfo>> _propertyCache = new Dictionary<Type, List<PropertyInfo>>();

		/// <summary>
		/// Get injectable properties for object instance.
		/// </summary>
		/// <param name="instance"></param>
		/// <returns></returns>
		private static List<PropertyInfo> GetInjectableProperties(object instance)
		{
			Type type = instance.GetType();

			List<PropertyInfo> injectableProperties;
			if (_propertyCache.TryGetValue(type, out injectableProperties) == true)
			{
				return injectableProperties;
			}

			injectableProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				 .Where(p => IsInjectableProperty(p, instance))
				 .ToList();

			_propertyCache = new Dictionary<Type, List<PropertyInfo>>(_propertyCache)
            {
               {type, injectableProperties}
            };

			return injectableProperties;
		}

		/// <summary>
		/// Check if property is injectable.
		/// </summary>
		/// <param name="property"></param>
		/// <param name="instance"></param>
		/// <returns></returns>
		private static bool IsInjectableProperty(PropertyInfo property, object instance)
		{
			return property.PropertyType.IsInterface && //only inject interfaces
					 property.GetValue(instance, null) == null && //only inject non-null values
					 property.PropertyType.Name != "ISite";
			//pesky ISite from framework..this pretty much sucks and there can be more of this in real SP environment.
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="container"></param>
		/// <param name="instance"></param>
		/// <returns></returns>
		public static List<object> InjectDependencies(this IWindsorContainer container, object instance)
		{
			var properties = GetInjectableProperties(instance);
			List<object> injectedInstances = new List<object>();

			foreach (var property in properties)
			{
				var resolvedDependency = container.Resolve(property.PropertyType);
				property.SetValue(instance, resolvedDependency, null);
				injectedInstances.Add(resolvedDependency);
			}

			return injectedInstances;
		}

		/// <summary>
		/// Explicitly release all the injected instances.
		/// </summary>
		/// <param name="container"></param>
		/// <param name="injectedInstances"></param>
		public static void ReleaseInjectedObjects(this IWindsorContainer container, List<object> injectedInstances)
		{
			foreach (var injectedInstance in injectedInstances)
			{
				container.Release(injectedInstance);
			}
		}
	}
}