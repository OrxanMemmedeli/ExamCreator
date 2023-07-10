using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.Extensions
{
    //Faylın adı fərqli olsasa da partial class olduğun üçün clasın adını ümumi olaraq saxlayırıq
    /// <summary>
    /// Entity-ər üçün Extension class ()
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        /// method vasitəsi ilə property-nin editlənə bilib bilmədiyi yoxlanılır. 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool IsEditable(this PropertyInfo propertyInfo)
        {
            //info məlumatı null və ya yazıla bilən deyilsə 
            if(propertyInfo == null || !propertyInfo.CanWrite) 
                return false;

            if(propertyInfo.PropertyType == typeof(string)) 
                return true;

            //Məntiq olaraq Entity daxilində olan Class və Collection tipli dəyərlər dəyişdirilməməlidir
            if (propertyInfo.PropertyType.IsClass || typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                return false;

            return true;
        }

        /// <summary>
        /// Entity daxilində sadecə olaraq dəyişilməsi lazım olan property-nin value-sunun dəyişdirilməsi
        /// </summary>
        /// <typeparam name="TEntity">Entity model (onun tipi)</typeparam>
        /// <typeparam name="TProperty">Entity-nin cari Property-si (onun tipi)</typeparam>
        /// <param name="entry"></param>
        /// <param name="propertyExpression"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EntityEntry<TEntity> SetValue<TEntity, TProperty> (this EntityEntry<TEntity> entry, 
            Expression<Func<TEntity, TProperty>> propertyExpression, 
            TProperty value) 
            where TEntity : class
        {

            entry.Property(propertyExpression).IsModified = true;
            entry.Property(propertyExpression).CurrentValue = value;
            return entry;
        }
    }
}
