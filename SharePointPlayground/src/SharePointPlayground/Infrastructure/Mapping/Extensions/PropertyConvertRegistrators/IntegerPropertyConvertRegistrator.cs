using System;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class IntegerPropertyConvertRegistrator : BasePropertyConvertRegistrator<int>
	{
		protected override Func<object, int> CreateConvertFunction()
		{
			return (x) => int.Parse(x.ToString());
		}
	}
}
