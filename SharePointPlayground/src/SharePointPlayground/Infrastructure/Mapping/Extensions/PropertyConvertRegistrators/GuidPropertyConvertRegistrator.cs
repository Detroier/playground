using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class GuidPropertyConvertRegistrator : BasePropertyConvertRegistrator<Guid>
	{
		protected override Func<object, Guid> CreateConvertFunction()
		{
			return (x) => new Guid(x.ToString());
		}
	}
}
