using WCFBaseDemo.Helpers;

namespace WCFBaseDemo.Services
{
	public class DummyService : IDummyService
	{
		private IHelloWriter _writer;

		public DummyService(IHelloWriter writer)
		{
			_writer = writer;
		}

		public string SayHello(string toWho)
		{
			return _writer.WriteHello(toWho);
		}
	}
}
