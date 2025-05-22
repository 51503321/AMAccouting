using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace BuildingBlocks.Infrastructure.DbContexts;

/* This class have to be a base class use for all derived class afterward */

public class AccountingDbContext : CoreKitDbContext<AccountingDbContext>
{
    private readonly IServiceProvider _serviceProvider;

    public AccountingDbContext(DbContextOptions<AccountingDbContext> options, IServiceProvider serviceProvider) : base(options, serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var builders = _serviceProvider.GetServices<IDbContextModelBuilder<AccountingDbContext>>();
        foreach (var builder in builders)
        {
            builder.EntitiesConfigure(modelBuilder);
        }
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        var builders = _serviceProvider.GetServices<IDbContextModelBuilder<AccountingDbContext>>();
        foreach (var builder in builders)
        {
            builder.ConfigureConventions(configurationBuilder);
        }
        base.ConfigureConventions(configurationBuilder);
    }
}
