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
    public class ResponseManager : IResponseService
    {
        private readonly IResponseDal _dal;

        public ResponseManager(IResponseDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Response t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<Response> GetAllAsnyc(params Expression<Func<Response, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Response> GetAllAsnyc(Expression<Func<Response, bool>> filter, params Expression<Func<Response, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Response> GetByAsnyc(Expression<Func<Response, bool>> filter, params Expression<Func<Response, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Response> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Response t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(Response t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Response t, Guid id)
        {
            await _dal.Update(t, id);
        }

        public async Task Update(Response t, Action<EntityEntry<Response>> rules = null)
        {
            await _dal.Update(t, rules);
        }
    }
}
