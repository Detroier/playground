using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFBaseDemo.Helpers
{
	public class AnotherHelloWriter : IHelloWriter
	{
		public string WriteHello(string toWho)
		{
			return toWho + ", Im another writer";
		}
	}
}
