using SPBaseDemo.Web.HttpHandlers.AbstractHandlers;
using System.Web;

namespace SPBaseDemo.Web.HttpHandlers
{
	/// <summary>
	/// Handles references to JS files in application.
	/// </summary>
	public class JsHandler : ScriptHandler
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="JsHandler"/> class.
		/// </summary>
		/// <param name="pathsToFiles">The paths to files.</param>
		public JsHandler(string[] pathsToFiles)
			: base(pathsToFiles, "text/javascript")
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
