using Domain.Products;

namespace ProductApi.Data.Repositories.Contracts;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetProductsWithCategoryAsync();
}
