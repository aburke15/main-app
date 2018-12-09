
using System.Collections.Generic;
using System.Threading.Tasks;
using AppData.Dtos;

namespace Websites.Services.Github
{
    public interface IGithubApiService
    {
        IEnumerable<GithubRepoDto> GetRepositories();
    }
}