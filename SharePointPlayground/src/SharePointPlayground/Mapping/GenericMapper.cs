using System;
using AutoMapper;
using SharePointPlayground.Infrastructure.Mapping;

namespace SharePointPlayground.Mapping
{
	public class GenericMapper<TSource, TDestination> : IMapper<TSource, TDestination>, IGenericMapperMarker
	{
		public TDestination Map(TSource source)
		{
			return Mapper.Map<TSource, TDestination>(source);
		}

		public TDestination Map(TSource source, TDestination destination)
		{
			return Mapper.Map<TSource, TDestination>(source, destination);
		}

		#region IGenericMapperMarker implementation

		public Type GetDestinationType()
		{
			return typeof(TDestination);
		}

		public Type GetSourceType()
		{
			return typeof(TSource);
		}
		#endregion

	}
}
