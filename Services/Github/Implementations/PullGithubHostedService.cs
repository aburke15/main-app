using System;
using System.Threading;
using System.Threading.Tasks;
using AppData.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Websites.Services.Github
{
    internal class PullGithubHostedService :  IHostedService, IDisposable
    {
        private Timer Timer;

        public PullGithubHostedService(IServiceProvider services) 
            => Services = services;

        IServiceProvider Services { get; }

        public void Dispose() 
            => Timer?.Dispose();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var service = scope.ServiceProvider
                    .GetRequiredService<IScopedProcessingService>();

                service.Process();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) 
            => Task.CompletedTask;
    }
}