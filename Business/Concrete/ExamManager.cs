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
        }

        public async Task Remove(Exam t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Exam t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}

