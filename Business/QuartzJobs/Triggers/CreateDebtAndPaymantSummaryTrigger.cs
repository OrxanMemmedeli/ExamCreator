using Business.QuartzJobs.Jobs;
using Quartz;
using Quartz.Impl;

namespace Business.QuartzJobs.Triggers
{
    public class CreateDebtAndPaymantSummaryTrigger
    {
        public async static Task Start()
        {
            //Zamanlayici yaradilir
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();


            //icra edilecek job-lar bildirilir
            IJobDetail debtJobDetail = JobBuilder.Create<CreateDebtJob>().Build();
            IJobDetail paymentJobDetail = JobBuilder.Create<CreatePaymentSummaryJob>().Build();

            //cronTrigger-ler yaradilir
            ICronTrigger debtCronTrigger = (ICronTrigger)TriggerBuilder.Create()
                .WithIdentity(nameof(CreateDebtJob))
                .WithCronSchedule("0 1 0 * * ?") // Her gün saat 00:01'de (simvollar uygun olaraq saniye, deqiqe, saat, gun, ay, heftenin gunleri, il)
                .Build();

            ICronTrigger paymentCronTrigger = (ICronTrigger)TriggerBuilder.Create()
                .WithIdentity(nameof(CreatePaymentSummaryJob))
                .WithCronSchedule("0 55 0 * * ?") // Her gün saat 00:55'de (simvollar uygun olaraq saniye, deqiqe, saat, gun, ay, heftenin gunleri, il)
                .Build();

            //zamanlayiciya goreceyi isler ve zamanlari bildirilir
            await scheduler.ScheduleJob(debtJobDetail, debtCronTrigger);
            await scheduler.ScheduleJob(paymentJobDetail, paymentCronTrigger);

            //zamanlayici ise salinir
            await scheduler.Start();
        }
    }
}
