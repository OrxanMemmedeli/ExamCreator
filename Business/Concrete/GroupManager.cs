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
        }

        public async Task Remove(Group t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Group t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
