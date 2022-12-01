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
    public class QuestionTypeManager : IQuestionTypeService
    {
        private readonly IQuestionTypeDal _dal;

        public QuestionTypeManager(IQuestionTypeDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(QuestionType t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<QuestionType> GetAllAsnyc(params Expression<Func<QuestionType, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<QuestionType> GetAllAsnyc(Expression<Func<QuestionType, bool>> filter, params Expression<Func<QuestionType, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<QuestionType> GetByAsnyc(Expression<Func<QuestionType, bool>> filter, params Expression<Func<QuestionType, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<QuestionType> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(QuestionType t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(QuestionType t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(QuestionType t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
