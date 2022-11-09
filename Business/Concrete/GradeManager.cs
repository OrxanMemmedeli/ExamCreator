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
    public class GradeManager : IGradeService
    {
        private readonly IGradeDal _dal;

        public GradeManager(IGradeDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Grade t)
        {
            await _dal.Delete(t); 
        }

        public IQueryable<Grade> GetAllAsnyc(Expression<Func<Grade, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<Grade> GetAllAsnyc(Expression<Func<Grade, bool>> filter, Expression<Func<Grade, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<Grade> GetByAsnyc(Expression<Func<Grade, bool>> filter, Expression<Func<Grade, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);    
        }

        public Task<Grade> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);   
        }

        public async Task Insert(Grade t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(Grade t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Grade t)
        {
            await _dal.Update(t);
        }
    }
}
