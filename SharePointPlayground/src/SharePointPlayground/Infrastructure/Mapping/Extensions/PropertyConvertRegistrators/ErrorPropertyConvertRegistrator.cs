using System;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class ErrorPropertyConvertRegistrator : IPropertyConvertRegistrator
	{
		public bool CanRegister(Type type)
		{
			return true;

		}

		public void RegisterConversion<Tsource, Tdestination>(AutoMapper.IMappingExpression<Tsource, Tdestination> expression, string propertyName)
		{
			throw new Exception(string.Format("Property {0} couldn't be registered, because it's type isn't supported by automatic registration", propertyName));
		}
	}
}
