using System.Collections.Generic;
using Microsoft.SharePoint.Utilities;
using SharePointPlayground.SPI.WebParts.LastTasksByUserWebPart;

namespace SharePointPlayground.Presenters
{
	public class LastTasksByUserPresenterWithScope : ILastTasksByUserPresenter
	{
		private ILastTasksByUserPresenter _innerPresenter;

		public LastTasksByUserPresenterWithScope(ILastTasksByUserPresenter innerPresenter)
		{
			_innerPresenter = innerPresenter;
		}

		public void InitView(ILastTasksByUserView view)
		{
			using (SPMonitoredScope monitoredScope = new SPMonitoredScope("LastTasksByUserPresenter -> InitView"))
			{
				_innerPresenter.InitView(view);
			}
		}

		public void DeleteTaskByItemId(int itemId)
		{
			using (SPMonitoredScope monitoredScope = new SPMonitoredScope("LastTasksByUserPresenter -> DeleteTaskByItemId"))
			{
				_innerPresenter.DeleteTaskByItemId(itemId);
			}
		}
	}
}
