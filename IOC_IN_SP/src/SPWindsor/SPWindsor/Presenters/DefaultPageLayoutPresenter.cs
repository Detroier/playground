using System.Web.UI.WebControls;
using Castle.Core.Logging;

namespace SPWindsor.Presenters
{
	public class DefaultPageLayoutPresenter : IDefaultPageLayoutPresenter
	{
		private ILogger _logger;

		public DefaultPageLayoutPresenter(ILogger logger)
		{
			_logger = logger;
		}

		public void FillControls(Label lblHelloWsorld)
		{
			lblHelloWsorld.Text = "Hello world from injected presenter!";
		}
	}
}
