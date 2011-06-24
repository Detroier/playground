using System.Reflection;
using Castle.Windsor;
using System.Linq;

namespace WebApp.Infrastructure.Container
{
    /// <summary>
    /// Windsor doesn't allow injection of properties toalready created object.
    /// To handle this extension is used.
    /// </summary>
    public static class ContainerExtension
    {
        /// <summary>
        /// Ineject properties to an instance of object.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="instance"></param>
        public static void InjectDependencies(this IWindsorContainer container, object instance)
        {
            var type = instance.GetType();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsInterface && p.PropertyType.Name != "ISite")
                .ToArray();

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