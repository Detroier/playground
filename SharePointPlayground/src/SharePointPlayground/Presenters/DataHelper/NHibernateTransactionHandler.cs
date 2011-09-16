using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SharePointPlayground.Presenters.DataHelper
{
	public class NHibernateTransactionHandler
	{
		public static void RunInTransaction(ISession session, Action actionInTransaction)
		{
			using (var tx = session.BeginTransaction())
			{
				try
				{
					actionInTransaction.Invoke();
				}
				catch (Exception ex)
				{
					tx.Rollback();
					throw ex;
				}

				tx.Commit();
			}
		}
	}
}
