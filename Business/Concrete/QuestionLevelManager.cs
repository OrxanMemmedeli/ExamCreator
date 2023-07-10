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
    public class QuestionLevelManager : IQuestionLevelService
    {
        private readonly IQuestionLevelDal _dal;

        public QuestionLevelManager(IQuestionLevelDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(QuestionLevel t)
        {
            await _dal.Delete(t);
        }

        public IQueryable<QuestionLevel> GetAllAsnyc(params Expression<Func<QuestionLevel, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<QuestionLevel> GetAllAsnyc(Expression<Func<QuestionLevel, bool>> filter, params Expression<Func<QuestionLevel, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<QuestionLevel> GetByAsnyc(Expression<Func<QuestionLevel, bool>> filter, params Expression<Func<QuestionLevel, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<QuestionLevel> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(QuestionLevel t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(QuestionLevel t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(QuestionLevel t, Guid id)
        {
            await _dal.Update(t, id);
        }

        public async Task Update(QuestionLevel t, Action<EntityEntry<QuestionLevel>> rules = null)
        {
            await _dal.Update(t, rules);
        }
    }
}
