using System.Data;

using Microsoft.SharePoint;

namespace SharePointPlayground.Queries.SP
{
	public class SPSiteDataQueryExecutor
	{
		private SPSiteDataQuery _dataQuery;

		public SPSiteDataQuery InnerQuery
		{
			get
			{
				return _dataQuery;
			}
		}

		public SPSiteDataQueryExecutor(string lists, string viewFields, string query, string webs, int rowLimit)
		{
			_dataQuery = new SPSiteDataQuery();

			if (string.IsNullOrEmpty(lists) == false)
			{
				_dataQuery.Lists = lists;
			}

			if (string.IsNullOrEmpty(viewFields) == false)
			{
				_dataQuery.ViewFields = viewFields;
			}

			if (string.IsNullOrEmpty(query) == false)
			{
				_dataQuery.Query = query;
			}

			_dataQuery.RowLimit = (uint)rowLimit;
		}

		public DataTable ExecuteQuery(SPWeb rootOfSearch)
		{
			return rootOfSearch.GetSiteData(_dataQuery);
		}
	}
}
