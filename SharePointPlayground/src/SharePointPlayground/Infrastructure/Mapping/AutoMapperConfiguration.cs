using System;
using AutoMapper;
using Microsoft.SharePoint;
using SharePointPlayground.Infrastructure.Mapping.Extensions;
using SharePointPlayground.ViewModels;
using AutoMapper.Mappers;
using System.Collections.Generic;
using SharePointPlayground.Infrastructure.Mapping.ObjectMappers;

namespace SharePointPlayground.Infrastructure.Mapping
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			ConfigureMapper();

			ConfigureListItem();
		}

		private static void ConfigureMapper()
		{
			var allMappers = MapperRegistry.AllMappers();
			List<IObjectMapper> newMappers = new List<IObjectMapper>();
			newMappers.Add(new SPListItemCollectionObjectMapper());
			newMappers.AddRange(allMappers);

			var mappersToServe = newMappers.ToArray();
			MapperRegistry.AllMappers = () => { return mappersToServe; };
		}

		private static void ConfigureListItem()
		{
			Mapper.CreateMap<SPListItem, TaskListItemViewModel>()
					.AutoConfigureForSPItem()
					.ForMember(x => x.GUID, opt => opt.MapFrom(item => new Guid(item["GUID"].ToString())));
		}
	}
}
