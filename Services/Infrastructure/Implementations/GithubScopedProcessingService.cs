using System;
using System.Linq;
using AppData.Interfaces;
using AppData.Models;
using Websites.Services.Github;

namespace Websites.Services.Infrastructure
{
    internal class GithubScopedProcessingService : IGithubScopedProcessingService
    {
        private readonly IGithubApiService GithubApi;
        private readonly IGithubRepoRepository GithubRepository;

        public GithubScopedProcessingService(
            IGithubApiService githubApi,
            IGithubRepoRepository githubRepository)
        {
            GithubApi = githubApi;
            GithubRepository = githubRepository;
        }

        public void DoWork()
        {
            GithubRepository.DropGithubRepoTable();
            GithubRepository.CreateGithubRepoTable();

            var repos = (GithubApi.GetRepositories())
                .Select(x => new
                {
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Forks = x.Forks,
                    HtmlUrl = x.HtmlUrl,
                    Language = x.Language,
                    Name = x.Name
                })
                .OrderByDescending(x => x.CreatedAt);

            foreach (var repo in repos)
            {
                var githubRepo = new GithubRepo
                {
                    CreatedAt = repo.CreatedAt.ToLongDateString(),
                    Description = repo.Description,
                    Forks = repo.Forks,
                    HtmlUrl = repo.HtmlUrl,
                    Language = repo.Language,
                    Name = repo.Name
                };

                GithubRepository.Add(githubRepo);
            }

            GithubRepository.SaveChanges();
        }
    }
}