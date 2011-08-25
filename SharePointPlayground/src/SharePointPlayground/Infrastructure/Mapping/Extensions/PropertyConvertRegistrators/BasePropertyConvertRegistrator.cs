using System;
using System.Data;
using AutoMapper;
using Microsoft.SharePoint;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public abstract class BasePropertyConvertRegistrator<T> : IPropertyConvertRegistrator
	{
		public bool CanRegister(Type type)
		{
			return type == typeof(T);
		}

		public void RegisterConversion<Tsource, Tdestination>(IMappingExpression<Tsource, Tdestination> expression, string propertyName)
		{
			var convertFunction = CreateConvertFunction();

			if (typeof(Tsource) == typeof(DataRow))
			{
				expression.ForMember(propertyName, opt => opt.MapFrom(item => convertFunction((item as DataRow)[propertyName])));				
			}
			else if (typeof(Tsource) == typeof(SPListItem))
			{
				expression.ForMember(propertyName, opt => opt.MapFrom(item => convertFunction((item as SPListItem)[propertyName])));
			}
			else
			{
				throw new ArgumentException("Only DataRows and SPListItem can be registered automatically");
			}
		}

		protected abstract Func<object, T> CreateConvertFunction();
	}
}