using System;
using System.Collections;
using System.Data.Entity;

namespace WCFBaseDemo.Infrastructure.Data
{
	public class InDictionaryTrackingContextFactory<T> : IDbContextFactory<T> where T : DbContext
	{
		private Func<T> _createContext;
		private Func<IDictionary> _trackingDictionary;
		private string _trackingKey;

		public InDictionaryTrackingContextFactory(Func<IDictionary> getTrackingDictionary, Func<T> createNewContext, string trackingKey)
		{
			_createContext = createNewContext;
			_trackingDictionary = getTrackingDictionary;
			_trackingKey = trackingKey;
		}

		public T GetContext()
		{
			var contextDictionary = _trackingDictionary.Invoke();
			if (contextDictionary.Contains(_trackingKey) == true)
			{
				var currentContextFromDictionary = contextDictionary[_trackingKey] as T;
				if (currentContextFromDictionary == null)
				{
					throw new ApplicationException("Null context was returned from dictionary");
				}
				return currentContextFromDictionary;
			}
			var newContext = _createContext.Invoke();
			contextDictionary.Add(_trackingKey, newContext);
			return newContext;
		}
	}
}
