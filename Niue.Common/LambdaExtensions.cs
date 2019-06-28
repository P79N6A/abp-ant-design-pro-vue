using System;
using System.Linq.Expressions;

namespace Niue.Common
{
    public static class LambdaExtensions
    {
        public static Expression<Func<T, bool>> SearchExpression<T>(T t)
        {
            Expression<Func<T, bool>> expression = o => true;
            if (t == null)
            {
                return expression;
            }
            var properties =
                t.GetType()
                    .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (properties.Length <= 0)
            {
                return expression;
            }
            foreach (var propertyInfo in properties)
            {
                //var name = propertyInfo.Name;
                if (propertyInfo.PropertyType == typeof(string))
                {
                    if (propertyInfo.GetValue(t, null) != null)
                    {
                        var value = propertyInfo.GetValue(t, null).ToString();
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            expression = expression.And(o => propertyInfo.GetValue(o, null) != null && propertyInfo.GetValue(o, null).ToString().Contains(value));
                        }
                    }
                }
                if (propertyInfo.PropertyType == typeof(int))
                {
                    var value = Convert.ToInt32(propertyInfo.GetValue(t, null));
                    if (value > 0)
                    {
                        expression = expression.And(o => Convert.ToInt32(propertyInfo.GetValue(o, null)) == value);
                    }
                }
            }
            return expression;
        }

        public static Expression<Func<T, bool>> CreateExpression<T>(Expression<Func<T, bool>> expression = null)
        {
            return expression ?? (o => true);
        }

        public static Expression<Func<T, bool>> AdditionalExpression<T>(Expression<Func<T, bool>> expression, Expression<Func<T, bool>> andExpression)
        {
            expression = expression.And(andExpression);
            return expression;
        }
    }

    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> True<T>()
        {
            return f => true;
        }

        public static Expression<Func<T, bool>> False<T>()
        {
            return f => false;
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1,
            Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.Or(expression1.Body, invokedExpression),
                expression1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1,
            Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.And(expression1.Body, invokedExpression),
                expression1.Parameters);
        }
    }
}
