﻿using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class SectionManager : ISectionService
    {
        private readonly ISectionDal _dal;

        public SectionManager(ISectionDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Section t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Section> GetAllAsnyc(params Expression<Func<Section, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Section> GetAllAsnyc(Expression<Func<Section, bool>> filter, params Expression<Func<Section, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Section> GetByAsnyc(Expression<Func<Section, bool>> filter, params Expression<Func<Section, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Section> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Section t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Section t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Section t, Action<EntityEntry<Section>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
