using Microsoft.EntityFrameworkCore;
using Websites.AppData.ModelConfigurations;
using Websites.AppData.Models;

namespace Websites.AppData
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