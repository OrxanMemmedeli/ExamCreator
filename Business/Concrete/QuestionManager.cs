using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _dal;

        public QuestionManager(IQuestionDal dal)
        {
            _dal = dal;
        }
        public async Task Delete(Question t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Question> GetAllAsnyc(params Expression<Func<Question, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Question> GetAllAsnyc(Expression<Func<Question, bool>> filter, params Expression<Func<Question, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Question> GetByAsnyc(Expression<Func<Question, bool>> filter, params Expression<Func<Question, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Question> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Question t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Question t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Question t, Action<EntityEntry<Question>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
