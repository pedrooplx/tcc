using System;
using System.Linq;
using System.Linq.Expressions;
using TCC.Domain.Entities.Abstract;

namespace TCC.Infra.DataProviders.Extensions
{
    public static class DataProviderExtensions
    {
        public static IQueryable<TEntity> WhereIdEqual<TEntity, Long>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, Long>> keyExpression,
            Long keyValue
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
