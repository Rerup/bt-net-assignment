using System;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Repositories.Contracts;

namespace ProductApi.Data.Repositories.Implementations;

public class EntityFrameworkRepository<T> : IRepository<T> where T : class
{
    protected readonly ProductContext _context;
    private readonly DbSet<T> _dbSet;

    public EntityFrameworkRepository(ProductContext context)
    {
        _context = context;

        _dbSet = _context.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        _dbSet.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> UpdateAsync(T existingEntity, T newEntity)
    {
        _context.Entry(existingEntity).State = EntityState.Modified;

        _context.Entry(existingEntity).CurrentValues.SetValues(newEntity);

        await _context.SaveChangesAsync();

        return existingEntity;
    }

    public async Task<IQueryable<T>> GetQueryableAsync()
    {
        return await Task.FromResult(_dbSet.AsQueryable());
    }

}
