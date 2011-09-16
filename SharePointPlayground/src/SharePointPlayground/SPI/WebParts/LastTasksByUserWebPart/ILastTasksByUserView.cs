using System;
using System.Collections.Generic;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.SPI.WebParts.LastTasksByUserWebPart
{
	public interface ILastTasksByUserView
	{
		IEnumerable<TaskListItemViewModel> Tasks { set; }
	}
}
