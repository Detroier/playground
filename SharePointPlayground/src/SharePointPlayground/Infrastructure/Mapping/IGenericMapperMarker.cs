using System;

namespace SharePointPlayground.Infrastructure.Mapping
{
	public interface IGenericMapperMarker
	{
		Type GetDestinationType();

		Type GetSourceType();
	}
}
