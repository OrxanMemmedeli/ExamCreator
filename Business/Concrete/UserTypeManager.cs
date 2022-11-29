using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
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

        public IQueryable<UserType> GetAllAsnyc(Expression<Func<UserType, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<UserType> GetAllAsnyc(Expression<Func<UserType, bool>> filter, Expression<Func<UserType, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<UserType> GetByAsnyc(Expression<Func<UserType, bool>> filter, Expression<Func<UserType, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);
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
    }
}
