using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BuildingBlocks.Infrastructure.DbContexts;

public abstract class CoreKitDbContext<TContext> : DbContext where TContext : DbContext
{
    private readonly IServiceProvider _serviceProvider;

    private readonly CoreKitDbContextOptions _coreKitOptions;

    protected CoreKitDbContext()
    {

    }

    protected CoreKitDbContext(DbContextOptions<TContext> options, IOptions<CoreKitDbContextOptions> coreKitOptions) : base(options)
    {
        _coreKitOptions = coreKitOptions.Value ?? throw new ArgumentNullException(nameof(coreKitOptions));
    }

    protected CoreKitDbContext(DbContextOptions<TContext> options, IServiceProvider serviceProvider) : base(options)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
           .UseSqlServer(_coreKitOptions.ToString(), providerOptions => { providerOptions.EnableRetryOnFailure(); });
        base.OnConfiguring(optionsBuilder);
    }

    // xu ly auditfield in here
}
