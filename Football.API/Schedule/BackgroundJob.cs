using Quartz;
using System.Threading.Tasks;
using System;

namespace Football.API.Schedule
{
    public class BackgroundJob: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var jobDataMap = context.MergedJobDataMap;
            var useJobDataMapConsoleOutput = jobDataMap.GetBoolean("UseJobDataMapConsoleOutput");
            if (useJobDataMapConsoleOutput)
            {
                var consoleOutput = jobDataMap.GetString("ConsoleOutput");
                await Console.Out.WriteLineAsync(consoleOutput);
            }
            else
            {
                //ToDo SignalR can be used for notification
                await Console.Out.WriteLineAsync("Executing background job without Data");
            }
        }
    }
}
