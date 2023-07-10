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

            try
            {
                foreach (var property in typeof(TDto).GetProperties())
                {
                    var dtoValue = property.GetValue(dto);
                    var existingProperty = typeof(TEntity).GetProperty(property.Name);

                    if (existingProperty != null)
                    {
                        var existingValue = existingProperty.GetValue(existingEntity);

                        if (!Equals(dtoValue, existingValue))
                        {
                            var propertyType = existingProperty.PropertyType;

                            // Check if propertyType is Nullable<T> and dtoValue is null
                            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                if (dtoValue == null)
                                {
                                    changedFields.Add((GetPropertyExpression<TEntity>(property.Name), null));
                                    continue;
                                }

                                // Get the underlying value type of the nullable property
                                propertyType = Nullable.GetUnderlyingType(propertyType);
                            }

                            var convertedValue = Convert.ChangeType(dtoValue, propertyType);
                            changedFields.Add((GetPropertyExpression<TEntity>(property.Name), convertedValue));
                        }
                    }
                }

                return changedFields;
            }
            catch (Exception)
            {

                throw;
            }

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
