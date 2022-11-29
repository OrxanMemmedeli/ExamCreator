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
        }

        public IQueryable<Question> GetAllAsnyc(Expression<Func<Question, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<Question> GetAllAsnyc(Expression<Func<Question, bool>> filter, Expression<Func<Question, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<Question> GetByAsnyc(Expression<Func<Question, bool>> filter, Expression<Func<Question, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);
        }

        public Task<Question> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Question t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(Question t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Question t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
