using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SPBaseDemo.Web.HttpHandlers.AbstractHandlers
{
	public abstract class ScriptHandler : HttpHandlerBase
	{
		private string[] _filesRootPaths;
		private string _contentType;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseScriptHandler"/> class.
		/// </summary>
		/// <param name="filesRootPaths">The files root paths.</param>
		/// <param name="contentType">Type of the content.</param>
		public ScriptHandler(string[] filesRootPaths, string contentType)
		{
			if (filesRootPaths == null || filesRootPaths.Length == 0)
			{
				throw new ArgumentNullException("filesRootPath");
			}
			if (string.IsNullOrEmpty(contentType) == true)
			{
				throw new ArgumentNullException("contentType");
			}

			_filesRootPaths = filesRootPaths
								.Select(x => x + "{0}")
								.ToArray();
			_contentType = contentType;
		}

		public override bool IsReusable
		{
			get { return false; }
		}

		public override void ProcessRequest(HttpContextBase context)
		{
			var filesString = context.Request["files"];
			var filesToLoad = filesString.Split(',');
			var scriptBuilder = new StringBuilder();

			BuildScript(context, filesToLoad, scriptBuilder);

			context.Response.ContentType = _contentType;

			SetCachingOptions(context);

			SetCustomContextOptions(context);

			var outputScript = UpdateGeneratedScript(scriptBuilder.ToString());

			context.Response.Write(outputScript);
		}

		private void SetCachingOptions(HttpContextBase context)
		{
			var dayOfWeek = (int)DateTime.Now.DayOfWeek;
			var daysToAdd = 7 - dayOfWeek == 0 ? 7 : 7 - dayOfWeek;

			//context.Response.Cache.VaryByParams["files"] = true; //not testable!
			context.Response.Cache.SetLastModifiedFromFileDependencies();
			context.Response.Cache.SetETagFromFileDependencies();
			context.Response.Cache.SetCacheability(HttpCacheability.Public);
			context.Response.Cache.SetExpires(DateTime.Now.Date.AddDays(daysToAdd));
		}

		private void BuildScript(HttpContextBase context, string[] filesToLoad, StringBuilder scriptBuilder)
		{
			foreach (var file in filesToLoad)
			{
				bool isFileFound = false;

				foreach (var filePath in _filesRootPaths)
				{
					var fileLocation = string.Format(filePath, file);
					if (File.Exists(fileLocation) == true)
					{
						var fileText = File.ReadAllText(fileLocation);
						scriptBuilder.Append(fileText);
						context.Response.AddFileDependency(fileLocation);
						isFileFound = true;
						break;
					}
				}
				if (!isFileFound)
				{
					context.Response.Headers.Add(file, "not-found");
				}
			}
		}

		protected abstract string UpdateGeneratedScript(string generatedScript);

		protected abstract void SetCustomContextOptions(HttpContextBase context);
	}
}
