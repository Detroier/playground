using System;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class StringPropertyRegistrator : BasePropertyConvertRegistrator<string>
	{
		protected override Func<object, string> CreateConvertFunction()
		{
			return (x) => x.ToString();
		}
	}
}
