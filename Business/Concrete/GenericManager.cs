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

        public void Delete(T t)
        {
            _dal.Delete(t); 
        }

        public IQueryable<T> GetAllAsnyc()
        {
            return _dal.GetAllAsnyc();
        }

        public IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter)
        {
            return GetAllAsnyc(filter);
        }

        public Task<T> GetByAsnyc(Expression<Func<T, bool>> filter)
        {
            return GetByAsnyc(filter);
        }

        public Task<T> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public void Insert(T t)
        {
            _dal.Insert(t);
        }

        public void Update(T t)
        {
            _dal.Update(t);
        }
    }
}
