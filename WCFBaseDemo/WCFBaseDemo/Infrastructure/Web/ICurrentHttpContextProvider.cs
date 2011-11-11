using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WCFBaseDemo.Infrastructure.Web
{
	public interface ICurrentHttpContextProvider
	{
		HttpContextBase GetCurrentContext();
	}
}
