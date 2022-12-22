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
    public class SubjectParameterManager : ISubjectParameterService
    {
        private readonly ISubjectParameterDal _dal;

        public SubjectParameterManager(ISubjectParameterDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(SubjectParameter t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<SubjectParameter> GetAllAsnyc(params Expression<Func<SubjectParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<SubjectParameter> GetAllAsnyc(Expression<Func<SubjectParameter, bool>> filter, params Expression<Func<SubjectParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<SubjectParameter> GetByAsnyc(Expression<Func<SubjectParameter, bool>> filter, params Expression<Func<SubjectParameter, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<SubjectParameter> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(SubjectParameter t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(SubjectParameter t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(SubjectParameter t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}

