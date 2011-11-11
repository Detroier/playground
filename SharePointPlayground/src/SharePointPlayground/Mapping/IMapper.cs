namespace SharePointPlayground.Mapping
{
	public interface IMapper<TSource, TDestination>
	{
		TDestination Map(TSource source);

		TDestination Map(TSource source, TDestination destination);
	}
}
