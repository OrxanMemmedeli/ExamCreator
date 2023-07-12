using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class TextManager : ITextService
    {
        private readonly ITextDal _dal;

        public TextManager(ITextDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Text t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Text> GetAllAsnyc(params Expression<Func<Text, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Text> GetAllAsnyc(Expression<Func<Text, bool>> filter, params Expression<Func<Text, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Text> GetByAsnyc(Expression<Func<Text, bool>> filter, params Expression<Func<Text, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Text> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(Text t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(Text t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Text t, Action<EntityEntry<Text>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}

