using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.DbContexts;

/* Why we need this
 * 1. Decoupling from Concrete DbContext.
 * 2. 
 */

public interface IDbContextProvider<TDbContext> where TDbContext : DbContext
{
    TDbContext GetDbContext();

    Task<TDbContext> GetDbContextAsync();
}
