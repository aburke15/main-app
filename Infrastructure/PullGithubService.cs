using System;
using System.Threading;
using System.Threading.Tasks;
using AppData.Interfaces;
using Microsoft.Extensions.Hosting;
using Websites.Services.Github;

namespace Websites.Infrastructure
{
    public class PullGithubService :  IHostedService, IDisposable
    {
        // inject some type that will work with the github API
        private readonly IGithubApiService GithubApi;
        private readonly IGithubRepoRepository GithubRepo; 

        public PullGithubService(GithubApiService githubApi, IGithubRepoRepository githubRepo)
        {
            GithubApi = githubApi;
            GithubRepo = githubRepo;
        }

        public void Dispose()
        {
            System.Console.WriteLine("Disposing?");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Github Service is starting");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Github service is ending");
        }
    }
}