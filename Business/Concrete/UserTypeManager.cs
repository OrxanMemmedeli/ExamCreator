using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

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
            await _dal.SaveAsync();
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
            await _dal.SaveAsync();
        }

        public async Task Remove(UserType t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(UserType t, Action<EntityEntry<UserType>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
