using System.Data;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.SharePoint;
using SharePointPlayground.Mapping;
using SharePointPlayground.Model;
using SharePointPlayground.ViewModels;
using SharePointPlayground.Infrastructure.Mapping;
using System.Collections.Generic;

namespace SharePointPlayground.Infrastructure.Container.Installers
{
	/// <summary>
	/// Note: We have duplicate configuration in here! Maybe, just maybe we could update generic mapper to check & update mappings, if those don't exist?
	/// This step could be done during runtime..or! we could autoconfigure mapper from the container during bootstrapping! => sadly not possible due to how container resolves stuff
	/// 
	/// </summary>
	public class MappingInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			//now we need to register all the mappings! what sucks
			container.Register(Component.For<IMapper<SPListItem, TaskListItemViewModel>, IGenericMapperMarker>()
										.ImplementedBy<GenericMapper<SPListItem, TaskListItemViewModel>>()
										.LifeStyle.Transient);

			container.Register(Component.For<IMapper<DataRow, TaskListItemViewModel>, IGenericMapperMarker>()
							.ImplementedBy<GenericMapper<DataRow, TaskListItemViewModel>>()
							.LifeStyle.Transient);

			container.Register(Component.For<IMapper<DataTable, List<TaskListItemViewModel>>, IGenericMapperMarker>()
							.ImplementedBy<GenericMapper<DataTable, List<TaskListItemViewModel>>>()
							.LifeStyle.Transient);

			container.Register(Component.For<IMapper<PostInsertViewModel, Post>, IGenericMapperMarker>()
							.ImplementedBy<GenericMapper<PostInsertViewModel, Post>>()
							.LifeStyle.Transient);
		}
	}
}
