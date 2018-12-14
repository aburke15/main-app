using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppData.Dtos;
using AppData.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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
            IMemoryCache cache,
            IGithubRepoRepository githubRepo)
        {
            Cache = cache;
            GithubRepo = githubRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            if (Cache.TryGetValue(REPO_KEY, out IEnumerable<GithubDataDto> projects))
                return Ok(projects);
            
            var repos = (await GithubRepo.GetAsync())
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

            Cache.Set(REPO_KEY, repos, TimeSpan.FromDays(5));

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
                Forks = githubRepo.Forks,
                HtmlUrl = githubRepo.HtmlUrl,
                Language = githubRepo.Language,
                Name = githubRepo.Name
            };

            return Ok(repo);
        }
    }
}