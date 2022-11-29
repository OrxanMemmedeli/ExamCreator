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
        }

        public IQueryable<QuestionLevel> GetAllAsnyc(Expression<Func<QuestionLevel, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<QuestionLevel> GetAllAsnyc(Expression<Func<QuestionLevel, bool>> filter, Expression<Func<QuestionLevel, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<QuestionLevel> GetByAsnyc(Expression<Func<QuestionLevel, bool>> filter, Expression<Func<QuestionLevel, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);
        }

        public Task<QuestionLevel> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(QuestionLevel t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(QuestionLevel t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(QuestionLevel t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
