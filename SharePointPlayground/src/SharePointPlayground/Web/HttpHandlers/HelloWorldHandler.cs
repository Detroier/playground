using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharePointPlayground.Infrastructure.HttpHandlers;

namespace SharePointPlayground.Web.HttpHandlers
{
	public class HelloWorldHandler : JSONResultHandler
	{
		protected override object ExecuteRequest(System.Web.HttpRequest request)
		{
			return "HEllo World!";
		}
	}
}
