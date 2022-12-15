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
    public class BookletManager : IBookletService
    {
        private readonly IBookletDal _dal;

        public BookletManager(IBookletDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Booklet t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<Booklet> GetAllAsnyc(params Expression<Func<Booklet, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Booklet> GetAllAsnyc(Expression<Func<Booklet, bool>> filter, params Expression<Func<Booklet, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Booklet> GetByAsnyc(Expression<Func<Booklet, bool>> filter, params Expression<Func<Booklet, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Booklet> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Booklet t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(Booklet t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Booklet t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
