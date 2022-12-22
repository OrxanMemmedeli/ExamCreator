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
    public class QuestionParameterManager : IQuestionParameterService
    {
        private readonly IQuestionParameterDal _dal;

        public QuestionParameterManager(IQuestionParameterDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(QuestionParameter t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<QuestionParameter> GetAllAsnyc(params Expression<Func<QuestionParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<QuestionParameter> GetAllAsnyc(Expression<Func<QuestionParameter, bool>> filter, params Expression<Func<QuestionParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<QuestionParameter> GetByAsnyc(Expression<Func<QuestionParameter, bool>> filter, params Expression<Func<QuestionParameter, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<QuestionParameter> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(QuestionParameter t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(QuestionParameter t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(QuestionParameter t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}

