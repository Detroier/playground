using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Castle.Windsor;

namespace WebApp.Infrastructure.Container
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

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => IsInjectableProperty(p, instance))
                .ToList();

            _propertyCache = new Dictionary<Type, List<PropertyInfo>>(_propertyCache)
            {
               {type, properties}
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
            return property.PropertyType.IsInterface &&
                   property.GetValue(instance, null) == null &&
                   property.PropertyType.Name != "ISite";
        }

        /// <summary>
        /// Inject properties to an instance of object.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="instance"></param>
        public static void InjectDependencies(this IWindsorContainer container, object instance)
        {
            var properties = GetInjectableProperties(instance);

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(instance, null);
                if (propertyValue == null)
                {
                    var resolvedDependency = container.Resolve(property.PropertyType);
                    property.SetValue(instance, resolvedDependency, null);
                }
            }
        }
    }
}