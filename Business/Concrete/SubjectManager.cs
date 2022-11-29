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
    public class SubjectManager : ISubjectService
    {
        private readonly ISubjectDal _dal;

        public SubjectManager(ISubjectDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Subject t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<Subject> GetAllAsnyc(Expression<Func<Subject, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<Subject> GetAllAsnyc(Expression<Func<Subject, bool>> filter, Expression<Func<Subject, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<Subject> GetByAsnyc(Expression<Func<Subject, bool>> filter, Expression<Func<Subject, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);
        }

        public Task<Subject> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Subject t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(Subject t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Subject t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
