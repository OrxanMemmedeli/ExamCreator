using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class GroupManager : IGroupService
    {
        private readonly IGroupDal _dal;

        public GroupManager(IGroupDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Group t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Group> GetAllAsnyc(params Expression<Func<Group, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Group> GetAllAsnyc(Expression<Func<Group, bool>> filter, params Expression<Func<Group, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Group> GetByAsnyc(Expression<Func<Group, bool>> filter, params Expression<Func<Group, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Group> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Group t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Group t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }
        public async Task Update(Group t, Action<EntityEntry<Group>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
