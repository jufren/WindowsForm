using ContosoUniversity.Quartz;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.App_Start
{
    public class ScheduleTaskStartUp
    {
        public static async void StartAsync()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<PushContentJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
             .WithIntervalInSeconds(15)
             .RepeatForever())
.Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}