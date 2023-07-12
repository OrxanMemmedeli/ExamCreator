using CoreLayer.Entities;
using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.Filters
{
    public static class BaseFilterAlgorithm<TEntity> where TEntity : IEntityBase
    {
        // Filtr modeli (TFilter) istifadə edərək (TEntity) tipində filtr ifadəsi yaradır.
        public static Expression<Func<TEntity, bool>> GenerateFilterExpression<TFilter>(TFilter filterModel)
        {
            // TEntity tipi üçün parametr ifadəsi yaradılır.
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "entity");

            // Filtr ifadəsinə ilkin olaraq null dəyəri mənimsədilir.
            Expression filterExpression = null;

            // Filtr modelinə uyğun mövcud field-lər tapılır.
            PropertyInfo[] filterProperties = typeof(TFilter).GetProperties()
                .Where(p => p.PropertyType != typeof(FilterType))
                .ToArray();

            // hər bir filed-ə uyğun filtr təyin edilir.
            foreach (var property in filterProperties)
            {
                string propertyName = property.Name;
                string propertyValue = property.GetValue(filterModel)?.ToString();

                if (string.IsNullOrWhiteSpace(propertyValue))
                    continue;

                filterExpression = AddFilterExpressions(parameter, propertyName, propertyValue, filterExpression, filterModel);

            }

            // Filtr ifadəsi null deyilsə lambda ifadəsinə çevreilir.
            if (filterExpression != null)
            {
                Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
                return lambda;
            }

            return null;
        }

        private static FilterType GetFilterType<TFilter>(string propertyName, TFilter filterModel)
        {
            //Property ilə eyni adla adlandırılmış və propertini xarakterizə edən porperty-ni təyin edir.
            PropertyInfo filterTypeProperty = typeof(TFilter).GetProperty($"{propertyName}FilterType");
            if (filterTypeProperty != null && filterTypeProperty.GetValue(filterModel) is FilterType filterType)
                return filterType;

            // Default to FilterType.Equal if the property is not found or invalid
            return FilterType.Equal;
        }

        private static Expression AddFilterExpressions<TFilter>(ParameterExpression parameter, string propertyName, string propertyValue, Expression filterExpression, TFilter filterModel)
        {
            //Entity parametri ve Filterin eyni adli propName-ə əsasən prop yaradılır. 
            MemberExpression property = Expression.Property(parameter, propertyName);
            MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            Expression equality = null;

            FilterType filterType = GetFilterType<TFilter>(propertyName, filterModel);


            if (property.Type == typeof(string))
            {
                switch (filterType)
                {
                    case FilterType.Equal:
                        equality = Expression.Equal(property, Expression.Constant(propertyValue));
                        break;
                    case FilterType.NotEqual:
                        equality = Expression.NotEqual(property, Expression.Constant(propertyValue));
                        break;
                    case FilterType.Contains:
                        equality = Expression.Call(property, containsMethod, Expression.Constant(propertyValue));
                        break;
                    default:
                        throw new NotSupportedException($"Filter type '{filterType}' is not supported for string properties.");
                }
            }
            else if (property.Type == typeof(DateTime) || property.Type == typeof(DateTime?))
            {
                DateTime? propertyDateTimeValue = DateTime.TryParse(propertyValue, out DateTime parsedValue)
                    ? parsedValue.Date
                    : (DateTime?)null;

                if (propertyDateTimeValue != null)
                {
                    Expression propertyYear = Expression.Property(property, "Year");
                    Expression propertyMonth = Expression.Property(property, "Month");
                    Expression propertyDay = Expression.Property(property, "Day");

                    switch (filterType)
                    {
                        case FilterType.Equal:
                            equality = Expression.AndAlso(
                                Expression.Equal(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                Expression.AndAlso(
                                    Expression.Equal(propertyMonth, Expression.Constant(propertyDateTimeValue.Value.Month)),
                                    Expression.Equal(propertyDay, Expression.Constant(propertyDateTimeValue.Value.Day))
                                )
                            );
                            break;
                        case FilterType.NotEqual:
                            equality = Expression.OrElse(
                                Expression.NotEqual(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                Expression.OrElse(
                                    Expression.NotEqual(propertyMonth, Expression.Constant(propertyDateTimeValue.Value.Month)),
                                    Expression.NotEqual(propertyDay, Expression.Constant(propertyDateTimeValue.Value.Day))
                                )
                            );
                            break;
                        case FilterType.GreaterThan:
                            equality = Expression.OrElse(
                                Expression.GreaterThan(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                Expression.OrElse(
                                    Expression.AndAlso(
                                        Expression.Equal(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                        Expression.GreaterThan(propertyMonth, Expression.Constant(propertyDateTimeValue.Value.Month))
                                    ),
                                    Expression.AndAlso(
                                        Expression.Equal(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                        Expression.AndAlso(
                                            Expression.Equal(propertyMonth, Expression.Constant(propertyDateTimeValue.Value.Month)),
                                            Expression.GreaterThan(propertyDay, Expression.Constant(propertyDateTimeValue.Value.Day))
                                        )
                                    )
                                )
                            );
                            break;
                        case FilterType.LessThan:
                            equality = Expression.OrElse(
                                Expression.LessThan(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                Expression.OrElse(
                                    Expression.AndAlso(
                                        Expression.Equal(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                        Expression.LessThan(propertyMonth, Expression.Constant(propertyDateTimeValue.Value.Month))
                                    ),
                                    Expression.AndAlso(
                                        Expression.Equal(propertyYear, Expression.Constant(propertyDateTimeValue.Value.Year)),
                                        Expression.AndAlso(
                                            Expression.Equal(propertyMonth, Expression.Constant(propertyDateTimeValue.Value.Month)),
                                            Expression.LessThan(propertyDay, Expression.Constant(propertyDateTimeValue.Value.Day))
                                        )
                                    )
                                )
                            );
                            break;
                        default:
                            throw new NotSupportedException($"Filter type '{filterType}' is not supported for DateTime properties.");
                    }
                }
            }
            else if (property.Type == typeof(decimal))
            {
                decimal propertyDecimalValue;
                if (decimal.TryParse(propertyValue, out propertyDecimalValue))
                {
                    switch (filterType)
                    {
                        case FilterType.Equal:
                            equality = Expression.Equal(property, Expression.Constant(propertyDecimalValue));
                            break;
                        case FilterType.NotEqual:
                            equality = Expression.NotEqual(property, Expression.Constant(propertyDecimalValue));
                            break;
                        case FilterType.GreaterThan:
                            equality = Expression.GreaterThan(property, Expression.Constant(propertyDecimalValue));
                            break;
                        case FilterType.LessThan:
                            equality = Expression.LessThan(property, Expression.Constant(propertyDecimalValue));
                            break;
                        default:
                            throw new NotSupportedException($"Filter type '{filterType}' is not supported for decimal properties.");
                    }
                }
            }
            else
            {
                throw new NotSupportedException($"Filtering is not supported for properties of type '{property.Type}'.");
            }

            return filterExpression == null ? equality : Expression.AndAlso(filterExpression, equality);
        }
    }

}
