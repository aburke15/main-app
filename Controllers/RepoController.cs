using System.Linq;
using System.Threading.Tasks;
using AppData.Dtos;
using AppData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Websites.Controllers
{
    [Route("api/repos")]
    [Produces("application/json")]
    public class RepoController : Controller
    {
        private readonly IGithubRepoRepository GithubRepo;

        public RepoController(IGithubRepoRepository githubRepo) 
            => GithubRepo = githubRepo;

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var githubRepoDto = (await GithubRepo.GetAsync())
            .Select(x => new GithubRepoDto
            {
                CreatedAt = x.CreatedAt,
                Description = x.Description,
                Forks = x.Forks,
                HtmlUrl = x.HtmlUrl,
                Language = x.Language,
                Name = x.Name
            })
            .OrderBy(x => x.CreatedAt);

            return Json(githubRepoDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await GithubRepo.GetByIdAsync(id);

            return Json(project);
        }
    }
}