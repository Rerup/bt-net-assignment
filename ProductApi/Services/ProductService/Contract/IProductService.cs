using System;
using Domain.Products;

namespace ProductApi.Services.ProductService.Contract;

public interface IProductService
{

    Task<List<Product>> GetProductsAsync();

    Task<Product?> GetProductAsync(Guid id);

    Task<Product> CreateProductAsync(Product product);

    Task DeleteProductAsync(Product product);

    Task<Product> UpdateProductAsync(Product existingProduct, Product newProduct);

}
