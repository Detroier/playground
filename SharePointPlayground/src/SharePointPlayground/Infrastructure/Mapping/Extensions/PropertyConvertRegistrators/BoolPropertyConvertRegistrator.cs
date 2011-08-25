using System;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class BoolPropertyConvertRegistrator : BasePropertyConvertRegistrator<bool>
	{
		protected override Func<object, bool> CreateConvertFunction()
		{
			return (x) => bool.Parse(x.ToString());
		}
	}
}
