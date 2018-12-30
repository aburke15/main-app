using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Websites.AppData.Models;

namespace Websites.AppData.ModelConfigurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Body)
                .HasColumnName("body")
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .HasColumnName("created_on")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}