using Business.QuartzJobs.Jobs;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;

namespace Business.QuartzJobs
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;

        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            IScheduler scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            scheduler.JobFactory = _jobFactory;

            await scheduler.Start(cancellationToken);

            await ScheduleJobs(scheduler);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task ScheduleJobs(IScheduler scheduler)
        {
            IJobDetail debtJobDetail = JobBuilder.Create<CreateDebtJob>()
                .WithIdentity("CreateDebtJob")
                .Build();

            ICronTrigger debtCronTrigger = (ICronTrigger)TriggerBuilder.Create()
                .WithIdentity("CreateDebtTrigger")
                .WithCronSchedule("0 1 0 * * ?")
                .Build();

            await scheduler.ScheduleJob(debtJobDetail, debtCronTrigger);

            IJobDetail paymentJobDetail = JobBuilder.Create<CreatePaymentSummaryJob>()
                .WithIdentity("CreatePaymentSummaryJob")
                .Build();

            ICronTrigger paymentCronTrigger = (ICronTrigger)TriggerBuilder.Create()
                .WithIdentity("CreatePaymentSummaryTrigger")
                .WithCronSchedule("0 55 0 * * ?")
                .Build();

            await scheduler.ScheduleJob(paymentJobDetail, paymentCronTrigger);
        }
    }
}
