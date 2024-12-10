using System;
using Domain.Products;
using ProductApi.Services.ProductService.Contract;
using ProductApi.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Services.ProductService.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _repository.GetProductsWithCategoryAsync();
    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        return await _repository.CreateAsync(product);
    }

    public async Task<Product> UpdateProductAsync(Product existingProduct, Product newProduct)
    {
        return await _repository.UpdateAsync(existingProduct, newProduct);
    }

    public async Task DeleteProductAsync(Product product)
    {
        await _repository.DeleteAsync(product);
    }
}
