using CoreLayer.Helpers.Extensions;
using DataAccess.Abstract.Generic;
using DataAccess.Concrete.Context;
using DTOLayer.DTOs;
using EntityLayer.Concrete.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : GenericBaseRepository<T>, IGenericDal<T> where T : BaseEntity
    {
        private readonly ECContext _context;

        public GenericRepository(ECContext context) : base(context)
        {
            _context = context;
        }

        public async Task Delete(T t)
        {
            Type type = t.GetType();
            PropertyInfo? prop = type.GetProperty("IsDeleted");
            //object obj = prop.GetValue(t, null);
            prop.SetValue(t, true, null);

            updateBaseField(ref t);

        }







        public override async Task Insert(T t)
        {
            addBaseFields(ref t);
            await Table.AddAsync(t);
        }

        private static void addBaseFields(ref T t)
        {
            t.Id = Guid.NewGuid();
            t.IsDeleted = false;
            t.Status = true;
            t.CreatedDate = DateTime.Now;
            t.ModifyedDate = default(DateTime);

            //if (typeof(T) == typeof(BaseEntityWithUser))
            //{
            //    Type type = t.GetType();
            //    PropertyInfo? propCreatUserId = type.GetProperty("CreatUserId");
            //    propCreatUserId.SetValue(t, , null);
            //}
        }







        private static void updateBaseField(ref T t)
        {
            t.ModifyedDate = DateTime.Now;

            //if (typeof(T) == typeof(BaseEntityWithUser))
            //{
            //    Type type = t.GetType();
            //    PropertyInfo? propModifyUserId = type.GetProperty("ModifyUserId");
            //    propModifyUserId.SetValue(t, , null);
            //}
        }

        public override async Task Update(T t, Action<EntityEntry<T>> rules = null)
        {
            var entry = _context.Entry(t);

            if (rules == null)
                goto summary;

            foreach (var propertyInfo in typeof(T).GetProperties().Where(x => Extension.IsEditable(x)))
                entry.Property(propertyInfo.Name).IsModified = false;


            rules(entry);

        summary:

            entry.Property(nameof(t.ModifyedDate)).IsModified = true;
            if (typeof(T).GetProperty("ModifiedUser") != null)
                entry.Property("ModifiedUser").IsModified = true;
            updateBaseField(ref t);

            entry.State = EntityState.Modified;

        }


        public override async Task UpdateRange(IEnumerable<GenericUpdateRangeModel<T>> rangeModels)
        {
            foreach (var item in rangeModels)
            {
                await Update(item.t, item.rules);
            }
        }


        //public override async Task Update(T t, Guid id)
        //{
        //    updateBaseField(ref t);


        //    EntityEntry entityEntry = _context.Entry(t);
        //    entityEntry.State = EntityState.Modified;

        //    //var local = await Table.FindAsync(id);
        //    //if (local != null)
        //    //{
        //    //    _context.Entry(local).State = EntityState.Detached;
        //    //}

        //    //entityEntry.State = EntityState.Modified;



        //    await SaveAsync();
        //}
    }
}
