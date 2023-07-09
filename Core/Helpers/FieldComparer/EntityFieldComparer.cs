using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.FieldComparer
{
    public static class EntityFieldComparer<TDto, TEntity>
        where TEntity : class
    {
        public static List<(Expression<Func<TEntity, object>> PropertyExpression, object Value)> GetChangedFields(TDto dto, TEntity existingEntity)
        {
            List<(Expression<Func<TEntity, object>> PropertyExpression, object Value)> changedFields = new List<(Expression<Func<TEntity, object>> PropertyExpression, object Value)>();

            foreach (var property in typeof(TDto).GetProperties())
            {
                var dtoValue = property.GetValue(dto);
                var existingValue = property.GetValue(existingEntity);

                if (!Equals(dtoValue, existingValue))
                {
                    Expression<Func<TEntity, object>> propertyExpression = GetPropertyExpression<TEntity>(property.Name);
                    changedFields.Add((propertyExpression, dtoValue));
                }
            }

            return changedFields;
        }

        private static Expression<Func<TEntity, object>> GetPropertyExpression<TEntity>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var propertyExpression = Expression.Property(parameter, propertyName);
            var castExpression = Expression.Convert(propertyExpression, typeof(object));
            return Expression.Lambda<Func<TEntity, object>>(castExpression, parameter);
        }
    }


}
