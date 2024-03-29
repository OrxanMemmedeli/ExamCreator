﻿using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class QuestionParameterManager : IQuestionParameterService
    {
        private readonly IQuestionParameterDal _dal;

        public QuestionParameterManager(IQuestionParameterDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(QuestionParameter t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<QuestionParameter> GetAllAsnyc(params Expression<Func<QuestionParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<QuestionParameter> GetAllAsnyc(Expression<Func<QuestionParameter, bool>> filter, params Expression<Func<QuestionParameter, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<QuestionParameter> GetByAsnyc(Expression<Func<QuestionParameter, bool>> filter, params Expression<Func<QuestionParameter, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<QuestionParameter> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        public async Task Insert(QuestionParameter t)
        {
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }

        public async Task Remove(QuestionParameter t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(QuestionParameter t, Action<EntityEntry<QuestionParameter>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }
    }
}

