﻿using Business.Abstract;
using Business.Abstract.Exceptional;
using Business.Attributes;
using CoreLayer.Constants;
using CoreLayer.Helpers.Tools;
using EntityLayer.Concrete.ExceptionalEntities;
using EntityLayer.Constants;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.QuartzJobs.Jobs
{
    public class CreateDebtJob : IJob
    {
        private readonly IPaymentService _paymentService;
        private readonly ICompanyService _companyService;
        public CreateDebtJob(IPaymentService paymentService, ICompanyService companyService)
        {
            _paymentService = paymentService;
            _companyService = companyService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var companies = _companyService.GetAllAsnyc().ToList();

            List<Payment> paymentList = new List<Payment>();

            foreach (var company in companies)
            {
                decimal payments = _paymentService.GetAllAsnyc(x => x.CompanyId == company.Id && x.PaymentType == PaymentType.Pay).Sum(x => x.Amout);
                decimal debts = _paymentService.GetAllAsnyc(x => x.CompanyId == company.Id && x.PaymentType == PaymentType.Debt).Sum(x => x.Amout);

                //gunluk borc melumati
                Payment payment = new Payment()
                {
                    CompanyId = company.Id,
                    PaymentType = PaymentType.Debt,
                    Amout = company.DailyAmount,
                    CreatedDate = DateTime.Now,
                };

                //Blok tarixi bos deyil ve bu gune beraberdirse company status false et ve cerimeli odenisi yaz
                if (company.BlockedDate != null && company.BlockedDate.Value.Date == DateTime.Now.Date)
                {
                    if (company.Status)
                        await _companyService.UpdateForStatus(company.Id, false);
                    payment.Amout += company.DailyAmount * company.PersentOfFine;
                }
                //blok tarixi bosdur amma borx meblegi teyin olunan limiti asibsa blok tarixi yaz, cerimeni aktiv et ve cerimeli meblegi yaz.
                else if (debts - payments > company.DebtLimit)
                {
                    await _companyService.UpdateForJob(new DTOLayer.DTOs.Company.CompanyJobUpdateDTO()
                    {
                        CompanyId = company.Id,
                        BlockedDate = DateTime.Now.AddDays(20),
                        IsPenal = true
                    });
                    payment.Amout += company.DailyAmount * company.PersentOfFine;
                }

                paymentList.Add(payment);
            }

            await _paymentService.InsertRangeDebts(paymentList);

        }
    }
}
