using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Websites.Services.Github;

namespace Websites.Infrastructure
{
    public class PullGithubService :  BackgroundService
    {
        // inject some type that will work with the github API
        private readonly IGithubApiService GithubApi;

        public PullGithubService(GithubApiService githubApi)
        {
            GithubApi = githubApi;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}