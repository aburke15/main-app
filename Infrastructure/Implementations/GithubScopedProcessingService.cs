using System;
using System.Linq;
using AppData.Interfaces;
using AppData.Models;
using Websites.Services.Github;

internal class GithubScopedProcessingService : IGithubScopedProcessingService
{
    private readonly IGithubApiService GithubApi;
    private readonly IGithubRepoRepository GithubRepo;

    public GithubScopedProcessingService(
        IGithubApiService githubApi, 
        IGithubRepoRepository githubRepo)
    {
        GithubApi = githubApi;
        GithubRepo = githubRepo;
    }

    public async void DoWork()
    {
        Console.WriteLine("Doing some scoped processing work");

        Console.WriteLine("Dropping Github Repo table.");
        GithubRepo.DropGithubRepoTable();
        Console.WriteLine("Github Repo dropped successfully.");

        Console.WriteLine("Creating Github Repo table.");
        GithubRepo.CreateGithubRepoTable();
        Console.WriteLine("Github Repo created successfully.");

        Console.WriteLine("Fetching repos from Github API");
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

        Console.WriteLine("Inserting repos into GithubRepo table.");
        GithubRepo.AddRange(githubRepos);
        await GithubRepo.SaveChangesAsync();
        Console.WriteLine("Records successfully inserted.");
    }
}