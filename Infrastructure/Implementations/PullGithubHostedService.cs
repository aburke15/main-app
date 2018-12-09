using System;
using System.Threading;
using System.Threading.Tasks;
using AppData.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Websites.Services.Github;

namespace Websites.Infrastructure
{
    internal class PullGithubHostedService :  IHostedService, IDisposable
    {
        private Timer _timer;

        public PullGithubHostedService(IServiceProvider services) 
            => Services = services;

        IServiceProvider Services { get; }

        public void Dispose() 
            => _timer?.Dispose();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Github background service is starting with a timer!");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var service = scope.ServiceProvider
                    .GetRequiredService<IGithubScopedProcessingService>();

                service.DoWork();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) 
            => Task.CompletedTask;
    }
}