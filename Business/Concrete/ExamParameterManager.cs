using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ExamParameterManager : IExamParameterService
    {
        private readonly IExamParameterDal _dal;

        public ExamParameterManager(IExamParameterDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(ExamParameter t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<ExamParameter> GetAllAsnyc(params Expression<Func<ExamParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<ExamParameter> GetAllAsnyc(Expression<Func<ExamParameter, bool>> filter, params Expression<Func<ExamParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<ExamParameter> GetByAsnyc(Expression<Func<ExamParameter, bool>> filter, params Expression<Func<ExamParameter, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<ExamParameter> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(ExamParameter t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(ExamParameter t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(ExamParameter t, Action<EntityEntry<ExamParameter>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}

