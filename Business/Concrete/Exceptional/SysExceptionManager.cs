using Business.Abstract.Exceptional;
using DataAccess.Abstract.Exceptional;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete.Exceptional
{
    public class SysExceptionManager : ISysExceptionService
    {
        private readonly ISysExceptionDal _SysExceptionDal;

        public SysExceptionManager(ISysExceptionDal SysExceptionDal)
        {
            _SysExceptionDal = SysExceptionDal;
        }

        public IQueryable<SysException> GetAllAsnyc(params Expression<Func<SysException, object>>[] includes)
        {
            return _SysExceptionDal.GetAllAsnyc(includes);
        }

        public IQueryable<SysException> GetAllAsnyc(Expression<Func<SysException, bool>> filter, params Expression<Func<SysException, object>>[] includes)
        {
            return _SysExceptionDal.GetAllAsnyc(filter, includes);
        }

        public async Task<SysException> GetByAsnyc(Expression<Func<SysException, bool>> filter, params Expression<Func<SysException, object>>[] includes)
        {
            return await _SysExceptionDal.GetByAsnyc(filter, includes);
        }

        public async Task<SysException> GetByIdAsnyc(Guid id)
        {
            return await _SysExceptionDal.GetByIdAsnyc(id);
        }

        public async Task Insert(SysException t)
        {
            await _SysExceptionDal.Insert(t);
        }

        public async Task Remove(SysException t)
        {
            await _SysExceptionDal.Remove(t);
        }

        public async Task Update(SysException t, Action<EntityEntry<SysException>> rules = null)
        {
            await _SysExceptionDal.Update(t, rules);
        }
    }
}
