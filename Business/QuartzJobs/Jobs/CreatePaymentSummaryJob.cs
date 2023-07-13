using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.QuartzJobs.Jobs
{
    public class CreatePaymentSummaryJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            // CreateDebtJob'un yapılması gereken işlemler burada yer alır
            return Task.CompletedTask;
        }
    }
}
