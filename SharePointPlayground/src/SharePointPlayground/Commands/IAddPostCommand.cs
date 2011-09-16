using System;
namespace SharePointPlayground.Commands
{
	public interface IAddPostCommand
	{
		void Execute(SharePointPlayground.ViewModels.PostInsertViewModel viewModel);
	}
}
