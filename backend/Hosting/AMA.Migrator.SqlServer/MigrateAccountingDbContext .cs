using AMA.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AMA.Migrator.SqlServer;

public class MigrateAccountingDbContext : DbContext
{
    public MigrateAccountingDbContext(DbContextOptions<MigrateAccountingDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
           .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AMAccounting;",
           providerOptions => { providerOptions.EnableRetryOnFailure(); });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountingInfrastructureModule).Assembly);
    }
}
