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

        public IQueryable<AcademicYear> GetAllAsnyc(Expression<Func<AcademicYear, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<AcademicYear> GetAllAsnyc(Expression<Func<AcademicYear, bool>> filter, Expression<Func<AcademicYear, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<AcademicYear> GetByAsnyc(Expression<Func<AcademicYear, bool>> filter, Expression<Func<AcademicYear, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);
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
    }
}
