using System;
using Domain.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Services.ProductService.Contract;

namespace ProductApi.Services.ProductService.Implementations;

public class ProductService : IProductService
{

    private readonly ProductContext _context;

    public ProductService(ProductContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return _context.Products is not null
        ? await _context.Products.Include(p => p.ProductCategory).ToListAsync()
        : new List<Product>();
    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        return _context.Products is not null
        ? await _context.Products.Include(p => p.ProductCategory).FirstOrDefaultAsync(p => p.Id == id)
        : null;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return await _context.Products.Include(p => p.ProductCategory).FirstOrDefaultAsync(p => p.Id == product.Id);
    }

    public async Task<Product> UpdateProductAsync(Product existingProduct, Product newProduct)
    {

        _context.Entry(existingProduct).State = EntityState.Modified;

        _context.Entry(existingProduct).CurrentValues.SetValues(newProduct);

        await _context.SaveChangesAsync();

        return await _context.Products.Include(p => p.ProductCategory).FirstOrDefaultAsync(p => p.Id == existingProduct.Id);
    }

    public async Task DeleteProductAsync(Product product)
    {
        _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }
}
