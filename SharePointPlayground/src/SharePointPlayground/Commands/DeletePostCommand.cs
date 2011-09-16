using NHibernate;
using SharePointPlayground.Model;
using System;

namespace SharePointPlayground.Commands
{
	public class DeletePostCommand : SharePointPlayground.Commands.IDeletePostCommand
	{
		private ISession _session;

		public DeletePostCommand(ISessionFactory sessionFactory)
		{
			_session = sessionFactory.GetCurrentSession();
		}

		public void Execute(int postId)
		{
			var post = _session.Get<Post>(postId);
			_session.Delete(post);
			_session.Flush();
		}
	}
}
