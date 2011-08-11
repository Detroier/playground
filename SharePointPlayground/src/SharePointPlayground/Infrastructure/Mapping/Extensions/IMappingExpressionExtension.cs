using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using Microsoft.SharePoint;

namespace SharePointPlayground.Infrastructure.Mapping.Extensions
{
	public static class IMappingExpressionExtension
	{
		public static IMappingExpression<Tsource, Tdestination> AutoConfigureForSPItem<Tsource, Tdestination>(this IMappingExpression<Tsource, Tdestination> expression)
			where Tsource : SPListItem
		{
			return expression.AutoConfigureForSPItem(null);
		}

		public static IMappingExpression<Tsource, Tdestination> AutoConfigureForSPItem<Tsource, Tdestination>(this IMappingExpression<Tsource, Tdestination> expression, params Expression<Func<Tdestination, object>>[] membersToIgnore)
			where Tsource : SPListItem
		{

			var propertiesToIgnore = new string[] { };
			var propertiesToMap = typeof(Tdestination).GetProperties();

			if (membersToIgnore != null)
			{
				var propertiesToIgnoreList = new List<string>();

				foreach (Expression<Func<Tdestination, object>> memberToIgnore in membersToIgnore)
				{
					var propertyName = FindProperty(memberToIgnore).Name;
					propertiesToIgnoreList.Add(propertyName);
				}
				propertiesToIgnore = propertiesToIgnoreList.ToArray();
			}


			foreach (var property in propertiesToMap)
			{
				if (propertiesToIgnore.FirstOrDefault(x => x == property.Name) == null)
				{
					var propertyName = property.Name;
					expression.ForMember(propertyName, opt => opt.MapFrom(item => item[propertyName]));
				}
			}
			return expression;
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
