using System;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Seeders;

namespace ProductApi.Data;

public class ProductContext : DbContext
{

    public DbSet<Product>? Products { get; set; }

    public DbSet<ProductCategory>? ProductCategories { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=products.db")
            .UseSeeding((context, _) => ProductContextSeeder.Seed(this))
            .UseAsyncSeeding(async (context, _, cancellationToken) => await ProductContextSeeder.SeedAsync(this, cancellationToken));
    }
}
