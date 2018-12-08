using AppData.ModelConfigurations;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData
{
    public class WebsitesContext : DbContext
    {
        public WebsitesContext(DbContextOptions options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TestConfiguration());
            builder.ApplyConfiguration(new GithubRepoConfiguration());
        }

        public virtual DbSet<GithubRepo> GithubRepo { get; set; }

        public virtual DbSet<Test> Test { get; set; }
    }
}