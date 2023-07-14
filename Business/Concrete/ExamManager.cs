using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ExamManager : IExamService
    {
        private readonly IExamDal _dal;

        public ExamManager(IExamDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Exam t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Exam> GetAllAsnyc(params Expression<Func<Exam, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Exam> GetAllAsnyc(Expression<Func<Exam, bool>> filter, params Expression<Func<Exam, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Exam> GetByAsnyc(Expression<Func<Exam, bool>> filter, params Expression<Func<Exam, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Exam> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Exam t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Exam t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Exam t, Action<EntityEntry<Exam>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}

