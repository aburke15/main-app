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
            // some enity type configuration

            builder.Entity<Test>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Entity<Test>()
                .HasKey(x => x.ID);

            builder.Entity<Test>()
                .Property(x => x.Body)
                .HasColumnName("body")
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .IsRequired();
            
            builder.Entity<Test>()
                .Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Entity<Test>()
                .Property(x => x.CreatedOn)
                .HasColumnName("created_on")
                .HasColumnType("date")
                .IsRequired();
        }

        // some db set
        public virtual DbSet<Test> Test { get; set; }
    }
}