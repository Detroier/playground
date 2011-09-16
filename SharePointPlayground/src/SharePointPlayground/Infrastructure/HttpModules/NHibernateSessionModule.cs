using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using SharePointPlayground.Infrastructure.Data;
using SharePointPlayground.Infrastructure.Framework;

namespace SharePointPlayground.Infrastructure.HttpModules
{
	public class NHibernateSessionModule : IHttpModule
	{
		private HttpApplication app;
		private ISessionFactoryProvider sfp;

		public void Init(HttpApplication context)
		{
			app = context;
			sfp = (ISessionFactoryProvider)
					  context.Application[SessionFactoryProvider.Key];
			context.BeginRequest += ContextBeginRequest;
			context.EndRequest += ContextEndRequest;
		}

		private void ContextBeginRequest(object sender, EventArgs e)
		{
			foreach (var sf in sfp.GetSessionFactories())
			{
				var localFactory = sf;
				LazySessionContext.Bind(
					new Lazy<ISession>(() => BeginSession(localFactory)),
					sf);
			}
		}

		private static ISession BeginSession(ISessionFactory sf)
		{
			var session = sf.OpenSession();
			session.BeginTransaction();
			return session;
		}

		private void ContextEndRequest(object sender, EventArgs e)
		{
			foreach (var sf in sfp.GetSessionFactories())
			{
				var session = LazySessionContext.UnBind(sf);
				if (session == null) continue;
				EndSession(session, app);
			}
		}

		private static void EndSession(ISession session, HttpApplication application)
		{
			//TODO: What about rollbacks? => what to do then?
			//error module do the rollbacks?
			//transaction isn't automatically rollbacked!
			if (application.Context.Error != null && session.Transaction != null && session.Transaction.IsActive)
			{
				session.Transaction.Rollback();
			}
			else if (session.Transaction != null && session.Transaction.IsActive)
			{
				session.Transaction.Commit();
			}
			session.Dispose();
		}

		public void Dispose()
		{
			app.BeginRequest -= ContextBeginRequest;
			app.EndRequest -= ContextEndRequest;
		}
	}
}