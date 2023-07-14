﻿using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class QuestionTypeManager : IQuestionTypeService
    {
        private readonly IQuestionTypeDal _dal;

        public QuestionTypeManager(IQuestionTypeDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(QuestionType t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<QuestionType> GetAllAsnyc(params Expression<Func<QuestionType, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<QuestionType> GetAllAsnyc(Expression<Func<QuestionType, bool>> filter, params Expression<Func<QuestionType, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<QuestionType> GetByAsnyc(Expression<Func<QuestionType, bool>> filter, params Expression<Func<QuestionType, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<QuestionType> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(QuestionType t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(QuestionType t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(QuestionType t, Action<EntityEntry<QuestionType>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}
