namespace WCFBaseDemo.Helpers
{
	public class HelloWriter : IHelloWriter
	{
		public string WriteHello(string toWho)
		{
			return "Hello " + toWho;
		}
	}
}
