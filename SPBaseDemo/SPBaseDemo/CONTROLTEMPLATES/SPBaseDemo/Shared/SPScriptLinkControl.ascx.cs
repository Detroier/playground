using System;
using System.Linq;
using Microsoft.Practices.Unity;
using SPBaseDemo.Helpers.SharePoint;
using SPBaseDemo.Infrastructure.Web.Controls;

namespace SPBaseDemo.CONTROLTEMPLATES.SPBaseDemo.Shared
{
	public partial class SPScriptLinkControl : BaseUserControl
	{
		private string _scriptType;
		private string _links;

		public SPScriptLinkControl()
			: base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SPScriptLinkControl"/> class.
		/// For test purposes.
		/// </summary>
		/// <param name="container">The container.</param>
		public SPScriptLinkControl(IUnityContainer container)
			: base(container)
		{
		}

		[Dependency]
		public ISharePointContextItemsAccesor SPContextAccesor { get; set; }

		/// <summary>
		/// Gets or sets the type of the script.
		/// </summary>
		/// <value>The type of the script.</value>
		public string ScriptType
		{
			get { return _scriptType; }
			set
			{
				if (string.IsNullOrEmpty(value) == true || (value != "Js" && value != "Css"))
				{
					throw new ArgumentException("ScriptType");
				}
				_scriptType = value;
			}
		}

		/// <summary>
		/// Gets or sets the links.
		/// </summary>
		/// <value>The links.</value>
		public string Links
		{
			get { return _links; }
			set
			{
				if (value == null || value.Length <= 0)
				{
					throw new ArgumentException("Links");
				}
				_links = value;
			}
		}

		private string[] GetListOfScriptsToLoad()
		{
			var scriptLinks = Links.Split(';');
			return scriptLinks;
		}

		public string GetScriptDefinition()
		{
			var package = SPContextAccesor.GetCurrentSite().WebApplication.Farm.Solutions.FirstOrDefault(x => x.Name.ToUpper() == "SPBASEDEMO.WSP");
			var versionHash = package == null ? "00000000000000" : package.LastOperationEndTime.ToString("yyyyMMddhhmmss");
			var siteUrl = SPContextAccesor.GetCurrentSite().RootWeb.Url;

			var linksQueryString = Links.Split(';')
									.Select(x => string.Format("files={0}", x))
									.Aggregate((accumulated, current) => string.IsNullOrEmpty(accumulated) ? current : string.Format("{0}&{1}", accumulated, current));
			var versionQueryString = string.Format("version={0}", versionHash);

			var linkTemplate = string.Empty;
			var pathToHandler = string.Empty;

			//template format: {0} - site url {1} - path to handler {2} - files parameters {3} - version
			switch (ScriptType)
			{
				case "Js":
					linkTemplate = @"<script type='text\javascript' src='{0}/{1}?{2}&{3}'></script>";
					pathToHandler = "_layouts/SPBaseDemo/Handler.ashx/Js";
					break;
				case "Css":
					linkTemplate = @"<link rel='stylesheet' href='{0}/{1}?{2}&{3}' />";
					pathToHandler = "_layouts/SPBaseDemo/Handler.ashx/Css";
					break;
				default:
					throw new Exception("Unknown script type");
			}

			return string.Format(linkTemplate, siteUrl, pathToHandler, linksQueryString, versionHash);
		}
	}
}
