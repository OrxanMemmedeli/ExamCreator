using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

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
            await _dal.SaveAsync();
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
            await _dal.SaveAsync();
        }

        public async Task Remove(Booklet t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Booklet t, Action<EntityEntry<Booklet>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
