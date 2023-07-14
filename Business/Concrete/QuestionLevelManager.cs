using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class QuestionLevelManager : IQuestionLevelService
    {
        private readonly IQuestionLevelDal _dal;

        public QuestionLevelManager(IQuestionLevelDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(QuestionLevel t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<QuestionLevel> GetAllAsnyc(params Expression<Func<QuestionLevel, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<QuestionLevel> GetAllAsnyc(Expression<Func<QuestionLevel, bool>> filter, params Expression<Func<QuestionLevel, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<QuestionLevel> GetByAsnyc(Expression<Func<QuestionLevel, bool>> filter, params Expression<Func<QuestionLevel, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<QuestionLevel> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(QuestionLevel t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(QuestionLevel t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(QuestionLevel t, Action<EntityEntry<QuestionLevel>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
