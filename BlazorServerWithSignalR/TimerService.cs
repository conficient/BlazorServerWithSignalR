using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorServerWithSignalR
{
    /// <summary>
    /// This is a background server-side process that pushes messages into the Talk Service
    /// to demonstrate you don't need to have a client present for the service to operate
    /// </summary>
    public class TimerService : BackgroundService
    {
        private readonly TalkService talkService;

        public TimerService(TalkService talkService)
        {
            this.talkService = talkService;
            Console.WriteLine("TimerService created");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("TimerService started");
            while (!stoppingToken.IsCancellationRequested)
            {
                // wait five seconds
                await Task.Delay(5000, stoppingToken);

                if (!stoppingToken.IsCancellationRequested)
                {
                    // generate a time event
                    await talkService.SendAsync($"The time is {DateTime.Now}");
                }
            }
        }
    }
}
