using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using AutoMapper;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class PropertyConversionRegistrator
	{
		private List<IPropertyConvertRegistrator> _registrators;

		public PropertyConversionRegistrator()
		{
			_registrators = new List<IPropertyConvertRegistrator>
			{
				new StringPropertyRegistrator(),
				new BoolPropertyConvertRegistrator(),
				new DecimalPropertyConvertRegistrator(),
				new DateTimePropertyConvertRegistration(),
				new IntegerPropertyConvertRegistrator(),
				new GuidPropertyConvertRegistrator(),
				new ErrorPropertyConvertRegistrator()
			};
		}

		public void TryRegisterProperty<Tsource, Tdestination>(IMappingExpression<Tsource, Tdestination> expression, PropertyInfo propertyInfo)
		{
			var propertyName = propertyInfo.Name;
			var propertyType = propertyInfo.PropertyType;

			foreach (var registrator in _registrators)
			{
				if (registrator.CanRegister(propertyType) == true)
				{
					registrator.RegisterConversion(expression, propertyName);
					break;
				}
			}
		}
	}
}