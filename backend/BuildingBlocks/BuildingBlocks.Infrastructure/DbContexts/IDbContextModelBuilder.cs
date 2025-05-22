using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.DbContexts;

public interface IDbContextModelBuilder<TDbContext> where TDbContext : DbContext
{
    public void EntitiesConfigure(ModelBuilder modelBuilder);
    public void ConfigureConventions(ModelConfigurationBuilder configurationBuilder);
}
