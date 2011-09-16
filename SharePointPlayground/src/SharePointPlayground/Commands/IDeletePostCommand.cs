using System;

namespace SharePointPlayground.Commands
{
	public interface IDeletePostCommand
	{
		void Execute(int postId);
	}
}
