using SPBaseDemo.Web.HttpHandlers.AbstractHandlers;
using System.Web;

namespace SPBaseDemo.Web.HttpHandlers
{
	public class CssHandler : ScriptHandler
	{
		public CssHandler(string[] pathsToFiles)
			: base(pathsToFiles, "text/css")
		{
		}

		protected override string UpdateGeneratedScript(string generatedScript)
		{
			return generatedScript;
		}

		protected override void SetCustomContextOptions(HttpContextBase context)
		{
		}
	}
}
