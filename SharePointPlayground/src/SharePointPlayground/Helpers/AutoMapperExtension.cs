using System.Collections;
using System.Collections.Generic;
using System.Data;
using AutoMapper;

namespace SharePointPlayground.Helpers
{
	/// <summary>
	/// Extension for easier access to mappings.
	/// </summary>
	public static class AutoMapperExtension
	{
		/// <summary>
		/// Maps to.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="self">The self.</param>
		/// <returns></returns>
		public static List<TResult> MapTo<TResult>(this IEnumerable self)
		{
			return (List<TResult>)Mapper.Map(self, self.GetType(), typeof(List<TResult>));
		}

		/// <summary>
		/// Maps to.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="self">The self.</param>
		/// <returns></returns>
		public static List<TResult> MapTo<TResult>(this DataTable self)
		{
			return (List<TResult>)Mapper.Map(self.Rows, self.Rows.GetType(), typeof(List<TResult>));
		}

		/// <summary>
		/// Maps to.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="self">The self.</param>
		/// <returns></returns>
		public static TResult MapTo<TResult>(this object self)
		{
			return (TResult)Mapper.Map(self, self.GetType(), typeof(TResult));
		}

		/// <summary>
		/// Maps to.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="self">The self.</param>
		/// <param name="output">The output.</param>
		/// <returns></returns>
		public static TResult MapTo<TResult>(this object self, TResult output)
		{
			return (TResult)Mapper.Map(self, output, self.GetType(), typeof(TResult));
		}
	}
}
