using AutoMapper;
using Microsoft.SharePoint;
using NUnit.Framework;
using SharePointPlayground.Helpers;
using SharePointPlayground.Infrastructure.Mapping;
using SharePointPlayground.ViewModels;
using System.Collections.Generic;
using System.Collections;

namespace SharePointPlaygroundTests
{
	[TestFixture]
	public class AutomapperTests
	{
		[Test]
		public void CanConfigureMapper()
		{
			Mapper.Reset();
			Assert.DoesNotThrow(() => AutoMapperConfiguration.Configure());
		}

		[Test]
		public void CanResolveListItem()
		{
			Mapper.Reset();
			AutoMapperConfiguration.Configure();

			SPListItem listItem = GetListItem();

			var viewItem = listItem.MapTo<TaskListItemViewModel>();
			Assert.AreEqual(viewItem.ID, 1);
			Assert.AreEqual(viewItem.Title, "Test item");
			Assert.AreEqual(viewItem.Status, "Not Started");
		}

		[Test]
		public void CanResolveListItems()
		{
			Mapper.Reset();
			AutoMapperConfiguration.Configure();

			var listItems = GetListItems();
			var result = listItems.MapTo<TaskListItemViewModel>();
			Assert.IsInstanceOf<IEnumerable<TaskListItemViewModel>>(result);
		}

		private SPListItem GetListItem()
		{
			SPListItem item = null;

			SPSecurity.RunWithElevatedPrivileges(() =>
			{
				using (var site = new SPSite("http://wl033766/"))
				{
					var list = site.RootWeb.Lists["Tasks"];
					item = list.Items[0];
				}
			});

			return item;
		}

		private SPListItemCollection GetListItems()
		{
			SPListItemCollection items = null;

			SPSecurity.RunWithElevatedPrivileges(() =>
			{
				using (var site = new SPSite("http://wl033766/"))
				{
					var list = site.RootWeb.Lists["Tasks"];
					items = list.Items;
				}
			});
			
			return items;
		}
	}
}
