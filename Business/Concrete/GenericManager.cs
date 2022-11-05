using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _dal;

        public GenericManager(IGenericDal<T> dal)
        {
            _dal = dal;
        }

        public async Task Delete(T t)
        {
            await _dal.Delete(t);
        }

        public async Task Remove(T t)
        {
            await _dal.Remove(t);
        }

        public IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null)
        {
            return GetAllAsnyc(filter, include);
        }

        public Task<T> GetByAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null)
        {
            return GetByAsnyc(filter, include);
        }

        public Task<T> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(T t)
        {
            await _dal.Insert(t);
        }

        public async Task Update(T t)
        {
            await _dal.Update(t);
        }
    }
}
