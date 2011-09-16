using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SharePointPlayground.SPI.WebParts.BlogsFromDatabaseWebPart
{
	[ToolboxItemAttribute(false)]
	public class BlogsFromDatabaseWebPart : WebPart
	{
		// Visual Studio might automatically update this path when you change the Visual Web Part project item.
		private const string _ascxPath = @"~/_CONTROLTEMPLATES/SharePointPlayground.SPI.WebParts/BlogsFromDatabaseWebPart/BlogsFromDatabaseWebPartUserControl.ascx";

		protected override void CreateChildControls()
		{
			Control control = Page.LoadControl(_ascxPath);
			Controls.Add(control);
		}
	}
}
