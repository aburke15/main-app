using System;
using System.Linq;
using AppData.Interfaces;
using AppData.Models;

namespace Websites.Services.Github
{
    internal class ScopedProcessingService : IScopedProcessingService
    {
        private readonly IGithubApiService GithubApi;
        private readonly IGithubRepoRepository GithubRepository;

        public ScopedProcessingService(
            IGithubApiService githubApi,
            IGithubRepoRepository githubRepository)
        {
            GithubApi = githubApi;
            GithubRepository = githubRepository;
        }

        public void Process()
        {
            GithubRepository.DropGithubRepoTable();
            GithubRepository.CreateGithubRepoTable();

            var repos = (GithubApi.GetRepositories())
                .Select(x => new
                {
                    x.CreatedAt,
                    x.Description,
                    x.Forks,
                    x.HtmlUrl,
                    x.Language,
                    x.Name
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