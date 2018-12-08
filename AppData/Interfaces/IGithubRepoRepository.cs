using AppData.Models;

namespace AppData.Interfaces
{
    public interface IGithubRepoRepository : IRepository<GithubRepo>
    { 
        void DropGithubRepoTable();

        void CreateGithubRepoTable();
    }
}