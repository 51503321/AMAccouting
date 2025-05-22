using BuildingBlocks.Domain.Repositories;
using BuildingBlocks.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.Repositories;

/*
 * EfRepository is a generic class, taking three type parameters
 */

/* virtual keyword: 
 * 1. Allows for it to be overridden in a derived class.
 * 2. This is a key part of polymorphism, where different classes can provide their own implementation of a member
 */

public class EfRepository<TDbContext, TEntity, TKey>: IRepository<TEntity, TKey>
    where TEntity : class
    where TDbContext : DbContext
{
    protected readonly IDbContextProvider<TDbContext> _dbContextProvider; /* Instead of directly injecting the DbContext */

    public EfRepository(IDbContextProvider<TDbContext> dbContextProvider)
    {
        _dbContextProvider = dbContextProvider ?? throw new ArgumentNullException(nameof(dbContextProvider));
    }

    private TDbContext DbContextProvider() => _dbContextProvider.GetDbContext();

    public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await DbContextProvider().Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public virtual async Task AddAsync(TEntity entity, bool isSaveChange = false, CancellationToken cancellationToken = default)
    {
        await DbContextProvider().Set<TEntity>().AddAsync(entity, cancellationToken);
        if (isSaveChange) await DbContextProvider().SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(TEntity entity, bool isSaveChange = false, CancellationToken cancellationToken = default)
    {
        DbContextProvider().Set<TEntity>().Update(entity);
        if(isSaveChange) await DbContextProvider().SaveChangesAsync(cancellationToken);
    }   

    public virtual async Task DeleteAsync(TKey id, bool isSaveChange = false, CancellationToken cancellationToken = default)
    {
        var entity = await DbContextProvider().Set<TEntity>().FindAsync(id, cancellationToken) ?? throw new Exception($"Can't find entity {nameof(TEntity)} with id {id}");
        DbContextProvider().Set<TEntity>().Remove(entity);
        if (isSaveChange) await DbContextProvider().SaveChangesAsync(cancellationToken);
    }
}

