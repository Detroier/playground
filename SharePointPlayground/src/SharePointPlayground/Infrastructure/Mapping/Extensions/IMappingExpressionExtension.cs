using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using Microsoft.SharePoint;
using System.Data;
using SharePointPlayground.Infrastructure.Mapping.Extensions.PropertyConvertRegistrators;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions
{
	public static class IMappingExpressionExtension
	{
		#region Mapping for SPItems

		/// <summary>
		/// Auto configures mapping of SPItem.
		/// </summary>
		/// <typeparam name="Tsource">The type of the source.</typeparam>
		/// <typeparam name="Tdestination">The type of the destination.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static IMappingExpression<Tsource, Tdestination> AutoConfigureForSPItem<Tsource, Tdestination>(this IMappingExpression<Tsource, Tdestination> expression)
			where Tsource : SPListItem
		{
			return expression.AutoConfigureForSPItem(null);
		}

		/// <summary>
		/// Auto configures mapping of SPItem.
		/// </summary>
		/// <typeparam name="Tsource">The type of the source.</typeparam>
		/// <typeparam name="Tdestination">The type of the destination.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <param name="membersToIgnore">The members to ignore.</param>
		/// <returns></returns>
		public static IMappingExpression<Tsource, Tdestination> AutoConfigureForSPItem<Tsource, Tdestination>(this IMappingExpression<Tsource, Tdestination> expression, params Expression<Func<Tdestination, object>>[] membersToIgnore)
			where Tsource : SPListItem
		{
			var propertiesToIgnore = GetPropertiesToIgnore<Tdestination>(membersToIgnore);
			var propertiesToMap = typeof(Tdestination).GetProperties();

			ConfigureMappingExpression<Tsource, Tdestination>(expression, propertiesToIgnore, propertiesToMap);

			return expression;
		}

		/// <summary>
		/// Configures the mapping expression.
		/// </summary>
		/// <typeparam name="Tsource">The type of the source.</typeparam>
		/// <typeparam name="Tdestination">The type of the destination.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <param name="propertiesToIgnore">The properties to ignore.</param>
		/// <param name="propertiesToMap">The properties to map.</param>
		private static void ConfigureMappingExpression<Tsource, Tdestination>(IMappingExpression<Tsource, Tdestination> expression, string[] propertiesToIgnore, PropertyInfo[] propertiesToMap)
			where Tsource : SPListItem
		{
			var propertyConversionRegistrator = new PropertyConversionRegistrator();

			foreach (var property in propertiesToMap)
			{
				if (propertiesToIgnore.FirstOrDefault(x => x == property.Name) == null)
				{
					propertyConversionRegistrator.TryRegisterProperty(expression, property);
				}
			}
		}

		#endregion

		#region Mapping for Data Rows

		/// <summary>
		/// Auto configures mapping of SPItem.
		/// </summary>
		/// <typeparam name="Tsource">The type of the source.</typeparam>
		/// <typeparam name="Tdestination">The type of the destination.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static IMappingExpression<Tsource, Tdestination> AutoConfigureForDataRow<Tsource, Tdestination>(this IMappingExpression<Tsource, Tdestination> expression)
			where Tsource : DataRow
		{
			return expression.AutoConfigureForDataRow(null);
		}

		/// <summary>
		/// Auto configures mapping of SPItem.
		/// </summary>
		/// <typeparam name="Tsource">The type of the source.</typeparam>
		/// <typeparam name="Tdestination">The type of the destination.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <param name="membersToIgnore">The members to ignore.</param>
		/// <returns></returns>
		public static IMappingExpression<Tsource, Tdestination> AutoConfigureForDataRow<Tsource, Tdestination>(this IMappingExpression<Tsource, Tdestination> expression, params Expression<Func<Tdestination, object>>[] membersToIgnore)
			where Tsource : DataRow
		{
			var propertiesToIgnore = GetPropertiesToIgnore<Tdestination>(membersToIgnore);
			var propertiesToMap = typeof(Tdestination).GetProperties();

			ConfigureMappingExpressionForDataRow<Tsource, Tdestination>(expression, propertiesToIgnore, propertiesToMap);

			return expression;
		}

		/// <summary>
		/// Configures the mapping expression.
		/// </summary>
		/// <typeparam name="Tsource">The type of the source.</typeparam>
		/// <typeparam name="Tdestination">The type of the destination.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <param name="propertiesToIgnore">The properties to ignore.</param>
		/// <param name="propertiesToMap">The properties to map.</param>
		private static void ConfigureMappingExpressionForDataRow<Tsource, Tdestination>(IMappingExpression<Tsource, Tdestination> expression, string[] propertiesToIgnore, PropertyInfo[] propertiesToMap)
			where Tsource : DataRow
		{
			var propertyConversionRegistrator = new PropertyConversionRegistrator();

			foreach (var property in propertiesToMap)
			{
				if (propertiesToIgnore.FirstOrDefault(x => x == property.Name) == null)
				{
					propertyConversionRegistrator.TryRegisterProperty(expression, property);
				}
			}
		}

		#endregion

		/// <summary>
		/// Gets the properties to ignore.
		/// </summary>
		/// <typeparam name="Tdestination">The type of the destination.</typeparam>
		/// <param name="membersToIgnore">The members to ignore.</param>
		/// <param name="propertiesToIgnore">The properties to ignore.</param>
		/// <returns></returns>
		private static string[] GetPropertiesToIgnore<Tdestination>(Expression<Func<Tdestination, object>>[] membersToIgnore)
		{
			var propertiesToIgnoreList = new List<string>();

			if (membersToIgnore != null)
			{
				foreach (Expression<Func<Tdestination, object>> memberToIgnore in membersToIgnore)
				{
					var propertyName = FindProperty(memberToIgnore).Name;
					propertiesToIgnoreList.Add(propertyName);
				}
			}

			return propertiesToIgnoreList.ToArray();
		}

		/// <summary>
		/// Finds the property.
		/// Taken from Automapper type helper.
		/// </summary>
		/// <param name="lambdaExpression">The lambda expression.</param>
		/// <returns></returns>
		private static MemberInfo FindProperty(LambdaExpression lambdaExpression)
		{
			Expression expressionToCheck = lambdaExpression;

			bool done = false;

			while (!done)
			{
				switch (expressionToCheck.NodeType)
				{
					case ExpressionType.Convert:
						expressionToCheck = ((UnaryExpression)expressionToCheck).Operand;
						break;
					case ExpressionType.Lambda:
						expressionToCheck = ((LambdaExpression)expressionToCheck).Body;
						break;
					case ExpressionType.MemberAccess:
						var memberExpression = ((MemberExpression)expressionToCheck);

						if (memberExpression.Expression.NodeType != ExpressionType.Parameter &&
							memberExpression.Expression.NodeType != ExpressionType.Convert)
						{
							throw new ArgumentException(string.Format("Expression '{0}' must resolve to top-level member.", lambdaExpression), "lambdaExpression");
						}

						MemberInfo member = memberExpression.Member;

						return member;
					default:
						done = true;
						break;
				}
			}

			return null;
		}
	}
}