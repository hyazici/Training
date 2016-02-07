using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace PoneraAdmin.Views.Templates.Models
{
    public static class PropertyNameHelper
    {
        public static IList<string> GetPropertyNames<T>(params Expression<Func<T, object>>[] propsToUpdate)
        {
            IList<string> propertyList = new List<string>();

            foreach (Expression<Func<T, object>> expression in propsToUpdate)
            {
                MemberExpression memberExpr = null;

                if (expression.Body.NodeType == ExpressionType.Convert)
                {
                    memberExpr = ((UnaryExpression)expression.Body).Operand as MemberExpression;
                }
                else if (expression.Body.NodeType == ExpressionType.MemberAccess)
                {
                    memberExpr = expression.Body as MemberExpression;
                }

                propertyList.Add(memberExpr.Member.Name);
            }

            return propertyList;
        }
    }
}