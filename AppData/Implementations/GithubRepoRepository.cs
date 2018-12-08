using AppData.Interfaces;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Implementations
{
    public class GithubRepoRepository : Repository<GithubRepo>, IGithubRepoRepository
    {
        private const string CREATE_TABLE = @"
            CREATE TABLE IF NOT EXISTS GithubRepo (
            ID int NOT NULL AUTO_INCREMENT,
            created_on timestamp NOT NULL,
            created_at timestamp NOT NULL,
            description varchar(500) NULL,
            forks int NULL,
            html_url varchar(200) NOT NULL,
            language varchar(25) NULL,
            name varchar(50) NOT NULL,
            PRIMARY KEY(ID));";

        private const string DROP_TABLE = "IF EXISTS DROP TABLE GithubRepo;";

        private readonly WebsitesContext Context;

        public GithubRepoRepository(WebsitesContext context)
            : base(context) => Context = context;

        public void DropGithubRepoTable()
            => Context.Database.ExecuteSqlCommand(DROP_TABLE);

        public void CreateGithubRepoTable()
            => Context.Database.ExecuteSqlCommand(CREATE_TABLE);
    }
}