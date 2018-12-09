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
                TimeSpan.FromSeconds(40));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var githubScopedProcessingService = 
                    scope.ServiceProvider
                        .GetRequiredService<IGithubScopedProcessingService>();

                githubScopedProcessingService.DoWork();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Github background service is ending");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}