using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class GradeManager : IGradeService
    {
        private readonly IGradeDal _dal;
        private readonly IMapper _mapper;
        public GradeManager(IGradeDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task Delete(Grade t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Grade> GetAllAsnyc(params Expression<Func<Grade, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Grade> GetAllAsnyc(Expression<Func<Grade, bool>> filter, params Expression<Func<Grade, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Grade> GetByAsnyc(Expression<Func<Grade, bool>> filter, params Expression<Func<Grade, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);    
        }

        public Task<Grade> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);   
        }

        public async Task Insert(Grade t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Grade t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Grade t, Action<EntityEntry<Grade>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
