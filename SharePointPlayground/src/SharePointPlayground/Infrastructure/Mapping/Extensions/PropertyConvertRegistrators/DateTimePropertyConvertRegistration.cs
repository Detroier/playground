using System;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators
{
	public class DateTimePropertyConvertRegistration : BasePropertyConvertRegistrator<DateTime>
	{
		protected override Func<object, DateTime> CreateConvertFunction()
		{
			return (x) => x == null || string.IsNullOrEmpty(x.ToString()) ? DateTime.MinValue : Convert.ToDateTime(x);
		}
	}
}
