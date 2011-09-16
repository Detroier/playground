using NHibernate;
using SharePointPlayground.Helpers;
using SharePointPlayground.Model;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Commands
{
	public class AddPostCommand : SharePointPlayground.Commands.IAddPostCommand
	{
		private ISession _session;

		public AddPostCommand(ISessionFactory sessionFactory)
		{
			_session = sessionFactory.GetCurrentSession();
		}

		public void Execute(PostInsertViewModel viewModel)
		{
			var post = viewModel.MapTo<Post>();
			_session.Save(post);
		}
	}
}
