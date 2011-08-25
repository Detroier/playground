using System;
using AutoMapper;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public interface IPropertyConvertRegistrator
	{
		bool CanRegister(Type type);

		void RegisterConversion<Tsource, Tdestination>(IMappingExpression<Tsource, Tdestination> expression, string propertyName);
	}
}
