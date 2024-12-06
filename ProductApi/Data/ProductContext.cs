using System;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Data;

public class ProductContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
