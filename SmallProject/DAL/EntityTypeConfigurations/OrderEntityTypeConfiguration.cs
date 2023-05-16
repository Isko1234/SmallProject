using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallProject.DAL.Constants;
using SmallProject.DAL.Models;

namespace SmallProject.DAL.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Order");

            entityTypeBuilder.HasKey(x => x.Id).HasName("Pr_Order");

            entityTypeBuilder.Property(x => x.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();

            entityTypeBuilder.Property(x => x.OverAllPrice).HasColumnType(StringConstants.BigInt).IsRequired();
            entityTypeBuilder.Property(x => x.Time).HasColumnType(StringConstants.DateTime).IsRequired();

            entityTypeBuilder.HasMany(x => x.ProductOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
