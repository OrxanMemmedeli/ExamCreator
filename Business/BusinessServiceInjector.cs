using Business.QuartzJobs;
using Business.QuartzJobs.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Business
{
    public static class BusinessServiceInjector
    {
        public static void BusinessServiceRegister(this IServiceCollection services)
        {
            // Quartz.NET yapılandırması
            //services.AddSingleton<IJobFactory, JobFactory>();
            //services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            //services.AddSingleton<CreateDebtJob>();
            //services.AddSingleton<CreatePaymentSummaryJob>();

            //services.AddHostedService<QuartzHostedService>();
        }
    }
}
