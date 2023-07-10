using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserTypeManager : IUserTypeService
    {
        private readonly IUserTypeDal _dal;

        public UserTypeManager(IUserTypeDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(UserType t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<UserType> GetAllAsnyc(params Expression<Func<UserType, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<UserType> GetAllAsnyc(Expression<Func<UserType, bool>> filter, params Expression<Func<UserType, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<UserType> GetByAsnyc(Expression<Func<UserType, bool>> filter, params Expression<Func<UserType, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<UserType> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(UserType t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(UserType t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(UserType t, Guid id)
        {
            await _dal.Update(t, id);
        }

        public async Task Update(UserType t, Action<EntityEntry<UserType>> rules = null)
        {
            await _dal.Update(t, rules);
        }
    }
}
