using System.Collections.Generic;
using Websites.AppData.Dtos;

namespace Websites.Services.Github.Interfaces
{
    public interface IGithubApiService
    {
        IEnumerable<GithubRepoDto> GetRepositories();
    }
}