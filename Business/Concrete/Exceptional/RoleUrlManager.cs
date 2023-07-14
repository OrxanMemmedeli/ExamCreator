using Business.Abstract.Exceptional;
using DataAccess.Abstract.Exceptional;
using EntityLayer.Concrete.ExceptionalEntities;
using EntityLayer.Concrete.ForRoles;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Exceptional
{
    public class RoleUrlManager : IRoleUrlService
    {
        private readonly IRoleUrlDal _RoleUrlDal;

        public RoleUrlManager(IRoleUrlDal RoleUrlDal)
        {
            _RoleUrlDal = RoleUrlDal;
        }

        public IQueryable<RoleUrl> GetAllAsnyc(params Expression<Func<RoleUrl, object>>[] includes)
        {
            return _RoleUrlDal.GetAllAsnyc(includes);
        }

        public IQueryable<RoleUrl> GetAllAsnyc(Expression<Func<RoleUrl, bool>> filter, params Expression<Func<RoleUrl, object>>[] includes)
        {
            return _RoleUrlDal.GetAllAsnyc(filter, includes);
        }

        public async Task<RoleUrl> GetByAsnyc(Expression<Func<RoleUrl, bool>> filter, params Expression<Func<RoleUrl, object>>[] includes)
        {
            return await _RoleUrlDal.GetByAsnyc(filter, includes);
        }

        public async Task<RoleUrl> GetByIdAsnyc(Guid id)
        {
            return await _RoleUrlDal.GetByIdAsnyc(id);
        }

        public async Task Insert(RoleUrl t)
        {
            await _RoleUrlDal.Insert(t);
        }

        public async Task Remove(RoleUrl t)
        {
            await _RoleUrlDal.Remove(t);
        }

        public async Task Update(RoleUrl t, Action<EntityEntry<RoleUrl>> rules = null)
        {
            await _RoleUrlDal.Update(t, rules);
        }
    }
}
