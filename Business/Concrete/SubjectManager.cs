using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class SubjectManager : ISubjectService
    {
        private readonly ISubjectDal _dal;

        public SubjectManager(ISubjectDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Subject t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Subject> GetAllAsnyc(params Expression<Func<Subject, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Subject> GetAllAsnyc(Expression<Func<Subject, bool>> filter, params Expression<Func<Subject, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Subject> GetByAsnyc(Expression<Func<Subject, bool>> filter, params Expression<Func<Subject, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Subject> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Subject t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Subject t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Subject t, Action<EntityEntry<Subject>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
