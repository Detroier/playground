using System.Collections.Generic;
using NHibernate;

namespace SharePointPlayground.Infrastructure.Data
{
	public interface ISessionFactoryProvider
	{
		IEnumerable<ISessionFactory> GetSessionFactories();
	}
}
