using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPlayground.ViewModels
{
	public class PageOfItems<T> : List<T>
	{
		public PageOfItems(IEnumerable<T> items, int pageNumber, int totalCountOfItems, int pageSize)
		{
			AddRange(items);
			PageNumber = pageNumber;
			TotalCountOfItems = totalCountOfItems;
			PageSize = pageSize;
		}

		public int TotalPageCount
		{
			get { return (int)Math.Ceiling((double)TotalCountOfItems / PageSize); }
		}

		public int PageNumber { get; set; }

		public int TotalCountOfItems { get; set; }

		public int PageSize { get; set; }

		public bool HasPreviousPage
		{
			get
			{
				return PageNumber > 1;
			}
		}

		public bool HasNextPage
		{
			get
			{
				return PageNumber < TotalPageCount;
			}
		}
	}
}
