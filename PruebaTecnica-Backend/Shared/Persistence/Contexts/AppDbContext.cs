

using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Backend.ProductsPerOrders.Domain.Models;
using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Shared.Extensions;

namespace PruebaTecnica_Backend.Shared.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPerOrder> ProductsPerOrders { get; set; }
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

            builder.Entity<ProductPerOrder>().ToTable("ProductPerOrder");
            builder.Entity<ProductPerOrder>().HasKey(ppo => new { ppo.ProductId, ppo.OrderId });
            builder.Entity<ProductPerOrder>().Property(ppo => ppo.ProductId).IsRequired();
            builder.Entity<ProductPerOrder>().Property(ppo => ppo.OrderId).IsRequired();

            // Products - ProductsPerOrder
            builder.Entity<ProductPerOrder>()
                .HasOne(ppo => ppo.Product)
                .WithMany(p => p.ProductsPerOrders);

            builder.UseSnakeCaseNamingConvention();
        }

    }
}
