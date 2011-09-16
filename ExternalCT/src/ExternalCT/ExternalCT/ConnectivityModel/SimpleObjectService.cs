using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalCT.ConnectivityModel
{
	/// <summary>
	/// All the methods for retrieving, updating and deleting data are implemented in this class file.
	/// The samples below show the finder and specific finder method for Entity1.
	/// </summary>
	public class SimpleObjectService
	{
		/// <summary>
		/// This is a sample specific finder method for Entity1.
		/// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Entity1</returns>
		public static SimpleObject ReadItem(string id)
		{
			return new SimpleObject
				{
					Identifier1 = id,
					Message = "Message_" + id,
					AnotherMessage = "AnotherMessage_" + id,
					AndAnotherMessage = "Hello World!"
				};
		}
		/// <summary>
		/// This is a sample finder method for Entity1.
		/// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
		/// </summary>
		/// <returns>IEnumerable of Entities</returns>
		public static IEnumerable<SimpleObject> ReadList()
		{
			List<SimpleObject> objects = new List<SimpleObject>();

			for (int i = 0; i < 100; i++)
			{
				objects.Add(new SimpleObject
				{
					Identifier1 = i.ToString(),
					Message = "Message_" + i.ToString(),
					AnotherMessage = "AnotherMessage_" + i.ToString(),
					AndAnotherMessage = "Hello World!"
				});
			}

			return objects;
		}

		public static SimpleObject Create(SimpleObject newSimpleObject)
		{
			//throw new System.NotImplementedException();
			return newSimpleObject;
		}

		public static void Delete(string identifier1)
		{
			//throw new System.NotImplementedException();
		}

		public static void Update(SimpleObject simpleObject)
		{
			//throw new System.NotImplementedException();
		}

		public static IEnumerable<SimpleObject> ReadList1()
		{
			throw new System.NotImplementedException();
		}
	}
}