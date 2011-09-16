using System;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.SharePoint;
using SharePointPlayground.Infrastructure.Mapping.Extensions;
using SharePointPlayground.Infrastructure.Mapping.ObjectMappers;
using SharePointPlayground.ViewModels;
using SharePointPlayground.Model;

namespace SharePointPlayground.Infrastructure.Mapping
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			ConfigureMapper();

			ConfigureListItem();

			ConfigureModelMappings();
		}

		private static void ConfigureModelMappings()
		{
			Mapper.CreateMap<PostInsertViewModel, Post>();
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
					.AutoConfigureForSPItem(); //(x => x.GUID, x => x.ID);
			//.ForMember(x => x.GUID, opt => opt.MapFrom(item => new Guid(item["GUID"].ToString())))
			//.ForMember(x => x.ID, opt => opt.MapFrom(item => Convert.ToInt32(item["ID"]))); 
			//left as example how to map some more difficult types!

			//this is just temporary!
			Mapper.CreateMap<DataRow, TaskListItemViewModel>()
					.AutoConfigureForDataRow();
		}
	}
}
