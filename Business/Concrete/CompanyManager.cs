using Business.Abstract;
using Business.Abstract.Exceptional;
using Business.Attributes;
using CoreLayer.Helpers.Extensions;
using DataAccess.Abstract;
using DTOLayer.DTOs.Company;
using DTOLayer.DTOs.PaymentSummary;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _dal;
        private readonly IPaymentSummaryService _paymentSummaryService;
        public CompanyManager(ICompanyDal dal, IPaymentSummaryService paymentSummaryService)
        {
            _dal = dal;
            _paymentSummaryService = paymentSummaryService;
        }

        public async Task Delete(Company t)
        {
            await _dal.Delete(t);
            await _dal.SaveAsync();
        }

        public IQueryable<Company> GetAllAsnyc(params Expression<Func<Company, object>>[] includes)
        {
            return _dal.GetAllAsnyc(includes);
        }

        public IQueryable<Company> GetAllAsnyc(Expression<Func<Company, bool>> filter, params Expression<Func<Company, object>>[] includes)
        {
            return _dal.GetAllAsnyc(filter, includes);
        }

        public Task<Company> GetByAsnyc(Expression<Func<Company, bool>> filter, params Expression<Func<Company, object>>[] includes)
        {
            return _dal.GetByAsnyc(filter, includes);
        }

        public Task<Company> GetByIdAsnyc(Guid id)
        {
            return _dal.GetByIdAsnyc(id);
        }

        [Transaction]
        public async Task Insert(Company t)
        {
            t.Id = Guid.NewGuid();
            t.StartDate = null;
            t.IsPenal = false;

            await _dal.Insert(t);

            await _paymentSummaryService.Insert(new PaymentSummaryCreateDTO()
            {
                CompanyId = t.Id,
                TotalDebt = 0,
                TotalPayment = 0,
            });
            await _dal.SaveAsync();
        }

        public async Task Remove(Company t)
        {
            await _dal.Remove(t);
            await _dal.SaveAsync();
        }

        public async Task Update(Company t, Action<EntityEntry<Company>> rules = null)
        {
            await _dal.Update(t, rules);
            await _dal.SaveAsync();
        }

        public async Task UpdateForJob(CompanyJobUpdateDTO t)
        {
            var company = await GetByIdAsnyc(t.CompanyId);
            await _dal.Update(company, entry =>
            {
                entry.SetValue<Company, >()
            })
        }

        public Task UpdateForStatus(bool status)
        {
            throw new NotImplementedException();
        }
    }
}

