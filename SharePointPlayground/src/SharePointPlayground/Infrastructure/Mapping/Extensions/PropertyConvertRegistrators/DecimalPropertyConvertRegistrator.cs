using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class DecimalPropertyConvertRegistrator : BasePropertyConvertRegistrator<decimal>
	{
		protected override Func<object, decimal> CreateConvertFunction()
		{
			return (x) => Convert.ToDecimal(x);
		}
	}
}
