using Domain.Products;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Repositories.Contracts;

namespace ProductApi.Data.Repositories.Implementations;

public class ProductRepository : EntityFrameworkRepository<Product>, IProductRepository
{
    public ProductRepository(ProductContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsWithCategoryAsync()
    {
        var query = _context.Set<Product>().Include(p => p.ProductCategory);

        return await query.ToListAsync();
    }
}
