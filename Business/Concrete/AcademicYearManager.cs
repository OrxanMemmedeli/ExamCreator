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
    public class AcademicYearManager : IAcademicYearService
    {
        private readonly IAcademicYearDal _dal;

        public AcademicYearManager(IAcademicYearDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(AcademicYear t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<AcademicYear> GetAllAsnyc(params Expression<Func<AcademicYear, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<AcademicYear> GetAllAsnyc(Expression<Func<AcademicYear, bool>> filter,params Expression<Func<AcademicYear, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<AcademicYear> GetByAsnyc(Expression<Func<AcademicYear, bool>> filter,params Expression<Func<AcademicYear, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<AcademicYear> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(AcademicYear t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(AcademicYear t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(AcademicYear t, Guid id)
        {
            await _dal.Update(t, id);
        }

        public async Task Update(AcademicYear t, Action<EntityEntry<AcademicYear>> rules = null)
        {
            await _dal.Update(t, rules);
        }
    }
}
