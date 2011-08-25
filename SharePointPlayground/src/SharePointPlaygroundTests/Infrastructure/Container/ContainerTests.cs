using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web;
using SharePointPlayground.Infrastructure.Container;
using Castle.Windsor;
using SharePointPlayground.Presenters;
using SharePointPlayground.Infrastructure.BaseClassesWithInjection;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;

namespace SharePointPlaygroundTests.Infrastructure.Container
{
	[TestFixture]
	public class ContainerTests
	{
		[Test]
		public void Can_Setup_Container()
		{
			var kernel = ContainerConfigurator.ConfigureContainer();
		}
	}

	[TestFixture]
	public class ContainerExtensionTests
	{
		private IWindsorContainer _container;

		[SetUp]
		public void SetupContainer()
		{
			_container = ContainerConfigurator.ConfigureContainer();
			_container.Register(Component.For<IDummyPresenter>().ImplementedBy<DummyPresenter>().LifeStyle.Transient);
		}

		[Test]
		public void Can_Resolve_Public_Properties_In_ExistingObject()
		{
			TestObjectWithInjectableProperties testObject = new TestObjectWithInjectableProperties();
			_container.InjectDependencies(testObject);

			Assert.IsNotNull(testObject.Presenter);
			Assert.IsInstanceOf<IDummyPresenter>(testObject.Presenter);
		}

		[Test]
		public void Can_Release_Injected_Properties_From_Object()
		{
			TestObjectWithInjectableProperties testObject = new TestObjectWithInjectableProperties();
			var injectedItems = _container.InjectDependencies(testObject);

			_container.ReleaseInjectedObjects(injectedItems);

			//I can't really write a test for this :(  but at least run the code
		}

		[Test]
		public void Can_Inject_Stuff_To_Injectable_Page_Child()
		{
			InjectablePageTestChild pageToInject = new InjectablePageTestChild(_container);

			Assert.IsNotNull(pageToInject.DummyPresenter);
			Assert.IsNotNull(pageToInject.Logger);
		}

		[Test]
		public void Can_Inject_Stuff_To_Injectable_WebPart_Child()
		{
			InjectableWebPartTestChild webpartToInject = new InjectableWebPartTestChild(_container);

			Assert.IsNotNull(webpartToInject.DummyPresenter);
		}
	}

	public class TestObjectWithInjectableProperties
	{
		public IDummyPresenter Presenter { get; set; }
	}

	public class InjectablePageTestChild : InjectableLayoutPageBase
	{
		public InjectablePageTestChild(IWindsorContainer kernel) : base(kernel) { }

		public IDummyPresenter DummyPresenter { get; set; }

		public ILogger Logger { get; set; }
	}

	public class InjectableWebPartTestChild : InjectableWebPart
	{
		public InjectableWebPartTestChild(IWindsorContainer kernel) : base(kernel) { }

		public IDummyPresenter DummyPresenter { get; set; }
	}

	public interface IDummyPresenter { }

	public class DummyPresenter : IDummyPresenter { }
}
