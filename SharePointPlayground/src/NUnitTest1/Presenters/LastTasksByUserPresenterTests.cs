using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.SharePoint;
using SharePointPlayground.Presenters;
using SharePointPlayground.Queries;
using SharePointPlayground.Infrastructure.Container;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using SharePointPlayground.Helpers.SharePoint;

namespace NUnitTest1.Presenters
{
	[TestFixture]
	public class LastTasksByUserPresenterTests
	{
		[Test]
		public void Can_Load_Last_Tasks_For_User()
		{

			SharePointPlayground.Infrastructure.Mapping.AutoMapperConfiguration.Configure();

			using (var site = new SPSite("http://wl033766/"))
			{
				using (var rootWeb = site.OpenWeb())
				{
					var user = rootWeb.EnsureUser(@"eu\poladmar");

					using (IWindsorContainer kernel = ConfigureKernelForTest(site, user))
					{
						var presenter = kernel.Resolve<ILastTasksByUserPresenter>();
						var presenterResults = presenter.GetLastTasks();

						Assert.LessOrEqual(presenterResults.Count(), 5);
					}
				}
			}
		}

		private static IWindsorContainer ConfigureKernelForTest(SPSite site, SPUser user)
		{
			IWindsorContainer kernel = new WindsorContainer();

			kernel.Register(Component.For<ICurrentSiteAccesor>()
										.UsingFactoryMethod(() => new FakeCurrentSiteAccesor(site))
										.LifeStyle.Transient);

			kernel.Register(Component.For<ICurrentUserAccesor>()
										.UsingFactoryMethod(() => new FakeCurrentUserAccesor(user))
										.LifeStyle.Transient);

			kernel.Install(FromAssembly.Containing<ICurrentSiteAccesor>());
			return kernel;
		}
	}

	public class FakeCurrentUserAccesor : ICurrentUserAccesor
	{
		private SPUser _user;

		public FakeCurrentUserAccesor(SPUser user)
		{
			_user = user;
		}

		public Microsoft.SharePoint.SPUser GetUser()
		{
			return _user;
		}
	}

	public class FakeCurrentSiteAccesor : ICurrentSiteAccesor
	{
		private SPSite _site;

		public FakeCurrentSiteAccesor(SPSite site)
		{
			_site = site;
		}

		public SPSite GetSite()
		{
			return _site;
		}
	}
}
