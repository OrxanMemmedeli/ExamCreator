﻿using Business.Abstract;
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

        public IQueryable<Response> GetAllAsnyc(Expression<Func<Response, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<Response> GetAllAsnyc(Expression<Func<Response, bool>> filter, Expression<Func<Response, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<Response> GetByAsnyc(Expression<Func<Response, bool>> filter, Expression<Func<Response, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);
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
    }
}
