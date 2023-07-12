using Business.Abstract.Exceptional;
using CoreLayer.Helpers.FieldComparer;
using DataAccess.Abstract.Exceptional;
using DTOLayer.DTOs;
using DTOLayer.DTOs.PaymentSummary;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ExceptionalEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Exceptional
{
    public class PaymentSummaryManager : IPaymentSummaryService
    {
        private readonly IPaymentSummaryDal _dal;

        public PaymentSummaryManager(IPaymentSummaryDal paymentSummaryDal)
        {
            _dal = paymentSummaryDal;
        }


        public async Task<PaymentSummary> GetByAsnyc(Guid CompanyId)
        {
            return await _dal.GetByAsnyc(x => x.CompanyId == CompanyId);
        }

        public async Task Insert(PaymentSummary t)
        {
            t.CurrentDebt = t.TotalPayment - t.TotalDebt;
            await _dal.Insert(t);
            await _dal.SaveAsync();
        }


        public async Task Update(IEnumerable<PaymentSummaryUpdateDTO> summaries)
        {
            List<GenericUpdateRangeModel<PaymentSummary>> rangeModels = new List<GenericUpdateRangeModel<PaymentSummary>>();




            if (summaries != null)
            {
                foreach (var item in summaries)
                {
                    var currentDebt = item.TotalPayment > item.TotalDebt ? item.TotalPayment - item.TotalDebt : 0;
                    var entity = new PaymentSummary()
                    {
                        CompanyId = item.CompanyId,
                        TotalDebt = 0,
                        TotalPayment = 0,
                        CurrentDebt = 0,
                    }
                    Action<EntityEntry<PaymentSummary>> rules = EntityFieldComparer<PaymentSummaryUpdateDTO, TEntity>.GetChangedFields(t, existingEntity);
                    await _dal.Update(,
                    

                    );

                    //rangeModels.Add(new GenericUpdateRangeModel<PaymentSummary>()
                    //{
                    //    t = new PaymentSummary()
                    //    {
                    //        CompanyId = item.CompanyId,
                    //        TotalDebt = item.TotalDebt,
                    //        TotalPayment = item.TotalPayment,
                    //        CurrentDebt = item.TotalPayment - item.TotalDebt,
                    //        Id = Guid.NewGuid(),
                    //    },
                    //    rules = new Action<EntityEntry<PaymentSummary>>
                    //    {

                    //    }
                    //})
                }
                //await _paymentSummaryDal.UpdateRange(rangeModels);
            }

            await _dal.SaveAsync();
        }
    }
}
