using Domain.Models;
using Infrastructure.Dal;
using Infrastructure.Dal.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace Infrastructure.Jobs
{
    public class PostcardSheduler
    {
        public static async Task Start(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create<Postcard>().Build();
            job.JobDataMap.Put("employeeRepository", serviceProvider.GetService<IBaseRepository<Employee>>());
            job.JobDataMap.Put("DefaultConnection", serviceProvider.GetRequiredService<AplicationContext>());
            // Читаем токен из appsettings.json
            string telegramBotToken = configuration["TelegramBot:Token"];
            // Передаем токен в JobDataMap
            job.JobDataMap.Put("TelegramBotToken", telegramBotToken);
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
