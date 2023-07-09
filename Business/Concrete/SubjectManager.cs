using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public IQueryable<Subject> GetAllAsnyc(params Expression<Func<Subject, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Subject> GetAllAsnyc(Expression<Func<Subject, bool>> filter, params Expression<Func<Subject, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Subject> GetByAsnyc(Expression<Func<Subject, bool>> filter, params Expression<Func<Subject, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
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

        public async Task Update(Subject t, Action<EntityEntry<Subject>> rules = null)
        {
            await _dal.Update(t, rules);
        }
    }
}
