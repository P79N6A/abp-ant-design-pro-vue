using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Niue.Application.BaseDto
{
    /// <summary>
    /// ≈≈–ÚDTO
    /// </summary>
    [Serializable]
    public class SortDto
    {
        /// <summary>
        /// ≈≈–Ú◊÷∂Œ
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// ≈≈–Ú∑Ω Ω
        /// </summary>
        public string SortOrder { get; set; }
    }

    /// <summary>
    /// ≈≈–Ú¿©’π
    /// </summary>
    public static class SortExtensions
    {
        /// <summary>
        /// IQueryable’˝–Ú(asc)≈≈–Ú°£
        /// <code>List&#60;T&#62; list = new List&#60;T&#62;();
        /// IQueryable&#60;T&#62; queryable = list.AsQueryable();
        /// queryable.OrderBy("SortField").ToList();</code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName)
        {
            return QueryableSort<T>.OrderBy(queryable, propertyName, false);
        }

        /// <summary>
        /// IQueryableµπ–Ú(desc)≈≈–Ú°£
        /// <code>List&#60;T&#62; list = new List&#60;T&#62;();
        /// IQueryable&#60;T&#62; queryable = list.AsQueryable();
        /// queryable.OrderByDescending("SortField").ToList();</code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> queryable, string propertyName)
        {
            return QueryableSort<T>.OrderBy(queryable, propertyName, true);
        }

        private static class QueryableSort<T>
        {
            // ReSharper disable once StaticMemberInGenericType
            private static readonly Dictionary<string, LambdaExpression> Cache =
                new Dictionary<string, LambdaExpression>();

            public static IQueryable<T> OrderBy(IQueryable<T> queryable, string propertyName, bool desc)
            {
                dynamic keySelector = GetLambdaExpression(propertyName);
                return desc
                    ? Queryable.OrderByDescending(queryable, keySelector)
                    : Queryable.OrderBy(queryable, keySelector);
            }

            private static LambdaExpression GetLambdaExpression(string propertyName)
            {
                if (Cache.ContainsKey(propertyName)) return Cache[propertyName];
                var param = Expression.Parameter(typeof (T));
                var body = Expression.Property(param, propertyName);
                var keySelector = Expression.Lambda(body, param);
                Cache[propertyName] = keySelector;
                return keySelector;
            }
        }
    }
}
