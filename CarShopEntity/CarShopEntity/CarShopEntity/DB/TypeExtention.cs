using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CarShopEntity.DB
{
    public static class TypeExtention
    {
        public static string GetMemberName<T, TValue>(this Expression<Func<T, TValue>> memSelector)
        {
            if (memSelector == null)
            {
                throw new ArgumentException("memberSelector");
            }

            var memberExpression = memSelector.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new NotSupportedException($"Expression of type {memSelector.Body.GetType().FullName} not supported.");
            }

            return memberExpression.Member.Name;
        }

    }
}