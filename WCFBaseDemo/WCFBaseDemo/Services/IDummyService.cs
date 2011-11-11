using System.ServiceModel;

namespace WCFBaseDemo.Services
{
	[ServiceContract]
	public interface IDummyService
	{
		[OperationContract]
		string SayHello(string toWho);
	}
}
