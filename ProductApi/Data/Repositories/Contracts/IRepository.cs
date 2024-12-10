using System;

namespace ProductApi.Data.Repositories.Contracts;

public interface IRepository<T>
{

    Task<List<T>> GetAllAsync();

    Task<T?> GetAsync(Guid id);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T existingEntity, T newEntity);

    Task DeleteAsync(T entity);

    Task<IQueryable<T>> GetQueryableAsync();

}
