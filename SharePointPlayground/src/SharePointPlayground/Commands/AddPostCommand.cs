using NHibernate;
using SharePointPlayground.Mapping;
using SharePointPlayground.Model;
using SharePointPlayground.ViewModels;

namespace SharePointPlayground.Commands
{
	public class AddPostCommand : SharePointPlayground.Commands.IAddPostCommand
	{
		private ISession _session;
		private IMapper<PostInsertViewModel, Post> _postViewMapper;

		public AddPostCommand(ISessionFactory sessionFactory, IMapper<PostInsertViewModel, Post> postViewMapper)
		{
			_session = sessionFactory.GetCurrentSession();
			_postViewMapper = postViewMapper;
		}

		public void Execute(PostInsertViewModel viewModel)
		{
			var post = _postViewMapper.Map(viewModel);
			_session.Save(post);
		}
	}
}
