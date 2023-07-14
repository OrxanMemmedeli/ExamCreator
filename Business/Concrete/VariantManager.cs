using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class VariantManager : IVariantService
    {
        private readonly IVariantDal _dal;

        public VariantManager(IVariantDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Variant t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Variant> GetAllAsnyc(params Expression<Func<Variant, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Variant> GetAllAsnyc(Expression<Func<Variant, bool>> filter, params Expression<Func<Variant, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Variant> GetByAsnyc(Expression<Func<Variant, bool>> filter, params Expression<Func<Variant, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Variant> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Variant t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Variant t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Variant t, Action<EntityEntry<Variant>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}

