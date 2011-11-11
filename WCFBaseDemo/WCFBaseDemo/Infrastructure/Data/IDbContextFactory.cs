using System.Data.Entity;

namespace WCFBaseDemo.Infrastructure.Data
{
	public interface IDbContextFactory<T> where T : DbContext
	{
		T GetContext();

	}
}