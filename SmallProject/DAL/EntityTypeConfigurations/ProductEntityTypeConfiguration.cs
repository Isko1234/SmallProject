using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallProject.DAL.Constants;
using SmallProject.DAL.Models;

namespace SmallProject.DAL.EntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Product");

            entityTypeBuilder.HasKey(x => x.Id).HasName("Pr_Product");

            entityTypeBuilder.Property(x => x.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();

            entityTypeBuilder.Property(x => x.Name).HasColumnType(StringConstants.Varchar20).IsRequired();

            entityTypeBuilder.Property(x => x.Price).HasColumnType(StringConstants.BigInt).IsRequired();

            entityTypeBuilder.Property(x => x.Description).HasColumnType(StringConstants.Varchar20).IsRequired();

            entityTypeBuilder.HasMany(x => x.CategoryProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }

    }
}
