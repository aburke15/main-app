using System;
using System.Linq;
using AppData.Interfaces;
using AppData.Models;
using Websites.Services.Github;

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

        var repos = GithubApi.GetRepositories();
        
        var githubRepos = repos.Select(x => new GithubRepo 
        {
            CreatedAt = x.CreatedAt,
            Description = x.Description,
            Forks = x.Forks,
            HtmlUrl = x.HtmlUrl,
            Language = x.Language,
            Name = x.Name
        });

        GithubRepository.AddRange(githubRepos);
        GithubRepository.SaveChanges();
    }
}