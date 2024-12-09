using System;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Data;

public class ProductContext : DbContext
{

    public DbSet<Product>? Products { get; set; }

    public DbSet<ProductCategory>? ProductCategories { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var electronicsCategoryId = Guid.NewGuid();
        var booksCategoryId = Guid.NewGuid();

        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory { Id = electronicsCategoryId, Name = "Electronics" },
            new ProductCategory { Id = booksCategoryId, Name = "Books" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.NewGuid(), Name = "T-Shirt", Price = 99.95m, ProductCategoryId = electronicsCategoryId },
            new Product { Id = Guid.NewGuid(), Name = "Necklace Unisex", Price = 129.95m, ProductCategoryId = electronicsCategoryId },
            new Product { Id = Guid.NewGuid(), Name = "Silver Ring", Price = 89.95m, ProductCategoryId = booksCategoryId }
        );
    }
}
