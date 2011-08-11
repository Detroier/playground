using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.SharePoint;
using SharePointPlayground.Helpers;
using System.Collections;

namespace SharePointPlayground.Infrastructure.Mapping.ObjectMappers
{
	public class SPListItemCollectionObjectMapper : IObjectMapper
	{
		public bool IsMatch(ResolutionContext context)
		{
			return typeof(SPListItemCollection).IsAssignableFrom(context.SourceType);
		}

		public object Map(ResolutionContext context, IMappingEngineRunner mapper)
		{
			var collection = context.SourceValue as SPListItemCollection;

			//1. Need to create single item type
			var elementType = context.DestinationType.GetGenericArguments()[0];

			//2. Need to create result with generic type
			var resultCollection = Activator.CreateInstance(context.DestinationType) as IList;


			foreach (var item in collection)
			{
				var mappedItem = Mapper.Map(item, typeof(SPListItem), elementType);
				resultCollection.Add(mappedItem);
			}
			return resultCollection;
		}
	}
}
