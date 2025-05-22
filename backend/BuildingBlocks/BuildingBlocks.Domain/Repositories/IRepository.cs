namespace BuildingBlocks.Domain.Repositories;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, bool isSaveChange, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, bool isSaveChange, CancellationToken cancellationToken);
    Task DeleteAsync(TKey id, bool isSaveChange, CancellationToken cancellationToken);
}
