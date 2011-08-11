using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPlayground.ViewModels
{
	public class TaskListItemViewModel
	{
		public int ID { get; set; }

		public string Title { get; set; }

		public string Status { get; set; }

		public Guid GUID { get; set; }

		public DateTime DueDate { get; set; }

		public DateTime StartDate { get; set; }

		public string Priority { get; set; }
	}
}
