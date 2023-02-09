using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Football.API.DataAccess;
using NLog;
using System.IO;
using System.Threading.Tasks;
using Football.API.Schedule;
using Quartz;

namespace Football.API
{
    public class Program
    {
        private const bool IsDisabledJob = true;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            CreateDbIfNotExists(host);

            if (!IsDisabledJob)
            {
                CreateJob();
            }
            

            host.Run();
        }

        private static async void CreateJob()
        {
            var job = JobBuilder.Create<BackgroundJob>()
                .WithIdentity(name: "BackgroundJob", group: "JobGroup")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity(name: "RepeatingTrigger", group: "TriggerGroup")
                .WithSimpleSchedule(o => o
                    .RepeatForever()
                    .WithIntervalInSeconds(10))
                .Build();
            var builder = Host.CreateDefaultBuilder()
                .ConfigureServices((cxt, services) =>
                {
                    services.AddQuartz();
                    services.AddQuartzHostedService(opt => { opt.WaitForJobsToComplete = true; });
                }).Build();
            var schedulerFactory = builder.Services.GetRequiredService<ISchedulerFactory>();
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.ScheduleJob(job, trigger);
            await builder.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<FootballContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        
    }
}
