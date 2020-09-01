using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorServerWithSignalR
{
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
                    await talkService.SendAsync($"The time is {DateTime.Now}");
                }
            }
        }
    }
}
