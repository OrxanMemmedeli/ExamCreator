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

                if (!string.IsNullOrEmpty(propertyValue))
                {
                    filterExpression = AddFilterExpressions(parameter, propertyName, propertyValue, filterExpression, filterModel);
                }
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
            if (filterTypeProperty != null)
            {
                var filterTypeValue = filterTypeProperty.GetValue(filterModel);
                if (filterTypeValue != null && filterTypeValue is FilterType filterType)
                {
                    return filterType;
                }
            }
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
            else if (property.Type == typeof(DateTime))
            {
                DateTime propertyDateTimeValue;
                if (DateTime.TryParse(propertyValue, out propertyDateTimeValue))
                {
                    propertyDateTimeValue = propertyDateTimeValue.Date; // Extract the date part

                    switch (filterType)
                    {
                        case FilterType.Equal:
                            equality = Expression.Equal(
                                Expression.Property(property, "Year"),
                                Expression.Constant(propertyDateTimeValue.Year)
                            );
                            equality = Expression.AndAlso(
                                equality,
                                Expression.Equal(
                                    Expression.Property(property, "Month"),
                                    Expression.Constant(propertyDateTimeValue.Month)
                                )
                            );
                            equality = Expression.AndAlso(
                                equality,
                                Expression.Equal(
                                    Expression.Property(property, "Day"),
                                    Expression.Constant(propertyDateTimeValue.Day)
                                )
                            );
                            break;
                        case FilterType.NotEqual:
                            equality = Expression.NotEqual(
                                Expression.Property(property, "Year"),
                                Expression.Constant(propertyDateTimeValue.Year)
                            );
                            equality = Expression.OrElse(
                                equality,
                                Expression.NotEqual(
                                    Expression.Property(property, "Month"),
                                    Expression.Constant(propertyDateTimeValue.Month)
                                )
                            );
                            equality = Expression.OrElse(
                                equality,
                                Expression.NotEqual(
                                    Expression.Property(property, "Day"),
                                    Expression.Constant(propertyDateTimeValue.Day)
                                )
                            );
                            break;
                        case FilterType.GreaterThan:
                            equality = Expression.GreaterThan(
                                Expression.Property(property, "Value"),
                                Expression.Constant(propertyDateTimeValue.Date)
                            );
                            break;
                        case FilterType.LessThan:
                            equality = Expression.LessThan(
                                Expression.Property(property, "Value"),
                                Expression.Constant(propertyDateTimeValue.Date)
                            );
                            break;
                        default:
                            throw new NotSupportedException($"Filter type '{filterType}' is not supported for DateTime properties.");
                    }
                }
            }
            else if (property.Type == typeof(DateTime?))
            {
                DateTime? propertyDateTimeValue = null;
                if (DateTime.TryParse(propertyValue, out DateTime parsedValue))
                {
                    propertyDateTimeValue = parsedValue.Date;
                }
                if (propertyDateTimeValue != default(DateTime))
                {
                    switch (filterType)
                    {
                        case FilterType.Equal:
                            equality = Expression.Equal(
                                Expression.Property(Expression.Property(property, "Value"), "Year"),
                                Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Year)
                            );
                            equality = Expression.AndAlso(
                                equality,
                                Expression.Equal(
                                    Expression.Property(Expression.Property(property, "Value"), "Month"),
                                    Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Month)
                                )
                            );
                            equality = Expression.AndAlso(
                                equality,
                                Expression.Equal(
                                    Expression.Property(Expression.Property(property, "Value"), "Day"),
                                    Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Day)
                                )
                            );
                            break;
                        case FilterType.NotEqual:
                            equality = Expression.NotEqual(
                                Expression.Property(Expression.Property(property, "Value"), "Year"),
                                Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Year)
                            );
                            equality = Expression.OrElse(
                                equality,
                                Expression.NotEqual(
                                    Expression.Property(Expression.Property(property, "Value"), "Month"),
                                    Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Month)
                                )
                            );
                            equality = Expression.OrElse(
                                equality,
                                Expression.NotEqual(
                                    Expression.Property(Expression.Property(property, "Value"), "Day"),
                                    Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Day)
                                )
                            );
                            break;
                        case FilterType.GreaterThan:
                            equality = Expression.GreaterThan(
                                Expression.Property(Expression.Property(property, "Value"), "Date"),
                                Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Date)
                            );
                            break;
                        case FilterType.LessThan:
                            equality = Expression.LessThan(
                                Expression.Property(Expression.Property(property, "Value"), "Date"),
                                Expression.Constant(propertyDateTimeValue.GetValueOrDefault().Date)
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
