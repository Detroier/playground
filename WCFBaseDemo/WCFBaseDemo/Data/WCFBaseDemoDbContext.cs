using System.Data.Entity;
using WCFBaseDemo.Model;

namespace WCFBaseDemo.Data
{
	/// <summary>
	/// Code-first data context.
	/// </summary>
	public class WCFBaseDemoDbContext : DbContext
	{
		public WCFBaseDemoDbContext()
			: base("wcfBaseDemoConnectionString")
		{
		}

		public DbSet<Customer> Customers { get; set; }
	}
}
