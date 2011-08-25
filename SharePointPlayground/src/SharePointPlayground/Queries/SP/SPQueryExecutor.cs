using Microsoft.SharePoint;

namespace SharePointPlayground.Queries.SP
{
	public class SPQueryExecutor
	{
		private SPQuery _query;

		public SPQuery InnerQuery
		{
			get
			{
				return _query;
			}
		}

		public SPQueryExecutor(string query, int rowLimit)
		{
			_query = new SPQuery();
			_query.Query = query;
			_query.RowLimit = (uint)rowLimit;
		}

		public SPListItemCollection ExecuteQuery(SPList rootOfSearch)
		{
			return rootOfSearch.GetItems(_query);
		}
	}
}
