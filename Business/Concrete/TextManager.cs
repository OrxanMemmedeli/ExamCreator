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
        }

        public async Task Remove(Text t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Text t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
}
