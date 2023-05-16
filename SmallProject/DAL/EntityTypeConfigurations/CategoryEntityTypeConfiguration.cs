using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallProject.DAL.Models;
using SmallProject.DAL.Constants;

namespace SmallProject.DAL.EntityTypeConfigurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Category");

            entityTypeBuilder.HasKey("Id").HasName("Pr_Category");

            entityTypeBuilder.Property(x => x.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();

            entityTypeBuilder.Property(x => x.Name).HasColumnType(StringConstants.Varchar20).UseMySqlIdentityColumn().IsRequired();


            entityTypeBuilder.HasMany(x => x.CategoryProducts)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
