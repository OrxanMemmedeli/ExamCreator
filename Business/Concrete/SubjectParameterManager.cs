using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class SubjectParameterManager : ISubjectParameterService
    {
        private readonly ISubjectParameterDal _dal;

        public SubjectParameterManager(ISubjectParameterDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(SubjectParameter t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<SubjectParameter> GetAllAsnyc(params Expression<Func<SubjectParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<SubjectParameter> GetAllAsnyc(Expression<Func<SubjectParameter, bool>> filter, params Expression<Func<SubjectParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<SubjectParameter> GetByAsnyc(Expression<Func<SubjectParameter, bool>> filter, params Expression<Func<SubjectParameter, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<SubjectParameter> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(SubjectParameter t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(SubjectParameter t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(SubjectParameter t, Action<EntityEntry<SubjectParameter>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}

