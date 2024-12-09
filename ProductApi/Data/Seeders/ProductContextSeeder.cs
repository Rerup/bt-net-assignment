using System;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Data.Seeders;

public static class ProductContextSeeder
{
    public static void Seed(ProductContext context)
    {
        var clothingCategoryId = Guid.NewGuid();
        var accessoriesCategoryId = Guid.NewGuid();

        if (!context.Set<ProductCategory>().Any())
        {
            context.Set<ProductCategory>().AddRange(
                new ProductCategory { Id = clothingCategoryId, Name = "Clothing" },
                new ProductCategory { Id = accessoriesCategoryId, Name = "Accessories" }
            );
        }

        if (!context.Set<Product>().Any())
        {
            context.Set<Product>().AddRange(
                new Product { Id = Guid.NewGuid(), Name = "T-Shirt", Price = 99.95m, ProductCategoryId = clothingCategoryId },
                new Product { Id = Guid.NewGuid(), Name = "Necklace Unisex", Price = 129.95m, ProductCategoryId = accessoriesCategoryId },
                new Product { Id = Guid.NewGuid(), Name = "Silver Ring", Price = 89.95m, ProductCategoryId = accessoriesCategoryId }
            );
        }

        context.SaveChanges();
    }

    public static async Task SeedAsync(ProductContext context, CancellationToken cancellationToken)
    {
        var clothingCategoryId = Guid.NewGuid();
        var accessoriesCategoryId = Guid.NewGuid();

        if (!await context.Set<ProductCategory>().AnyAsync(cancellationToken))
        {
            await context.Set<ProductCategory>().AddRangeAsync(
                new ProductCategory { Id = clothingCategoryId, Name = "Clothing" },
                new ProductCategory { Id = accessoriesCategoryId, Name = "Accessories" }
            );
        }

        if (!await context.Set<Product>().AnyAsync(cancellationToken))
        {
            await context.Set<Product>().AddRangeAsync(
                new Product { Id = Guid.NewGuid(), Name = "T-Shirt", Price = 99.95m, ProductCategoryId = clothingCategoryId },
                new Product { Id = Guid.NewGuid(), Name = "Necklace Unisex", Price = 129.95m, ProductCategoryId = accessoriesCategoryId },
                new Product { Id = Guid.NewGuid(), Name = "Silver Ring", Price = 89.95m, ProductCategoryId = accessoriesCategoryId }
            );
        }

        await context.SaveChangesAsync(cancellationToken);
    }

}
