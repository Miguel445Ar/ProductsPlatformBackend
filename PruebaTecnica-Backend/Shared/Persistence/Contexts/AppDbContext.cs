

using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Shared.Extensions;
using PruebaTecnica_Backend.Orders.Domain.Models;

namespace PruebaTecnica_Backend.Shared.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Creating Products

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Code).IsRequired().HasMaxLength(20);
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Product>().Property(p => p.Description).IsRequired();
            builder.Entity<Product>().Property(p => p.Stock).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitPrice).IsRequired();


            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().HasKey(o => o.Id);
            builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(o => o.TotalPrice).IsRequired();
            builder.Entity<Order>().Property(o => o.DeliveryDate).IsRequired();
            builder.Entity<Order>().Property(o => o.RequestedUnits).IsRequired();

            builder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductsId);
            

            builder.UseSnakeCaseNamingConvention();
        }

    }
}
