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
        }

        public IQueryable<Section> GetAllAsnyc(Expression<Func<Section, bool>> include = null)
        {
            return _dal.GetAllAsnyc(include);
        }

        public IQueryable<Section> GetAllAsnyc(Expression<Func<Section, bool>> filter, Expression<Func<Section, bool>> include = null)
        {
            return _dal.GetAllAsnyc(filter, include);
        }

        public Task<Section> GetByAsnyc(Expression<Func<Section, bool>> filter, Expression<Func<Section, bool>> include = null)
        {
            return _dal.GetByAsnyc(filter, include);
        }

        public Task<Section> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Section t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(Section t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Section t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
