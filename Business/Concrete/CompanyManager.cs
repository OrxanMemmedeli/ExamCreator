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
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _dal;

        public CompanyManager(ICompanyDal dal)
        {
            _dal = dal;
        }

        public async Task Delete(Company t)
        {
            await _dal.Delete(t);
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

        public async Task Insert(Company t)
        {
            await _dal.Insert(t);
        }

        public async Task Remove(Company t)
        {
            await _dal.Remove(t);
        }

        public async Task Update(Company t, Guid id)
        {
            await _dal.Update(t, id);
        }
    }
}
}
