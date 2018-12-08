using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.ModelConfigurations
{
    public class GithubRepoConfiguration : IEntityTypeConfiguration<GithubRepo>
    {
        public void Configure(EntityTypeBuilder<GithubRepo> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedOn)
                .HasColumnName("created_on")
                .HasColumnType("timestamp")
                .IsRequired();
            
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();
            
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(500);

            builder.Property(x => x.Forks)
                .HasColumnName("forks");

            builder.Property(x => x.HtmlUrl)
                .HasColumnName("html_url")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Language)
                .HasColumnName("language")
                .HasMaxLength(25);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}