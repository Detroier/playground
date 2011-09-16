using System.Collections.Generic;
using SharePointPlayground.SPI.WebParts.LastTasksByUserWebPart;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Presenters
{
	public interface ILastTasksByUserPresenter
	{
		/// <summary>
		/// Initializes the view.
		/// </summary>
		/// <param name="view"></param>
		void InitView(ILastTasksByUserView view);

		/// <summary>
		/// Deletes the task by item id.
		/// </summary>
		/// <param name="itemId">The item id.</param>
		void DeleteTaskByItemId(int itemId);
	}
}
