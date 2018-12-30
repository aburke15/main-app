using Websites.AppData.Models;

namespace Websites.AppData.Interfaces
{
    public interface IGithubRepoRepository : IRepository<GithubRepo>
    { 
        void DropGithubRepoTable();

        void CreateGithubRepoTable();
    }
}