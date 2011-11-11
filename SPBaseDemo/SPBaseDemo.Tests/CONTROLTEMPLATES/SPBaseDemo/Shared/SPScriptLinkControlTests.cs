using Microsoft.Practices.Unity;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPBaseDemo.CONTROLTEMPLATES.SPBaseDemo.Shared;
using SPBaseDemo.Helpers.SharePoint;
using SPBaseDemo.Tests.TestInternals.Helpers.SharePoint;

namespace SPBaseDemo.Tests.CONTROLTEMPLATES.SPBaseDemo.Shared
{
	[TestFixture]
	public class SPScriptLinkControlTests
	{
		private SPSite _site;
		private UnityContainer _container;

		[SetUp]
		public void InitTestVariables()
		{
			_site = new SPSite("http://wl033766");
			_container = new UnityContainer();
			_container.RegisterInstance<ISharePointContextItemsAccesor>(new DummySharePointContextItemsAccesor(_site));
		}

		[TearDown]
		public void CloseTestVariables()
		{
			_container.Dispose();
			_site.Dispose();
		}

		[Test]
		public void CanCreateLinkToJsFiles()
		{
			var control = new SPScriptLinkControl(_container);
			control.Links = "test1.js;test2.js";
			control.ScriptType = "Js";

			var result = control.GetScriptDefinition();

			Assert.IsNotNullOrEmpty(result, "Script definition cannot be null");
			Assert.IsTrue(result.Contains("files=test1.js&files=test2.js"), "Result should contain valid query string parameters");
			Assert.IsTrue(result.Contains(_site.RootWeb.Url), "Scripts should point to root web of site");
			Assert.IsTrue(result.Contains(@"text\javascript"), "Should contain js definition");
		}

		[Test]
		public void CanCreateLinksToCssFiles()
		{
			var control = new SPScriptLinkControl(_container);
			control.Links = "test1.css;test2.css";
			control.ScriptType = "Css";

			var result = control.GetScriptDefinition();

			Assert.IsNotNullOrEmpty(result, "Script definition cannot be null");
			Assert.IsTrue(result.Contains("files=test1.css&files=test2.css"), "Result should contain valid query string parameters");
			Assert.IsTrue(result.Contains(_site.RootWeb.Url), "Scripts should point to root web of site");
			Assert.IsTrue(result.Contains("stylesheet"), "Should contain js definition");
		}		
	}
}
