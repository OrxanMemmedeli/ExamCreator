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
        }

        public async Task Remove(ExamParameter t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(ExamParameter t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}

