using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharePointPlayground.Infrastructure.Mapping;
using AutoMapper;
using Microsoft.SharePoint;
using SharePointPlayground.ViewModels;
using SharePointPlayground.Helpers;

namespace NUnitTest1.Infrastructure.Mapping
{
	[TestFixture]
	public class AutomapperSPItemTests
	{
		[TearDown]
		public void TearDown()
		{
			Mapper.Reset();
		}

		[SetUp]
		public void EstablishContext()
		{
			AutoMapperConfiguration.Configure();
		}

		[Test]
		public void Can_Map_SPListItem_To_OtherType()
		{
			//SPListItem listItem = GetListItem();

			//var viewItem = listItem.MapTo<TaskListItemViewModel>();
			//Assert.AreEqual(viewItem.ID, 1);
			//Assert.AreEqual(viewItem.Title, "Test item");
			//Assert.AreEqual(viewItem.Status, "Not Started");
		}

		[Test]
		public void Can_Map_SPListItemCollection()
		{
			//var listItems = GetListItems();
			//var result = listItems.MapTo<TaskListItemViewModel>();
			//Assert.IsInstanceOf<IEnumerable<TaskListItemViewModel>>(result);
		}

		private SPListItem GetListItem()
		{
			return GetListItems()[0];
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