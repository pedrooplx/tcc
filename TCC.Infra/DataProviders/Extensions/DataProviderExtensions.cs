using System;
using System.Linq;
using System.Linq.Expressions;
using TCC.Domain.Abstract;

namespace TCC.Infra.DataProviders.Extensions
{
    public static class DataProviderExtensions
    {
        public static IQueryable<TEntity> WhereIdEqual<TEntity, Guid>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, Guid>> keyExpression,
            Guid keyValue
        ) where TEntity : EntityBase
        {
            var memberExpression = (MemberExpression)keyExpression.Body;
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, memberExpression.Member.Name);
            var equal = Expression.Equal(property, Expression.Constant(keyValue));
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, parameter);

            return source.Where(lambda);
        }
    }
}
