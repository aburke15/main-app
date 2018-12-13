using System.Linq;
using System.Threading.Tasks;
using AppData.Dtos;
using AppData.Interfaces;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Websites.Services.System;

namespace Websites.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RepoController : Controller
    {
        private const string REPO_KEY = "Github Repos";

        private readonly IMemoryCache Cache;
        private readonly IGithubRepoRepository GithubRepo;

        public RepoController(
            IGithubRepoRepository githubRepo, 
            IMemoryCache cache)
        {
            Cache = cache;
            GithubRepo = githubRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {

            var githubRepos = await GithubRepo.GetAsync();
            var repos = githubRepos
                .Select(x => new GithubDataDto
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Forks = x.Forks,
                    HtmlUrl = x.HtmlUrl,
                    Language = x.Language,
                    Name = x.Name
                })
                .OrderBy(x => x.CreatedOn);

            return Ok(repos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var githubRepo = await GithubRepo.GetByIdAsync(id);
            var repo = new GithubDataDto
            {
                Id = githubRepo.Id,
                CreatedOn = githubRepo.CreatedOn,
                CreatedAt = githubRepo.CreatedAt,
                Description = githubRepo.Description,
                HtmlUrl = githubRepo.HtmlUrl,
                Language = githubRepo.Language,
                Name = githubRepo.Name
            };

            return Ok(repo);
        }
    }
}