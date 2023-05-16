using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SmallProject.DAL.Models;

namespace SmallProject
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Category->Product
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(x => new { x.ProductId, x.CategoryId });
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.CategoryProducts)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(x => x.Category)
                .WithMany(x => x.CategoryProducts)
                .HasForeignKey(x => x.CategoryId);
            #endregion

            #region Product->Order
            modelBuilder.Entity<ProductOrder>()
                .HasKey(x => new {x.ProductId,x.OrderId});
            modelBuilder.Entity<ProductOrder>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductOrders)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<ProductOrder>()
                .HasOne(x => x.Order)
                .WithMany(x => x.ProductOrders)
                .HasForeignKey(x => x.OrderId);
            #endregion
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        


    }
}
